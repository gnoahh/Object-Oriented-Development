/*
 * Hoang Do
 * dubPrime.h
 * Date: 05/20/2021
 * Description: header file for dubPrime.cpp
 */

#ifndef P2_DUBPRIME_H
#define P2_DUBPRIME_H

const int DEFAULT_NUM = 107;
const int INCREMENT = 1;
const int LIMIT = 100;
const int ERROR = -1;

class dubPrime {
    static int objCount;
    int bound, queryCount, encapNum;
    bool upMode, deactivated;
    void copy(const dubPrime&);
    int encapUpdate(const int);
public:
    dubPrime(int num = DEFAULT_NUM);
    dubPrime(const dubPrime & rhs);
    dubPrime& operator=(const dubPrime&);
    dubPrime operator+(const dubPrime&);
    dubPrime& operator+=(const dubPrime&);

    bool operator<(const dubPrime&)const;
    bool operator>(const dubPrime&)const;
    bool operator==(const dubPrime&)const;
    bool operator!=(const dubPrime&)const;
    bool operator<=(const dubPrime&)const;
    bool operator>=(const dubPrime&)const;

    bool operator<(const int)const;
    bool operator>(const int)const;
    bool operator==(const int)const;
    bool operator!=(const int)const;
    bool operator<=(const int)const;
    bool operator>=(const int)const;

    dubPrime operator++(int);
    dubPrime operator++();
    dubPrime operator+(int);
    dubPrime& operator+=(int);
    bool isPermanentlyDeactivated();
    int query(int);
    void updateMode();
    void reset();
    void revive();
    bool isPrime(int);
    bool getMode();

};

bool operator<(const int num, const dubPrime& rhs);
bool operator<=(const int num , const dubPrime& rhs) ;
bool operator>=(const int num, const dubPrime& rhs);
bool operator>(const int num, const dubPrime& rhs);
bool operator==(const int num, const dubPrime& rhs);
bool operator!=(const int num, const dubPrime& rhs);

dubPrime operator+(const int num, dubPrime& rhs);

#endif //P2_DUBPRIME_H
