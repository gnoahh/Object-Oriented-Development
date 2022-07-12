/*
 * Hoang Do
 * clusterP.h
 * Date: 04/22/2021
 * Description: header file for clusterP.cpp
 */

#ifndef P2_CLUSTERP_H
#define P2_CLUSTERP_H

#include "dubPrime.h"

const int DEFAULT_SIZE = 10;
const int MIN_BOUND = 10;
const int MAX_BOUND = 500;

class clusterP {
public:
    static int objCount;
    explicit clusterP(int size = DEFAULT_SIZE);
    clusterP(clusterP& rhs);
    clusterP(clusterP && rhs);
    clusterP& operator=(const clusterP& rhs);
    clusterP& operator=(clusterP && rhs);
    int* query(int);
    int findMin(int);
    int findMax(int);
    int inversion(int);
    bool checkDead();
    void replace();
    ~clusterP();

private:
    dubPrime* dubPrimeArr;
    int encapSize;
    void copy(clusterP& rhs);
    int queryCount;
};


#endif //P2_CLUSTERP_H
