#include <pendulum.h>

double pendCurrPos, armCurrPos, pendOutCmd, armOutCmd, pendSetPoint, armSetPoint;
double P1 = 0.3;
double I1 = 0;
double D1 = 0.035;
double P2 = 1.3;
double I2 = 0.2;
double D2 = 0.03;
double dz = 2.75;
double parsedValues[9];


void stateFeedback(PID_Controller * pend_PID, PID_Controller * arm_PID)
{
//  armCurrPos = FILL;
//  pendCurrPos = FILL;
}

void updateControllers(PID_Controller * pend_PID, PID_Controller * arm_PID) {

	 /* Update Control effort based on current state */
	 Controller_Compute(arm_PID);
	 Controller_Compute(pend_PID);
}
