#include "Arduino.h"
#include "duinocom.h"

const char identifyRequest = 'I';
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
      if (verboseCom)
        Serial.println("[newline]");
    }
    else // Message bytes
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

    // If an id request is received then respond
    if (isMsgReady)
    {
      char firstCharacter = char(msgBuffer[0]);
      Serial.println(char(firstCharacter));

      if (firstCharacter == identifyRequest)
      {
        identify();

        isMsgReady = false;

        clearMsg(msgBuffer);
      }
    }

    delay(15);
  }

  return isMsgReady;
}

// Get the message from the 'msgBuffer' buffer
byte* getMsg()
{
  // Reset the isMsgReady flag until a new message is received
  isMsgReady = false;

  if (verboseCom)
   printMsg(msgBuffer);

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
