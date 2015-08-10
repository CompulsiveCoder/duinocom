#include "Arduino.h"
#include "duinocom.h" 

void setup()
{
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }
  
  duinocomSetup();
}

void loop()
{
  duinocomLoop();

}




