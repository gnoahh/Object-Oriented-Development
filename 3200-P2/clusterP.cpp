/*
 * Hoang Do
 * clusterP.cpp
 * Date: 04/22/2021
 *
 * Interface Invariants:
 * clusterP object can return integers upon calling query(x) method. It does not have any access to the encapsulated
 * data of its dubPrime objects.
 * If query(x) returns negative value => some of the dubPrime objects are permanently dead. It will not be able to return
 * positive values until calling replace
 *
 * Pre-condition for query(x): needs to pass in a non-negative x
 * Class Invariants:
 * Each clusterP object will have different encapsulated size => different number of dubPrime objects
 * clusterP(int num) will act as a default constructor as well if no number passed in
 *
 * For copy constructor, move constructor, copy assignment and move assignment will successfully copy
 * or transfer onwership if the passed object is usuable (no size 0 no nullptr)
 * clusterP(clusterP& rhs)
 * clusterP(clusterP&& rhs)
 * clusterP::operator=(const clusterP& rhs)
 * clusterP::operator=(clusterP&& rhs)
 *
 *
 *
 */

#include "clusterP.h"
#include <ctime>
#include <stdlib.h>
using namespace std;

clusterP::clusterP(int num){
    encapSize = num;
    dubPrimeArr = new dubPrime[encapSize];
    queryCount = 0;
    srand(time(0));
    int randomNum;

    for(int i = 0; i < encapSize; i++){
        randomNum = rand() % (MAX_BOUND - MIN_BOUND) + MIN_BOUND;
        dubPrime obj(randomNum);
        dubPrimeArr[i] = obj;
    }
}

clusterP::clusterP(clusterP& rhs){
    if(rhs.encapSize != 0)
        copy(rhs);
}

//Help revive dead objects
void clusterP::replace(){
    for(int i = 0; i < encapSize; i++){
        if(dubPrimeArr[i].isPermanentlyDeactivated()){
            dubPrimeArr[i].revive();
        }
    }
}

//Move constructor
//Pre-condition: encapSize is not 0 and the object is not null
clusterP::clusterP(clusterP&& rhs){
    if(rhs.encapSize != 0 && rhs.dubPrimeArr != nullptr){
        encapSize = rhs.encapSize;
        dubPrimeArr = rhs.dubPrimeArr;
        rhs.dubPrimeArr = nullptr;
        rhs.encapSize = 0;
    }

}

//Pre-condition: provide a usuable object, not a nullptr or an object that has encapSize = 0
clusterP& clusterP::operator=(const clusterP& rhs){
    if(this != &rhs){
        if(rhs.encapSize != 0 && rhs.dubPrimeArr != nullptr){
            delete [] dubPrimeArr;
            copy(const_cast<clusterP&> (rhs));
        }

    }
    return *this;
}


clusterP& clusterP::operator=(clusterP&& rhs){
    if(this != &rhs && rhs.encapSize != 0 && rhs.dubPrimeArr != nullptr){
        delete[] dubPrimeArr;
        encapSize = rhs.encapSize;
        dubPrimeArr = rhs.dubPrimeArr;

        rhs.encapSize = 0;
        rhs.dubPrimeArr = nullptr;
    }

    return *this;
}

//Destructor
clusterP::~clusterP(){
    delete [] dubPrimeArr;
}

//Copy helper method
void clusterP::copy(clusterP& rhs){
    if(this != & rhs){
        encapSize = rhs.encapSize;
        for(int i = 0; i < encapSize; i++){
            dubPrimeArr[i] = rhs.dubPrimeArr[i];
        }
    }
}

//Pre-condition: x has to be non-negative
int* clusterP::query(int x){
    int tempVal;
    if(x < 0){
        tempVal = abs(x);
    }
    else{
        tempVal = x;
    }
    queryCount++;
    int resultArr[3];
    resultArr[0] = findMin(tempVal);
    resultArr[1] = findMax(tempVal);
    resultArr[2] = inversion(tempVal);

    return resultArr;

}
int clusterP::findMin(int x){
    int minVal = dubPrimeArr[0].query(x);
    int tempVal = 0;
    for(int i = 0; i < encapSize; i++){
        tempVal = dubPrimeArr[i].query(x);
        if(minVal > tempVal){
            minVal = tempVal;
        }
    }
    return minVal;
}
int clusterP::findMax(int x) {
    int maxVal = dubPrimeArr[0].query(x);
    int tempVal = 0;
    for(int i = 0; i < encapSize; i++){
        tempVal = dubPrimeArr[i].query(x);
        if(maxVal < tempVal){
            maxVal = tempVal;
        }
    }
    return maxVal;
}
int clusterP::inversion(int x){
    int inversion = 0;
    int placeHolder1 = 0;
    int placeHolder2 = 0;

    for(int i = 0; i < encapSize - 1; i++){
        placeHolder1 = dubPrimeArr[i].query(x);
        placeHolder2 = dubPrimeArr[i + 1].query(x);

        if(placeHolder1 == placeHolder2 && dubPrimeArr[i].getMode() != dubPrimeArr[i + 1].getMode()){
            inversion++;
        }
    }

    return inversion;
}

bool clusterP::checkDead() {
    for(int i = 0; i < encapSize; i++){
        if(dubPrimeArr[i].isPermanentlyDeactivated())
            return true;
    }
    return false;
}

/*
 * Implementation invariants:
 * Parameterized constructor takes in a number to make that as the size of dubPrimeArr.
 * the constructor uses a random generator to give each dubPrime object different encapsulated numbers.
 *
 * There are copy constructor, copy assignment operator, move constructor and move assignment operator
 * Each one of them will always check for the passed in object to see if the dubPrimeArr pointer is null or the encapSize is 0
 * If so, do nothing
 *
 * Each call to query(x) method will increment the queryCount by 1. X will be passed to query(int p) in the dubPrime class
 * The query(x) method returns an array of size 3. First index is the minimum value, second is the maximum value and third
 * is number of inversions across all objects
 *
 *
 * If any dubPrime objects is dead, user can call the replace method to revive the dead objects
 *
 */