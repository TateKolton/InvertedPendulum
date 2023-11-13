// PWM values from 0-16383

#include <PID_v1.h>
#include <Encoder.h>

const int motor = 23;
const int in1 = 22;
const int in2 = 21;
const int A_1 = 11;
const int B_1 = 12;
const int A_2 = 28;
const int B_2 = 29;
const int disturbanceLimit = 40;
const int PWMlimit = 16383;
const int sampleTime = 2500;
const int sampleTimeSU = 1;

int oscCount = 0;
double encRes = 4*2048/360.0;
double pendCurrPos1, armCurrPos1, pendOutCmd1, armOutCmd1, pendSetPoint1, armSetPoint1, outVoltage1, osc1Pos, osc2Pos, pendCurrPos, armCurrPos, pendOutCmd, armOutCmd, pendSetPoint, armSetPoint, outVoltage, oscAmp, currVel;
double armPrevPos = 0;
double pendPrevPos = 10;
double p1 = 0.0;
double p2 = 0.0;
double velInterval = 2.0;
double velThresh = 2.0;
double pendPrevPos1 = 0.00;
double currVel1 = 0.0;
double parsedValues[9];
double P1 = 0.3;
double D1 = 0.035;
double I1 = 0;
double P2 = 0.1;
double I2 = 0.01;
double D2 = 0.035;
double dz1 = 2.75;
double dz2 = 2.75;
double filterInc = 1;
double K = -0.15;
double outCmd = 0.0;
const double equilibriumThresh = 0.5;
const double armThresh = 0.5;
static unsigned long millis1 = 0;
static unsigned long millis2 = 0;
static unsigned long pingMicros = 0;
static unsigned long pingMillis = 0;
static unsigned long prevMillisTest = 0;
static unsigned long SDmillis = 0;

const unsigned long graphInterval = 15;
const unsigned long serialWait = 200;
const unsigned long stabilityWait = 500;
const unsigned long ampThresh = 6.0;
bool armFlag = true;
bool testFlag = true;
bool commFlag = true;
bool startFlag = false;
bool oscFlag = false;
bool waitForResponse = false;
bool zeroIntegral = false;
char swingU = 'U';
char swingUF = 'F';
char swingD = 'D';
char zeroPend = 'P';
char zeroArm = 'A';
char plusSixty = 'Y';
char minusSixty = 'J';

struct FilterState {
  bool stable;
  bool filter;
  bool disableFilter;
  bool enableFilter;
  double filterPeriod;
  double maxFilterPeriod;
};

FilterState state = {
  false,     // stable
  false,     // filter
  false,     // disableFilter
  false,     // enableFilter
  1.0,         // filterPeriod
  2.0          // maxFilterPeriod
};

Encoder arm(A_1, B_1);
Encoder pendulum(A_2, B_2);
PID pend_controller(&pendCurrPos, &pendOutCmd, &pendSetPoint, P1, I1, D1, DIRECT);
PID arm_controller(&armCurrPos, &armOutCmd, &armSetPoint, P2, I2, D2, DIRECT);

void setup() {

  Serial.begin(115200);
  pinMode(in1, OUTPUT);
  pinMode(in2, OUTPUT);
  pinMode(motor, OUTPUT);
  analogWriteResolution(14);
  analogWriteFrequency(motor,9155.0); 
  pend_controller.SetMode(AUTOMATIC);
  pend_controller.SetOutputLimits(-5,5);
  pend_controller.SetSampleTime(sampleTime);
  arm_controller.SetMode(AUTOMATIC);
  arm_controller.SetOutputLimits(-180,180);
  arm_controller.SetSampleTime(sampleTime);
  pendulum.write(0);
  arm.write(0);
  pendSetPoint = 0;
  armSetPoint = 0;
  armCurrPos = 0;
}

void loop() {

 ping(0.00, 0.00);
 
}

void runPendulum()
{
  delay(250);
  arm.write(0);
  armSetPoint = 0;
  pendulum.write(0);
  stateFeedback();
  swingUp();
  balancePendulum();
}

void runPendulumFast()
{
  delay(250);
  arm.write(0);
  armSetPoint = 0;
  pendulum.write(0);
  stateFeedback();
  swingUpFast();
  balancePendulum();
}

void stateFeedback()
{
  armCurrPos = arm.read()/encRes;
  pendCurrPos = -1*pendulum.read()/encRes;
  pendCurrPos1 = pendCurrPos;
  pendSetPoint = armOutCmd;
}

