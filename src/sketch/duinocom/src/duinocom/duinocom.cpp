#include "Arduino.h"
#include "duinocom.h"

const char identifyCmd = '#';

byte* getCmd()
{
  byte cmd[MAX_CMD_LENGTH];
  
  clearCmd(cmd);

  int x = 0;
  while (Serial.available() > 0) {
    byte b = Serial.read();
    if (b != '\0')
    {
      cmd[x] = b;
    
    }
    else
    {
      cmd[x] = b;
    }
      x++;
    delay(100);
  }

  if (cmd[0] == identifyCmd)
    identify();

  return cmd;
}

void printCmd(byte cmd[MAX_CMD_LENGTH])
{
  if (cmd[0] != '\0')
  {
    Serial.print("Cmd:");
    for (int i = 0; i < MAX_CMD_LENGTH; i++)
    {
      if (cmd[i] != '\0')
        Serial.print(char(cmd[i]));
    }
    Serial.println();
  }
}

void clearCmd(byte cmd[MAX_CMD_LENGTH])
{
  //cmd[0] = 0;
  //for (int i = 1; i < 10; i++)
  //{
  //  cmd[i] = '\0';
 // }
}

void identify()
{
  Serial.println("duinocom");
}

int readInt2(char char1, char char2)
{
  char buffer[2];
  buffer[0] = char1;
  buffer[1] = char2;
  int number = atoi(buffer);

  return number;
}

int readInt3(char char1, char char2, char char3)
{
  char buffer[3];
  buffer[0] = char1;
  buffer[1] = char2;
  buffer[2] = char3;
  int number = atoi(buffer);

  return number;
}


// Example loop
/*void duinocomLoop()
{
  byte* cmd = getCmd(cmd);

  runCmd(cmd);
}*/


// Example runCmd function
/*void runCmd(byte cmd[MAX_CMD_LENGTH])
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
}*/
