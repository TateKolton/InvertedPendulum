/**********************************************************************************
 * Library Designed for balancing an inverted pendulum
 * Tate Kolton, December 2023
 *********************************************************************************/

#ifndef PENDULUM_H
#define PENDULUM_H

#include <PID_control.h>

#define MAX_DISTURBANCE 37
#define SWINGDOWN_BEGIN_ANGLE 85
#define SWINGUP_MULTIPLIER 0.02
#define LONG_DELAY 500
#define SWINGUP_THRESH 2
#define SWINGUP_SETPOINT 73.75
#define SAMPLE_PERIOD 1
#define VOLTAGE_LIMIT_SWINGUP 13.1
#define VOLTAGE_LIMIT_BALANCE 6
#define ARM_CONTROL_LIMIT 180
#define MAX_MOTOR_VOLTAGE 24
#define MAX_PWM 10000
#define MAX_MSG_LENGTH 100
#define SWINGDOWN_THRESH 1
#define VELOCITY_SWINGUP_THRESH 0.5
#define MIN_VOLTAGE 1.5
#define VEL_SAMPLE_PERIOD 2.0
#define SWINGUP_DELAY 25
#define SWINGDOWN_DELAY 20
#define DEVICE_LIMIT 170
#define SWINGDOWN_INIT_DUTY 1700

void updateControllers(PID_Controller * pend_PID, PID_Controller * arm_PID);

extern double pendCurrPos, armCurrPos, pendOutCmd, armOutCmd, pendSetPoint, armSetPoint, P1, P2, I1, I2, D1, D2, dz;
extern double parsedValues[9];

#endif // PENDULUM_H