void balancePendulum()
{
  stateFeedback();
   
 while(pendCurrPos<disturbanceLimit && pendCurrPos>-disturbanceLimit)
  {
    stateFeedback();

    if(pend_controller.Compute(filterRatio(state.filterPeriod), zeroIntegral))
    {
      arm_controller.Compute(filterRatio(state.filterPeriod), zeroIntegral);   

      if(zeroIntegral)
      {
        zeroIntegral = false;
      }

      if(pendOutCmd<0) 
      {
        digitalWrite(in1, HIGH);
        digitalWrite(in2, LOW);
        outVoltage = (abs(pendOutCmd)+dz1)*PWMlimit/24.0;
      }

      else
      {
        digitalWrite(in2, HIGH);
        digitalWrite(in1, LOW);
        outVoltage = (abs(pendOutCmd)+dz2)*PWMlimit/24.0;
      }

      analogWrite(motor, outVoltage); 

      if(ping(pendCurrPos, armCurrPos))
      {
        dynamicLPFilter();
      }
    }
  }
  
  digitalWrite(in1, LOW);
  digitalWrite(in2, LOW);
}

void swingUp()
{
  stateFeedback();
  pend_controller.SetTunings(P1, 0.0, D1);
  arm_controller.SetTunings(P2, 0.0, D2);
  currVel1 = 0;
  pendPrevPos1 = pendCurrPos1;
  
  while(pendCurrPos1>-(180-(0.9*disturbanceLimit)) && pendCurrPos1<(180-(0.9*disturbanceLimit)))
  {

    if(millis() - millis2 > sampleTimeSU)
    {
      millis2 = millis();
      stateFeedback();

      if(ping(pendCurrPos1, armCurrPos))
        refreshVelSU();

      p1 = cos(pendCurrPos1*6.283/360.0);
      p2 = currVel1;
      outCmd = p1*p2*K;
        
      if(outCmd<0) 
      {
        digitalWrite(in1, HIGH);
        digitalWrite(in2, LOW);
      }
  
      else
      {
        digitalWrite(in2, HIGH);
        digitalWrite(in1, LOW);
      }

      outVoltage = (abs(outCmd)+2.75)*PWMlimit/24.0;
      analogWrite(motor, outVoltage);
      
    }
  }

  stateFeedback();
  
  if(pendCurrPos1>0)
  {
    pendulum.write(-1*(pendCurrPos1-180.0)*encRes);
  }

  else
  {
    pendulum.write(-1*(180.0+pendCurrPos1)*encRes);
  }

  outCmd = 0.0;
}

void swingUpFast()
{
  stateFeedback();
  pend_controller.SetTunings(P1, 0.0, D1);
  arm_controller.SetTunings(P2, 0.0, D2);
  currVel1 = 0;
  pendPrevPos1 = pendCurrPos1;
  
  while(pendCurrPos1>-100 && pendCurrPos1<100 && armCurrPos < 190 && armCurrPos1 > - 190)
  {
   digitalWrite(in1, HIGH);
   digitalWrite(in2, LOW);
   
    if(millis() - millis2 > sampleTimeSU)
    {
        millis2 = millis();
        stateFeedback();
        ping(pendCurrPos1, armCurrPos);
       
        outCmd = 5.5;
        outVoltage = (abs(outCmd)+2.75)*PWMlimit/24.0;
        analogWrite(motor, outVoltage);
    }
  }

  while(pendCurrPos1>-140 && pendCurrPos1<140 && armCurrPos < 190 && armCurrPos1 > - 190)
  {
    digitalWrite(in1, LOW);
    digitalWrite(in2, HIGH);
    
    if(millis() - millis2 > sampleTimeSU)
    {
        millis2 = millis();
        stateFeedback();
        ping(pendCurrPos1, armCurrPos1);
        outCmd = 10;
        outVoltage = (abs(outCmd)+2.75)*PWMlimit/24.0;
        analogWrite(motor, outVoltage);
    }
  }

  stateFeedback();
  
  if(pendCurrPos1>0)
  {
    pendulum.write(-1*(pendCurrPos1-180.0)*encRes);
  }

  else
  {
    pendulum.write(-1*(180.0+pendCurrPos1)*encRes);
  }

  outCmd = 0.0;
}

  void swingDown()
  {
    digitalWrite(in1, LOW);
    digitalWrite(in2, LOW);
    delay(2000);
  }

  void dynamicLPFilter()
  {
    if(millis()-millis1 > stabilityWait)
    {
      if(abs(pendCurrPos) > equilibriumThresh && state.stable)
      {
        state.disableFilter = true;
        state.stable = false;
      }

      if(state.disableFilter)
      {
        if(disableFilter())
        {
          state.disableFilter = false;
          state.filter = false;
        }
      }

      if(!state.filter)
      {
        if(!state.enableFilter)
        {
          if(stateTransition())
            state.enableFilter = true;
        }

        if(state.enableFilter)
        {
          if(abs(armCurrPos)<armThresh)
          {
            if(enableFilter())
            {
              state.enableFilter = false;
              state.stable = true;
              state.filter = true;
              zeroIntegral = true;
              millis1 = millis();
            }
          }
        }
      }
    }
  }

