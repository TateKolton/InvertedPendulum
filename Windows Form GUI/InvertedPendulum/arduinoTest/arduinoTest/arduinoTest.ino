bool commFlag = true;
char swingUp = 'U';
char swingDown = 'D';
char fastCont = 'F';
char slowCont = 'S';
char sweepArm = 'W';
char zeroPend = 'P';
char zeroArm = 'A';

void setup() {
  Serial.begin(9600); // Initialize the serial communication
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  static unsigned long prevMillis = 0;
  const unsigned long interval = 10; // 1ms interval
  
  if (millis() - prevMillis >= interval) {
    prevMillis = millis();

    double sinValue = 5 * sin(2*3.14*millis() / 1000.0);
    double cosValue = 12 * cos(2*3.14*millis() / 1000.0);

    char sinStr[10]; // Buffer for the sin value string
    char cosStr[10]; // Buffer for the cos value string

    dtostrf(sinValue, 6, 3, sinStr); // Convert sinValue to string with 3 decimal places
    dtostrf(cosValue, 6, 3, cosStr); // Convert cosValue to string with 3 decimal places

    char buffer[30]; // Increased buffer size to accommodate the formatted string
    snprintf(buffer, sizeof(buffer), "%sA%sZ", sinStr, cosStr);

    if(commFlag)
    {
      Serial.println(buffer);
      //commFlag = false;
    }

  }
    //recieveData();
}

void parseMessage(char func)
{
  if(func == swingUp)
  {
    digitalWrite(LED_BUILTIN, HIGH);
  }

  else if(func == swingDown)
  {
    digitalWrite(LED_BUILTIN, LOW);
  }

  else if(func == fastCont)
  {
    //
  }

  else if(func == slowCont)
  {
    //
  }

  else if(func == sweepArm)
  {
    //
  }
  commFlag = true;
}

void recieveData()
{
  if(Serial.available() >= 2)
  {
    char startChar = Serial.read();
    if (startChar == 'X')
    {
      char function = Serial.read();
      char garbage = Serial.read();
      // No need to clear the end delimiter since we are not sending it from the PC
      parseMessage(function);
    }
  }
}
