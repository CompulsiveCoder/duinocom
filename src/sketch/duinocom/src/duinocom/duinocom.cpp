#include "Arduino.h"
#include "duinocom.h"

const byte identifyRequest = '?';
const char* identifyResponse = "duinocom";

bool verboseCom = true;

bool isMsgReady = false;
int msgPosition = 0;
byte msgBuffer[MAX_MSG_LENGTH];
int msgLength = 0;

// Check whether a message is available and add it to the 'msgBuffer' buffer
bool checkMsgReady()
{
  if (Serial.available() > 0) {
    if (verboseCom)
    {
      Serial.println("Reading serial...");
    }
    byte b = Serial.read();

    //if (!isMsgReady)
    //{
      // The end of a message
      if ((b == ';'
        || b == '\n'
        || b == '\r')
        && msgPosition > 0
        )
      {
        if (verboseCom)
        {
          Serial.print("In:");
          if (b == '\n'
            || b == '\r')
            Serial.println("[newline]");
          else
            Serial.println(char(b));
        }

        msgBuffer[msgPosition] = '\0';
        isMsgReady = true;
        msgPosition = 0;

        if (verboseCom)
        {
          Serial.println("Message ready");

          Serial.print("Length:");
          Serial.println(msgLength);
        }
      }
      else if (byte(b) == '\n' // New line
        || byte(b) == '\r') // Carriage return
      {
        //isMsgReady = false;
        //msgPosition = 0;
        if (verboseCom)
          Serial.println("newline");
      }
      else
      {
        if (msgPosition == 0)
          clearMsg(msgBuffer);
        msgBuffer[msgPosition] = b;
        msgLength = msgPosition+1;
        msgPosition++;
        isMsgReady = false;

        if (verboseCom)
        {
          Serial.print("In:");
          Serial.println(char(b));
        }
      }
    //}
    delay(15);
  }

  if (msgBuffer[0] == identifyRequest)
  {
    identify();

    clearMsg(msgBuffer);
  }

  return isMsgReady;
}

// Get the message from the 'msgBuffer' buffer
byte* getMsg()
{
  // Reset the isMsgReady flag until a new message is received
  isMsgReady = false;

  byte output[MAX_MSG_LENGTH];
  for (int i = 0; i < MAX_MSG_LENGTH; i++)
  {
    byte c = msgBuffer[i];
    output[i] = c;
  }

  if (verboseCom)
   printMsg(output);

 // clearMsg(msgBuffer);

  return msgBuffer;
}

void printMsg(byte msg[MAX_MSG_LENGTH])
{
  if (msgLength > 0)
  {
    Serial.print("Message:");
    for (int i = 0; i < MAX_MSG_LENGTH; i++)
    {
      if (msg[i] != '\0')
        Serial.print(char(msg[i]));
    }
    Serial.println();
  }
}

void clearMsg(byte msgBuffer[MAX_MSG_LENGTH])
{
  for (int i = 0; i < 10; i++)
  {
    msgBuffer[i] = '\0';
  }
}

void identify()
{
  Serial.println(identifyResponse);
}

int readInt2(char byte1, char byte2)
{
  char buffer[2];
  buffer[0] = byte1;
  buffer[1] = byte2;
  int number = atoi(buffer);

  return number;
}

int readInt3(char byte1, char byte2, char byte3)
{
  char buffer[3];
  buffer[0] = byte1;
  buffer[1] = byte2;
  buffer[2] = byte3;
  int number = atoi(buffer);

  return number;
}
