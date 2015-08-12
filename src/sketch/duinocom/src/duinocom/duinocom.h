#ifndef duinocom_H_
#define duinocom_H_

const int MAX_CMD_LENGTH = 10;

byte* getCmd();

void printCmd(byte cmd[MAX_CMD_LENGTH]);

void clearCmd(byte cmd[MAX_CMD_LENGTH]);

void identify();

int readInt2(char char1, char char2);

#endif
