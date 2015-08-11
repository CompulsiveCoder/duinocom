#ifndef duinocom_H_
#define duinocom_H_

void duinocomSetup();

void duinocomLoop();

void getCmd(byte cmd[10]);

void runCmd(byte cmd[10]);

void printCmd(byte cmd[10]);

void clearCmd(byte cmd[10]);

void identify();

#endif
