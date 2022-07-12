/*
 * Hoang Do
 * clusterP.cpp
 * Date: 05/20/2021
 *
 * Interface Invariants:
 * clusterP object can return integers upon calling query(x) method. It does not have any access to the encapsulated
 * data of its dubPrime objects.
 * If query(x) returns negative value => some of the dubPrime objects are permanently dead. It will not be able to return
 * positive values until calling replace
 *
 * clusterP +/+= clusterP : combine the encapsulated sizes and the arrays together
 * clusterP +/+= dubPrime : add the dubPrime object to the end of dubPrime array in clusterP object
 * clusterP +/+= int : pass the int to a dubPrime object then add it to the end of dubPrime array in clusterP object
 *
 * clusterP </<=/>/>=/==/!= clusterP : compare the sizes between the two objects
 * clusterP </<=/>/>=/==/!= int: compare the size with the int
 *
 * clusterP++:  add a default dubPrime object to the end of dubPrime array in clusterP object
 *
 * Pre-condition for query(x): needs to pass in a non-negative x
 * Class Invariants:
 * Each clusterP object will have different encapsulated size => different number of dubPrime objects
 * clusterP(int num) will act as a default constructor as well if no number passed in
 * clusterP(array, num) constructor allow the client to create clusterP object with a given dubPrime array and its size
 * For copy constructor, move constructor, copy assignment and move assignment will successfully copy
 * or transfer onwership if the passed object is usuable (no size 0 no nullptr)
 *
 * clusterP(clusterP& rhs)
 * clusterP(clusterP&& rhs)
 * clusterP::operator=(const clusterP& rhs)
 * clusterP::operator=(clusterP&& rhs)
 *

 *
 */

#include "clusterP.h"
#include <ctime>
#include <stdlib.h>
#include <iostream>
using namespace std;

clusterP::clusterP(int num){
    encapSize = num;
    dubPrimeArr = new dubPrime[encapSize];
    queryCount = 0;

    for(int i = 0; i < encapSize; i++){
        dubPrime obj(MAGNIFIER + i * encapSize);
        dubPrimeArr[i] = obj;
    }
}
clusterP::clusterP(dubPrime* array, int size){
    encapSize = size;
    dubPrimeArr = array;
    queryCount = 0;
}
clusterP::clusterP( clusterP& rhs){
    if(rhs.encapSize != 0)
        copy(rhs);
}

//Help revive dead objects
void clusterP::replace(){
    for(int i = 0; i < encapSize; i++){
        if(dubPrimeArr[i].isPermanentlyDeactivated() || dubPrimeArr[i].query(1) < 0){
            dubPrime tempObj;
            dubPrimeArr[i] = tempObj;

        }
    }
}

clusterP clusterP::operator+(const clusterP& rhs)const{

    int newSize = encapSize + rhs.encapSize;
    clusterP temp(newSize);
    temp.dubPrimeArr = new dubPrime[newSize];
    for(int i = 0; i < encapSize; i++){
        temp.dubPrimeArr[i] = dubPrimeArr[i];
    }
    for(int i = 0; i < rhs.encapSize; i++){
        temp.dubPrimeArr[encapSize + i] = rhs.dubPrimeArr[i];
    }
    return temp;
}

clusterP clusterP::operator++(){
    *this = *this + 1;
    return *this;
}

clusterP clusterP::operator++(int num){
    clusterP oldState(dubPrimeArr, encapSize);
    *this = *this + 1;
    return oldState;
}
clusterP clusterP::operator+(int num)const{
    int newSize = encapSize + 1;
    dubPrime *tempArr = new dubPrime[newSize];
    int tempNum = num * MAGNIFIER;
    dubPrime tempObj(tempNum);

    for(int i = 0; i < encapSize; i++){
        tempArr[i] = dubPrimeArr[i];
    }
    tempArr[newSize - 1] = tempObj;
    clusterP tempCluster(tempArr, newSize);
    return tempCluster;

}

clusterP clusterP::operator+(const dubPrime& rhs)const{
    int newSize = encapSize + 1;
    dubPrime *tempArr = new dubPrime[newSize];

    for(int i = 0; i < encapSize; i++){
        tempArr[i] = dubPrimeArr[i];
    }

    tempArr[newSize - 1] = rhs;
    clusterP tempCluster(tempArr, newSize);
    return tempCluster;
}
clusterP& clusterP::operator+=(int num){
    *this = *this + 1;
    return *this;
}

clusterP& clusterP::operator+=(const clusterP& rhs){
    clusterP temp;
    temp = rhs;
    *this = *this + temp;
    return *this;
}

clusterP& clusterP::operator+=(const dubPrime& rhs){
    *this = *this + rhs;
    return *this;
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
    if(this == &rhs)
        return *this;
    delete [] dubPrimeArr;
    copy(rhs);
    return *this;
}


clusterP& clusterP::operator=(clusterP&& rhs){
    if(this == &rhs)
        return *this;

    encapSize = rhs.encapSize;
    dubPrimeArr = rhs.dubPrimeArr;

    rhs.encapSize = 0;
    rhs.dubPrimeArr = nullptr;
    return *this;
}

bool clusterP::operator<(const clusterP& rhs)const{
    return encapSize < rhs.encapSize;
}
bool clusterP::operator>(const clusterP& rhs)const{
    return encapSize > rhs.encapSize;
}

bool clusterP::operator==(const clusterP& rhs)const{
    return encapSize == rhs.encapSize;
}
bool clusterP::operator!=(const clusterP& rhs)const{
    return encapSize != rhs.encapSize;
}
bool clusterP::operator<=(const clusterP& rhs)const{
    return encapSize <= rhs.encapSize;
}
bool clusterP::operator>=(const clusterP& rhs)const{
    return encapSize >= rhs.encapSize;
}


bool clusterP::operator<(const int num)const{
    return encapSize < num;
}

bool clusterP::operator>(const int num)const{
    return encapSize > num;
}

bool clusterP::operator==(const int num)const{
    return encapSize == num;
}
bool clusterP::operator!=(const int num)const{
    return encapSize != num;
}

bool clusterP::operator<=(const int num)const{
    return encapSize <= num;
}
bool clusterP::operator>=(const int num)const{
    return encapSize >= num;
}
//Destructor
clusterP::~clusterP(){
    delete [] dubPrimeArr;
}

//Copy helper method
void clusterP::copy(const clusterP& rhs){
    encapSize = rhs.encapSize;
    dubPrimeArr = new dubPrime[encapSize];
    for(int i = 0; i < encapSize; i++){
        dubPrimeArr[i] = rhs.dubPrimeArr[i];
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
    static int resultArr[3];
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
    int placeHolder1;
    int placeHolder2;

    for(int i = 0; i < encapSize - 1; i++){
        for(int j = i + 1; j < encapSize; j++){
            placeHolder1 = dubPrimeArr[i].query(x);
            placeHolder2 = dubPrimeArr[j].query(x);
            if(placeHolder1 == placeHolder2 && dubPrimeArr[i].getMode() != dubPrimeArr[j].getMode()){
                inversion++;
            }
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
 *
 * Each of the encapsulated number of dubPrime objects is determined by encapSize * 100 + i => unique number
 *
 * +=, ++ (pre n post) will utilize the + instead of redoing the same work.
 *
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
 * replace() will check if any of the dubPrime obj in the dubPrimeArr is dead, if so replace with a default dubPrime obj
 * Inversion count is determined by comparing one object query with the rest
 *
 *  * a private copy method is to help with copying all the data members over. THis is only for internal change
 */

