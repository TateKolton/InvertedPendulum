/**********************************************************************************
 * Library Designed for implementing PID control
 * Tate Kolton, December 2023
 *********************************************************************************/

// pid_controller.h
#ifndef PID_CONTROLLER_H
#define PID_CONTROLLER_H

// PID controller struct ***************************************************************************

typedef struct {
	double* Input;
	double* Output;
	double* Setpoint;
	double Kp;
	double Ki;
	double Kd;
	int SampleTime;
	int FilterPeriod;
	double OutMin;
	double OutMax;
	double LastInput;
	double DInputPrev;
	double OutputSum;

}PID_Controller;
//commonly used functions **************************************************************************

void Controller_Init(PID_Controller* controller, double* input, double* output, double* setpoint, double kp, double ki, double kd, int sampleTime);

void Controller_Compute(PID_Controller* controller);

void Controller_SetOutputLimits(PID_Controller* controller, double min, double max);

void Controller_SetSampleTime(PID_Controller* controller, int sampleTime);

void Controller_SetTunings(PID_Controller* controller, double kp, double ki, double kd);

void Controller_SetFilterRatio(PID_Controller* controller, int filtPeriod);

#endif // PID_CONTROLLER_H


