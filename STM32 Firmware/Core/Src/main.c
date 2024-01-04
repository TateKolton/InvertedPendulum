/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2023 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "cmsis_os.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include <stdio.h>
#include <stdlib.h>
#include <pendulum.h>
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */
#define MAX_COUNTER_VALUE 10000000
#define STEPS_TO_DEG 0.04394531

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
TIM_HandleTypeDef htim2;
TIM_HandleTypeDef htim8;

UART_HandleTypeDef huart2;

osThreadId controlAlgoHandle;
osThreadId sendUARTDataHandle;
osThreadId recieveUARTDataHandle;
/* USER CODE BEGIN PV */
PID_Controller pend_controller, arm_controller;
uint32_t counter = 0;
uint32_t previousCounter = 0;
int32_t netPosition = 0;
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_USART2_UART_Init(void);
static void MX_TIM8_Init(void);
static void MX_TIM2_Init(void);
void computeControlEffort(void const * argument);
void sendData(void const * argument);
void recieveData(void const * argument);

/* USER CODE BEGIN PFP */

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/

/* USER CODE BEGIN 0 */

void updatePosition(uint32_t currentCounter) {
    // Calculate the change in counter value since the last callback
    int32_t counterChange = currentCounter - previousCounter;

    // Update the previous counter value for the next iteration
    previousCounter = currentCounter;

    // Handle wrap-around by checking if the change is larger than half the range
    if (counterChange > MAX_COUNTER_VALUE / 2) {
        counterChange -= MAX_COUNTER_VALUE + 1;  // Handle wrap from high to low
    } else if (counterChange < -MAX_COUNTER_VALUE / 2) {
        counterChange += MAX_COUNTER_VALUE + 1;  // Handle wrap from low to high
    }

    // Update the net position
    netPosition += counterChange;
}

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* Initialize PID Controllers for Pendulum angle and Motor Arm Angle */
  Controller_Init(&pend_controller, &pendCurrPos, &pendOutCmd, &pendSetPoint, P1, I1, D1, SAMPLE_PERIOD);
  Controller_Init(&arm_controller, &armCurrPos, &armOutCmd, &armSetPoint, P2, I2, D2, SAMPLE_PERIOD);

  /* Set Saturation Limits on Control Output */
  Controller_SetOutputLimits(&pend_controller, -VOLTAGE_LIMIT, VOLTAGE_LIMIT);
  Controller_SetOutputLimits(&arm_controller, -VOLTAGE_LIMIT, VOLTAGE_LIMIT);

  /* Get initial positions for pendulum and arm */
  stateFeedback(&pend_controller, &arm_controller);

  /* Initialize Variables */
  pendCurrPos = 0;
  pendOutCmd = 0;
  armCurrPos = 0;
  armOutCmd = 0;
  pendSetPoint = 0;
  armSetPoint = 0;

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_USART2_UART_Init();
  MX_TIM8_Init();
  MX_TIM2_Init();
  /* USER CODE BEGIN 2 */

  /* Start PWM for DC Motor */
  HAL_TIM_PWM_Start(&htim8, TIM_CHANNEL_2);
  HAL_TIM_Encoder_Start(&htim2, TIM_CHANNEL_ALL);


  /* USER CODE END 2 */

  /* USER CODE BEGIN RTOS_MUTEX */
  /* add mutexes, ... */
  /* USER CODE END RTOS_MUTEX */

  /* USER CODE BEGIN RTOS_SEMAPHORES */
  /* add semaphores, ... */
  /* USER CODE END RTOS_SEMAPHORES */

  /* USER CODE BEGIN RTOS_TIMERS */
  /* start timers, add new ones, ... */
  /* USER CODE END RTOS_TIMERS */

  /* USER CODE BEGIN RTOS_QUEUES */
  /* add queues, ... */
  /* USER CODE END RTOS_QUEUES */

  /* Create the thread(s) */
  /* definition and creation of controlAlgo */
  osThreadDef(controlAlgo, computeControlEffort, osPriorityNormal, 0, 128);
  controlAlgoHandle = osThreadCreate(osThread(controlAlgo), NULL);

  /* definition and creation of sendUARTData */
  osThreadDef(sendUARTData, sendData, osPriorityNormal, 0, 128);
  sendUARTDataHandle = osThreadCreate(osThread(sendUARTData), NULL);

  /* definition and creation of recieveUARTData */
  osThreadDef(recieveUARTData, recieveData, osPriorityNormal, 0, 128);
  recieveUARTDataHandle = osThreadCreate(osThread(recieveUARTData), NULL);

  /* USER CODE BEGIN RTOS_THREADS */
  /* add threads, ... */
  /* USER CODE END RTOS_THREADS */

  /* Start scheduler */
  osKernelStart();

  /* We should never get here as control is now taken by the scheduler */
  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Configure the main internal regulator output voltage
  */
  if (HAL_PWREx_ControlVoltageScaling(PWR_REGULATOR_VOLTAGE_SCALE1) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSI;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.HSICalibrationValue = RCC_HSICALIBRATION_DEFAULT;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSI;
  RCC_OscInitStruct.PLL.PLLM = 1;
  RCC_OscInitStruct.PLL.PLLN = 10;
  RCC_OscInitStruct.PLL.PLLP = RCC_PLLP_DIV7;
  RCC_OscInitStruct.PLL.PLLQ = RCC_PLLQ_DIV2;
  RCC_OscInitStruct.PLL.PLLR = RCC_PLLR_DIV2;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV1;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_4) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief TIM2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM2_Init(void)
{

  /* USER CODE BEGIN TIM2_Init 0 */

  /* USER CODE END TIM2_Init 0 */

  TIM_Encoder_InitTypeDef sConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};

  /* USER CODE BEGIN TIM2_Init 1 */

  /* USER CODE END TIM2_Init 1 */
  htim2.Instance = TIM2;
  htim2.Init.Prescaler = 0;
  htim2.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim2.Init.Period = 10000000;
  htim2.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim2.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_ENABLE;
  sConfig.EncoderMode = TIM_ENCODERMODE_TI12;
  sConfig.IC1Polarity = TIM_ICPOLARITY_RISING;
  sConfig.IC1Selection = TIM_ICSELECTION_DIRECTTI;
  sConfig.IC1Prescaler = TIM_ICPSC_DIV1;
  sConfig.IC1Filter = 0;
  sConfig.IC2Polarity = TIM_ICPOLARITY_RISING;
  sConfig.IC2Selection = TIM_ICSELECTION_DIRECTTI;
  sConfig.IC2Prescaler = TIM_ICPSC_DIV1;
  sConfig.IC2Filter = 0;
  if (HAL_TIM_Encoder_Init(&htim2, &sConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim2, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM2_Init 2 */

  /* USER CODE END TIM2_Init 2 */

}

/**
  * @brief TIM8 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM8_Init(void)
{

  /* USER CODE BEGIN TIM8_Init 0 */

  /* USER CODE END TIM8_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};
  TIM_OC_InitTypeDef sConfigOC = {0};
  TIM_BreakDeadTimeConfigTypeDef sBreakDeadTimeConfig = {0};

  /* USER CODE BEGIN TIM8_Init 1 */

  /* USER CODE END TIM8_Init 1 */
  htim8.Instance = TIM8;
  htim8.Init.Prescaler = 0;
  htim8.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim8.Init.Period = 10000;
  htim8.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim8.Init.RepetitionCounter = 0;
  htim8.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_ENABLE;
  if (HAL_TIM_Base_Init(&htim8) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim8, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_Init(&htim8) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterOutputTrigger2 = TIM_TRGO2_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim8, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sConfigOC.OCMode = TIM_OCMODE_PWM1;
  sConfigOC.Pulse = 0;
  sConfigOC.OCPolarity = TIM_OCPOLARITY_HIGH;
  sConfigOC.OCNPolarity = TIM_OCNPOLARITY_HIGH;
  sConfigOC.OCFastMode = TIM_OCFAST_DISABLE;
  sConfigOC.OCIdleState = TIM_OCIDLESTATE_RESET;
  sConfigOC.OCNIdleState = TIM_OCNIDLESTATE_RESET;
  if (HAL_TIM_PWM_ConfigChannel(&htim8, &sConfigOC, TIM_CHANNEL_2) != HAL_OK)
  {
    Error_Handler();
  }
  sBreakDeadTimeConfig.OffStateRunMode = TIM_OSSR_DISABLE;
  sBreakDeadTimeConfig.OffStateIDLEMode = TIM_OSSI_DISABLE;
  sBreakDeadTimeConfig.LockLevel = TIM_LOCKLEVEL_OFF;
  sBreakDeadTimeConfig.DeadTime = 0;
  sBreakDeadTimeConfig.BreakState = TIM_BREAK_DISABLE;
  sBreakDeadTimeConfig.BreakPolarity = TIM_BREAKPOLARITY_HIGH;
  sBreakDeadTimeConfig.BreakFilter = 0;
  sBreakDeadTimeConfig.Break2State = TIM_BREAK2_DISABLE;
  sBreakDeadTimeConfig.Break2Polarity = TIM_BREAK2POLARITY_HIGH;
  sBreakDeadTimeConfig.Break2Filter = 0;
  sBreakDeadTimeConfig.AutomaticOutput = TIM_AUTOMATICOUTPUT_DISABLE;
  if (HAL_TIMEx_ConfigBreakDeadTime(&htim8, &sBreakDeadTimeConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM8_Init 2 */

  /* USER CODE END TIM8_Init 2 */
  HAL_TIM_MspPostInit(&htim8);

}

/**
  * @brief USART2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART2_UART_Init(void)
{

  /* USER CODE BEGIN USART2_Init 0 */

  /* USER CODE END USART2_Init 0 */

  /* USER CODE BEGIN USART2_Init 1 */

  /* USER CODE END USART2_Init 1 */
  huart2.Instance = USART2;
  huart2.Init.BaudRate = 115200;
  huart2.Init.WordLength = UART_WORDLENGTH_8B;
  huart2.Init.StopBits = UART_STOPBITS_1;
  huart2.Init.Parity = UART_PARITY_NONE;
  huart2.Init.Mode = UART_MODE_TX_RX;
  huart2.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart2.Init.OverSampling = UART_OVERSAMPLING_16;
  huart2.Init.OneBitSampling = UART_ONE_BIT_SAMPLE_DISABLE;
  huart2.AdvancedInit.AdvFeatureInit = UART_ADVFEATURE_NO_INIT;
  if (HAL_UART_Init(&huart2) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART2_Init 2 */

  /* USER CODE END USART2_Init 2 */

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
  GPIO_InitTypeDef GPIO_InitStruct = {0};
/* USER CODE BEGIN MX_GPIO_Init_1 */
/* USER CODE END MX_GPIO_Init_1 */

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOC_CLK_ENABLE();
  __HAL_RCC_GPIOH_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOA, IN_1_Pin|IN_2_Pin, GPIO_PIN_RESET);

  /*Configure GPIO pins : IN_1_Pin IN_2_Pin */
  GPIO_InitStruct.Pin = IN_1_Pin|IN_2_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

/* USER CODE BEGIN MX_GPIO_Init_2 */
/* USER CODE END MX_GPIO_Init_2 */
}

/* USER CODE BEGIN 4 */

/* USER CODE END 4 */

/* USER CODE BEGIN Header_computeControlEffort */
/**
  * @brief  Function implementing the controlAlgorith thread.
  * @param  argument: Not used
  * @retval None
  */
/* USER CODE END Header_computeControlEffort */
void computeControlEffort(void const * argument)
{
  /* USER CODE BEGIN 5 */
  /* Infinite loop */

//  for(;;)
//  {
//	/* Thread sleep for sample time */
//    osDelay(SAMPLE_PERIOD);
//
//	 /* Read current pendulum position state */
//	 stateFeedback(&pend_controller, &arm_controller);
//
//    if (*pend_controller.Input < MAX_DISTURBANCE && *pend_controller.Input > -MAX_DISTURBANCE)
//	{
//
//		/* Update Pendulum Control Effort */
//		updateControllers(&pend_controller, &arm_controller);
//
//		double outVoltage = *pend_controller.Output;
//
//		/* Set Motor Direction */
//		if(outVoltage < 0)
//		{
//
//			HAL_GPIO_WritePin(GPIOA, IN_1_Pin, GPIO_PIN_SET);
//			HAL_GPIO_WritePin(GPIOA, IN_2_Pin, GPIO_PIN_RESET);
//		}
//
//		else
//		{
//			HAL_GPIO_WritePin(GPIOA, IN_1_Pin, GPIO_PIN_RESET);
//			HAL_GPIO_WritePin(GPIOA, IN_2_Pin, GPIO_PIN_SET);
//		}
//
//		/* Calculate PWM counter for given voltage */
//		int dutyCycle = (abs(outVoltage) + dz)* MAX_PWM / MAX_MOTOR_VOLTAGE;
//
//		/* Set Motor PWM Cycle */
//		__HAL_TIM_SET_COMPARE(&htim8, TIM_CHANNEL_2, dutyCycle);
//	}
//
//	/* Brake Motor if outside of balancing range */
//	HAL_GPIO_WritePin(GPIOA, IN_1_Pin, GPIO_PIN_SET);
//	HAL_GPIO_WritePin(GPIOA, IN_2_Pin, GPIO_PIN_RESET);
//}

	  for(;;)
	  {
		/* Thread sleep for sample time */
		osDelay(SAMPLE_PERIOD);

		// Updates the encoder;
		updatePosition(TIM2->CNT);

		armCurrPos = netPosition*STEPS_TO_DEG;

		 /* Read current pendulum position state */
		 //stateFeedback(&pend_controller, &arm_controller);

			/* Update Pendulum Control Effort */
		 updateControllers(&pend_controller, &arm_controller);

		 double outVoltage = *arm_controller.Output;

		/* Set Motor Direction */
		if(outVoltage < 0)
		{

			HAL_GPIO_WritePin(GPIOA, IN_1_Pin, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOA, IN_2_Pin, GPIO_PIN_RESET);
		}

		else
		{
			HAL_GPIO_WritePin(GPIOA, IN_1_Pin, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOA, IN_2_Pin, GPIO_PIN_SET);
		}

		/* Calculate PWM counter for given voltage */
		int dutyCycle = (abs(outVoltage) + dz)* MAX_PWM / MAX_MOTOR_VOLTAGE;

		/* Set Motor PWM Cycle */
		__HAL_TIM_SET_COMPARE(&htim8, TIM_CHANNEL_2, dutyCycle);

		}

  /* USER CODE END 5 */
}

/* USER CODE BEGIN Header_sendData */
/**
* @brief Function implementing the sendUARTData thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_sendData */
void sendData(void const * argument)
{
  /* USER CODE BEGIN sendData */
  /* Infinite loop */
  for(;;)
  {
    for(int32_t i=0; i<1000; i++) {
    	armSetPoint = 8*i;
    	osDelay(35);
    	armSetPoint = 8*i + 5;
    	osDelay(35);
    	armSetPoint = 8*i;
    	osDelay(35);
    }

    for(int32_t i=1000; i<0; i--) {
    	armSetPoint = 8*i;
    	osDelay(35);
    	armSetPoint = 8*i + 5;
    	osDelay(35);
    	armSetPoint = 8*i;
    	osDelay(35);
    }
  }
  /* USER CODE END sendData */
}

/* USER CODE BEGIN Header_recieveData */
/**
* @brief Function implementing the recieveUARTData thread.
* @param argument: Not used
* @retval None
*/
/* USER CODE END Header_recieveData */
void recieveData(void const * argument)
{
  /* USER CODE BEGIN recieveData */
  /* Infinite loop */
  for(;;)
  {
    osDelay(1);
    printf("NET POS: %d ", (int)*arm_controller.Input);
    printf("SETPOINT: %d ", (int)*arm_controller.Setpoint);
    printf("VOLTAGE: %d\n", (int)*arm_controller.Output);

  }
  /* USER CODE END recieveData */
}

/**
  * @brief  Period elapsed callback in non blocking mode
  * @note   This function is called  when TIM6 interrupt took place, inside
  * HAL_TIM_IRQHandler(). It makes a direct call to HAL_IncTick() to increment
  * a global variable "uwTick" used as application time base.
  * @param  htim : TIM handle
  * @retval None
  */
void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)
{
  /* USER CODE BEGIN Callback 0 */

  /* USER CODE END Callback 0 */
  if (htim->Instance == TIM6) {
    HAL_IncTick();
  }
  /* USER CODE BEGIN Callback 1 */

  /* USER CODE END Callback 1 */
}

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
