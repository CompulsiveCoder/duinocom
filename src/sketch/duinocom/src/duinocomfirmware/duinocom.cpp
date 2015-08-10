#include "Arduino.h"
#include "duinocom.h"

const char identifyCmd = '#';


void duinocomSetup()
{
}

void duinocomLoop()
{
  byte cmd[10];
  
  clearCmd(cmd);

  getCmd(cmd);

  // Disabled; used for debugging only
  //printCmd(cmd);

  runCmd(cmd);
}


void getCmd(byte cmd[10])
{
  int x = 0;
  while (Serial.available() > 0) {
    cmd[x] = Serial.read();
    
    x++;
    delay(100);
  }
}

void runCmd(byte cmd[10])
{
  if (cmd[0] != '\0')
  {
    char letter = cmd[0];

    if (letter == identifyCmd)
    {
      identify();
    }
    else
    {
      Serial.println("Invalid command");
    }
  }
}

void printCmd(byte cmd[10])
{
  if (cmd[0] != '\0')
  {
    Serial.print("Cmd:");
    for (int i = 0; i < 10; i++)
    {
      if (cmd[i] != '\0')
        Serial.print(char(cmd[i]));
    }
    Serial.println();
  }
}

void clearCmd(byte cmd[10])
{
  for (int i = 0; i < 10; i++)
  {
    cmd[i] = '\0';
  }
}

void identify()
{
  Serial.println("duinocom");
}
