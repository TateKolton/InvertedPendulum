/**********************************************************************************
 * Library Designed for balancing an inverted pendulum
 * Tate Kolton, December 2023
 *********************************************************************************/

#ifndef PENDULUM_H
#define PENDULUM_H

#include <PID_control.h>

#define MAX_DISTURBANCE 15
#define SAMPLE_PERIOD 1
#define VOLTAGE_LIMIT 24
#define MAX_MOTOR_VOLTAGE 24
#define A1 11
#define B1 12
#define A2 28
#define B2 29
#define MAX_PWM 10000
#define FILL 5
#define VOID_OUTCMD

void updateControllers(PID_Controller * pend_PID, PID_Controller * arm_PID);
void stateFeedback(PID_Controller * pend_PID, PID_Controller * arm_PID);

extern double pendCurrPos, armCurrPos, pendOutCmd, armOutCmd, pendSetPoint, armSetPoint, P1, P2, I1, I2, D1, D2, dz;
extern double parsedValues[9];

#endif // PENDULUM_H
