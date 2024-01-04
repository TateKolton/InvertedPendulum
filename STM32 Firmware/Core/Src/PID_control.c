/**********************************************************************************
 * Library Designed for implementing PID control
 * Tate Kolton, December 2023
 *********************************************************************************/

#include <PID_control.h>

// Initialize controller structure
void Controller_Init(PID_Controller* controller, double* input, double* output, double* setpoint, double kp, double ki, double kd, int sampleTime) {

	if (kp<0 || ki<0 || kd<0) return;

	double sampleTimeSec = sampleTime/1000.0;

	controller->Input = input;
	controller->Output = output;
	controller->Setpoint = setpoint;
	controller->Kp = kp;
	controller->Ki = ki*sampleTimeSec;
	controller->Kd = kd/sampleTimeSec;
	controller->LastInput = 0.00;
	controller->DInputPrev = 0.00;
	controller->FilterPeriod = 0.5;
	controller->SampleTime = sampleTime;
	controller->OutputSum = 0.00;
}

void Controller_Compute(PID_Controller* controller) {

	/*Compute all the working error variables*/
	  double input = *(controller->Input);
	  double error = *(controller->Setpoint) - input;
	  double dInput = (input - controller->LastInput);
	  controller->OutputSum += (controller->Ki * error);


//	  /*Clamp integral term */
//	  if(outputSum > 0.3) {
//		  outputSum= 0.3;
//	  }
//
//	  else if(outputSum < -0.3)  {
//		  outputSum= -0.3;
//	  }

	  /*Proportional Controller Contribution*/
	  double output = controller->Kp * error + controller->OutputSum - controller->Kd * dInput;

	  /*Check for output saturation */
	  if(output > controller->OutMax) {
		  output = controller->OutMax;
	  }

	  else if(output < controller->OutMin) {
		  output = controller->OutMin;
	  }

	  /*Populate controller output effort */
	  *(controller->Output) = output;

	  /*Remember some variables for next time*/
	  controller->LastInput = input;
	  controller->DInputPrev = dInput;
}

void Controller_SetOutputLimits(PID_Controller* controller, double min, double max) {
	controller->OutMin = min;
	controller->OutMax = max;
}

void Controller_SetSampleTime(PID_Controller* controller, int sampleTime) {
	controller->SampleTime = sampleTime;

}

// Adjust PID control parameters
void Controller_SetTunings(PID_Controller* controller, double kp, double ki, double kd){
   if (kp<0 || ki<0 || kd<0) return;
   double SampleTimeInSec = ((double)controller->SampleTime)/1000;

   controller->Kp = kp;
   controller->Ki = ki * SampleTimeInSec;
   controller->Kd = kd / SampleTimeInSec;
}

void Controller_SetFilterRatio(PID_Controller* controller, int filtPeriod){
	controller->FilterPeriod = filtPeriod;
}








