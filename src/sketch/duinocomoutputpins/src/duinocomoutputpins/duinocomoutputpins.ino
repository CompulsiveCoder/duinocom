#include "Arduino.h"
#include "duinocom.h" 

void setup()
{
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }
  
  Serial.println("Starting demo");
  duinocomSetup();
}

void loop()
{
  byte cmd[10];
  
  clearCmd(cmd);

  getCmd(cmd);

  // Disabled; used for debugging only
  //printCmd(cmd);

  runCustomCmd(cmd);
  
}

void runCustomCmd(byte cmd[10])
{
  if (cmd[0] != '\0')
  {
    char letter = cmd[0];

    if (letter == '#')   {
      identify();
    }
    else if (letter == 'H')
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
  // Get the number of degrees (up to 3 digits)
  char buffer[2];
  buffer[0] = cmd[1];
  buffer[1] = cmd[2];
  int pin = atoi(buffer);
  
  Serial.println(pin);
  
  digitalWrite(pin, value);
}




