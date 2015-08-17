#include "Arduino.h"
#include "duinocom.h"

const char identifyMsg = '#';

bool isMsgReady = false;
int msgPosition = 0;
char msg[MAX_MSG_LENGTH];
int msgLength = 0;

bool checkMsgReady()
{
  while (Serial.available() > 0) {
    byte b = Serial.read();

    if (!isMsgReady)
    {
      if (b == ';')
      {
        msg[msgPosition] = '\0';
        isMsgReady = true;
        msgLength = msgPosition+1;
        msgPosition = 0;
        Serial.println("msg ready");
      }
      else if (char(b) == '\n'
        || char(b) == '\r')
      {
        // ignore
      }
      else
      {
        msg[msgPosition] = b;
        msgPosition++;
      
      }
    }
    else
        msg[msgPosition] = '\0';
    delay(15);
  }

  if (msg[0] == identifyMsg)
    identify();

  return isMsgReady;
}

char* getMsg()
{
  // Reset the isMsgReady flag until a new message is received
  isMsgReady = false;

  char output[MAX_MSG_LENGTH];
  for (int i = 0; i < MAX_MSG_LENGTH; i++)
    output[i] = msg[i];

 //clearMsg(msg);

  return output;
}

void printMsg(byte msg[MAX_MSG_LENGTH])
{
  if (msg[0] != '\0')
  {
    Serial.print("msg:");
    for (int i = 0; i < MAX_MSG_LENGTH; i++)
    {
      if (msg[i] != '\0')
        Serial.print(char(msg[i]));
    }
    Serial.println();
  }
}

void clearMsg(byte msg[MAX_MSG_LENGTH])
{
  for (int i = 0; i < 10; i++)
  {
    msg[i] = '\0';
  }
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
