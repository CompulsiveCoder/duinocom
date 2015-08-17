#include "Arduino.h"
#include <duinocom.h>

void setup()
{
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }
  
  Serial.println("Starting duinocom demo");
  Serial.println("Send 'H[pin]' (eg. 'H13') to set a pin high.");
  Serial.println("Send 'L[pin]' (eg. 'L13') to set a pin low.");
}

void loop()
{
  if (checkMsgReady())
  {
    char* msg = getMsg();
    
    for (int i = 0; i < 3; i++)
    {
        Serial.print(msg[i]);
    }
    Serial.println();
    
    char letter = msg[0];

    if (letter != '\0')
    {
      if (letter == byte('H'))
      {
        Serial.println("HIGH");
        turn(HIGH, msg);
      }
      else if (letter == 'L')
      {
        Serial.println("LOW");
        turn(LOW, msg);
      }
      else
      {
        Serial.println("Invalid command");
      }
    }
  }
  delay(100);
}

void turn(bool value, char msg[10])
{
  int pin = readInt2(msg[1], msg[2]);
  
  Serial.println(pin);
  
  digitalWrite(pin, value);
}




