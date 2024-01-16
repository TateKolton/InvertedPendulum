#include <pendulum.h>

double pendCurrPos, armCurrPos, pendOutCmd, armOutCmd, pendSetPoint, armSetPoint;
double P1 = 0.36;
double I1 = 0.0;
double D1 = 0.05;
double P2 = 0.12;
double I2 = 0.04;
double D2 = 0.07;
double dz = 2.75;
double parsedValues[9];

void updateControllers(PID_Controller * pend_PID, PID_Controller * arm_PID) {

	 /* Update Control effort based on current state */
	 Controller_Compute(arm_PID);
	 Controller_Compute(pend_PID);
}
