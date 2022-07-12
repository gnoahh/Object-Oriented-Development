/*
 * Hoang Do
 * clusterP.h
 * Date: 05/20/2021
 * Description: header file for clusterP.cpp
 */

#ifndef P2_CLUSTERP_H
#define P2_CLUSTERP_H

#include "dubPrime.h"

const int DEFAULT_SIZE = 10;

const int MAGNIFIER = 100;

class clusterP {
public:

    explicit clusterP(int size = DEFAULT_SIZE);
    clusterP(dubPrime*, int);
    clusterP(clusterP& rhs);
    clusterP(clusterP && rhs);
    clusterP& operator=(const clusterP& rhs);
    clusterP& operator=(clusterP && rhs);
    clusterP operator+(const clusterP&)const;
    clusterP operator+(const dubPrime&)const;
    clusterP operator+(int)const;

    clusterP& operator+=(int);
    clusterP& operator+=(const clusterP&);
    clusterP& operator+=(const dubPrime&);
    clusterP operator++();
    clusterP operator++(int);


    bool operator<(const clusterP&)const;
    bool operator<=(const clusterP&) const;
    bool operator>=(const clusterP&) const;
    bool operator>(const clusterP&)const;
    bool operator==(const clusterP&)const;
    bool operator!=(const clusterP&)const;

    bool operator<(const int)const;
    bool operator<=(const int) const;
    bool operator>=(const int) const;
    bool operator>(const int)const;
    bool operator==(const int)const;
    bool operator!=(const int)const;



    int* query(int);
    int findMin(int);
    int findMax(int);
    int inversion(int);
    bool checkDead();
    void replace();
    ~clusterP();

private:
    static int objCount;
    dubPrime* dubPrimeArr;
    int encapSize;
    void copy(const clusterP& rhs);
    int queryCount;
};

bool operator<(const int num, const clusterP& rhs);
bool operator<=(const int num , const clusterP& rhs) ;
bool operator>=(const int num, const clusterP& rhs);
bool operator>(const int num, const clusterP& rhs);
bool operator==(const int num, const clusterP& rhs);
bool operator!=(const int num, const clusterP& rhs);

clusterP operator+(const int num, const clusterP& rhs);
clusterP operator+(const dubPrime& lhs, const clusterP& rhs);



#endif //P2_CLUSTERP_H
