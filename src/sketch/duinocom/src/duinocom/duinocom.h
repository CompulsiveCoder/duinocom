#ifndef duinocom_H_
#define duinocom_H_

const int MAX_MSG_LENGTH = 10;

bool checkMsgReady();

char* getMsg();

void printMsg(byte msg[MAX_MSG_LENGTH]);

void clearMsg(byte msg[MAX_MSG_LENGTH]);

void identify();

int readInt2(char char1, char char2);

#endif
