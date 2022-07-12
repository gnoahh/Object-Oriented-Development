/*
 * Hoang Do
 * dubPrime.h
 * Date: 04/22/2021
 * Description: header file for dubPrime.cpp
 */

#ifndef P2_DUBPRIME_H
#define P2_DUBPRIME_H

const int DEFAULT_NUM = 13;
const int LIMIT = 10;
const int ERROR = -1;

class dubPrime {
    static int objCount;
    int bound, queryCount, encapNum;
    bool upMode, deactivated;
public:
    dubPrime(int num = DEFAULT_NUM);
    dubPrime(dubPrime & rhs);
    int getQueryCount();
    bool getMode();
    bool isPermanentlyDeactivated();
    int query(int);
    void updateMode();
    void reset();
    void revive();
    bool isPrime(int);
    int getBound();




};


#endif //P2_DUBPRIME_H