int disableFilter()
{
    if(state.filterPeriod == 1.0)
    {
        return 1;
    }

    else
    {
        (state.filterPeriod) -= filterInc;
    }

    return 0;
}

int enableFilter()
{
    if(state.filterPeriod == state.maxFilterPeriod)
    {
        return 1;
    }

    else
    {
        (state.filterPeriod) += filterInc;
    }

    return 0;
}

void refreshVel()
{
  currVel = 1000*(armCurrPos - armPrevPos)/(graphInterval);
  armPrevPos = armCurrPos;
}

int calcOscAmp()
{
    refreshVel();
    
    if(abs(currVel) < velThresh && oscCount == 0)
    {
      osc1Pos = armCurrPos;
      oscCount++;
    }

    else if(abs(currVel) > 2*velThresh && oscCount == 1)
    {
      oscCount++;
    }

    else if(abs(currVel) < velThresh && oscCount == 2)
    {
      osc2Pos = armCurrPos;
      oscCount++;
    }

    else if(oscCount ==3)
    {
      oscAmp = abs(osc2Pos-osc1Pos);
      oscCount = 0;
      return 1;
    }

    return 0;
}


int stateTransition()
{
  if(calcOscAmp())
  {
    if(oscAmp < ampThresh)
    {
      return 1;
    }
  }

  return 0;
}

double filterRatio(int filtPeriod)
{
   double x = 1/(double)filtPeriod;
   return (filtPeriod-1)*x;
}


// Communication API's //

void publishAngles(double arm, double pend)
{
    char armStr[10];
    char pendStr[10];
    dtostrf(arm, 6, 2, armStr);
    dtostrf(pend, 6, 2, pendStr);

    char buffer[50]; // Increased buffer size to accommodate the formatted string
    snprintf(buffer, sizeof(buffer), "%sA%sZ", armStr, pendStr);

    if(commFlag)
    {
      Serial.println(buffer);

      if(startFlag)
        commFlag = false;
    }
}

void parseMessage(char func)
{

  P1 = parsedValues[0];
  I1 = parsedValues[1];
  D1 = parsedValues[2];
  P2 = parsedValues[3];
  I2 = parsedValues[4];
  D2 = parsedValues[5];
  dz1 = parsedValues[6];
  dz2 = parsedValues[7];
  int targetAngle = (int)parsedValues[8];

  pend_controller.SetTunings(P1, I1, D1);
  arm_controller.SetTunings(P2, I2, D2);
  armSetPoint = targetAngle;
  
  
  commFlag = true;

  if(func == swingU)
  {
    runPendulum();
  }

  else if(func == swingUF)
  {
    runPendulumFast();
  }

  else if(func == swingD)
  {
    swingDown();
  }

  else if(func == zeroArm)
  {
    armSetPoint = 0;
  }

  else if(func == zeroPend)
  {
    pendulum.write(0);
  }

  else if(func == plusSixty)
  {
    armSetPoint = 60;
  }

  else if(func == minusSixty)
  {
    armSetPoint = -60;
  }
}


bool parseControllerString()
{
  if (Serial.available() >= 2) {
    char firstChar = Serial.read();
    char programMode = 'P';

    if(firstChar == 'P')
    {
      String receivedString = Serial.readStringUntil('Z');
      
      int startIndex = 0; 
      int valueIndex = 0;
      
      // Loop through the string to extract double values
      
      for (int i = 1; i < receivedString.length(); i++) {
          if (receivedString.charAt(i) == 'A' || i == receivedString.length() - 1) {
              String valueStr = receivedString.substring(startIndex+1, i-1); 

          if (valueIndex == 9) {
            programMode = receivedString.charAt(startIndex+1); 
            break; 
          }
          
          parsedValues[valueIndex] = atof(valueStr.c_str()); 
          startIndex = i; 
          valueIndex++;
          
          if (valueIndex > 9) {
            break; 
          }
        }
      }

      parseMessage(programMode);
      startFlag = true;
      return true;
    }
    return false;
  }
  return false;
}

bool ping(double pend, double arm)
{
  if(millis() - pingMillis > graphInterval)
  {
    publishAngles(pend, arm);
    pingMillis = millis();
    pingMicros = micros();
    waitForResponse = true;
    return true;
  }

  if(waitForResponse)
  {
    if (micros() - pingMicros > serialWait)
    {
      if(parseControllerString())
        waitForResponse = false;
    }
  }

  return false;
}

int refreshVelSU()
{
  currVel1 = 6283/360.0*(pendCurrPos1 - pendPrevPos1)/(graphInterval);
  pendPrevPos1 = pendCurrPos1;
}
