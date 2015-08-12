#include "Arduino.h"
#include <duinocom.h>

void setup()
{
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }
  
  Serial.println("Starting duinocom demo");
  Serial.println("Send 'H[pin]' or 'H13' to set a pin high.");
  Serial.println("Send 'L[pin]' or 'L13' to set a pin low.");
}

void loop()
{
  byte* cmd = getCmd();

  runCmd(cmd);
  
  delay(100);
}

void runCmd(byte cmd[10])
{
  byte letter = cmd[0];
    Serial.print("'");
    Serial.print(letter);
    Serial.print("'");
    Serial.println();
  if (letter != '\0')
  {
    if (letter == 'H')
    {
      Serial.println("HIGH");
      turn(HIGH, cmd);
    }
    else if (letter == 'L')
    {
      Serial.println("LOW");
      turn(LOW, cmd);
    }
    else
    {
      Serial.println("Invalid command");
    }
  }
}

void turn(bool value, byte cmd[10])
{
  int pin = readInt2(cmd[1], cmd[2]);
  
  Serial.println(pin);
  
  digitalWrite(pin, value);
}




