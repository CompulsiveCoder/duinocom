#ifndef duinocom_H_
#define duinocom_H_

const int MAX_MSG_LENGTH = 10;

bool checkMsgReady();

byte* getMsg();

void printMsg(byte msg[MAX_MSG_LENGTH]);

void clearMsg(byte msg[MAX_MSG_LENGTH]);

void identify();

int readInt2(char byte1, char byte2);

int readInt3(char byte1, char byte2, char byte3);

#endif
