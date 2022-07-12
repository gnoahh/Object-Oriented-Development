/*
 * Hoang Do
 * dubPrime.cpp
 * Date: 04/22/2021
 * Interface Invariants:
 * query(x) method:
 *      //Public utility method that allows the client to get a pr
        //Pre-condition: gives a positive integer
        //if it's passed in a negative number then will take the absolute value of it
        //if p is 0, then p is assigned to be 1
        //Post-condition: returns preceding prime number if in down mode and succeeing prime number if in up mode

 *
 * Class Invariants:
 * This class only supports copy constructor. No copy assignment or move semantics are supported (these are set private
 * to limit the use)
 *
 * Parameterized constructor
//Pre-conditions: passed in number needs to be at least 2 digit long and a prime number
//If not the encapsulated number will be set to a default number
 *
 *
 *
 */

#include "dubPrime.h"
#include <cstdlib>
using namespace std;
int dubPrime::objCount = 0;

dubPrime::dubPrime(int num){
    if(num/LIMIT < 1)
        encapNum = DEFAULT_NUM;
    if(isPrime(num))
        encapNum = num;
    else{
        encapNum = num;
        while(!isPrime(encapNum)){
            encapNum++;
    }
        }
    objCount++;
    bound = objCount/10;
    upMode = true;
    queryCount = 0;
    deactivated = false;
}
int dubPrime::getBound() {
    return bound;
}

//Copy constructor that copies over all the data members
//Pre-conditions: the passed in object needs to be initialized
dubPrime::dubPrime(dubPrime & rhs){
    encapNum = rhs.encapNum;
    upMode = rhs.upMode;
    queryCount = rhs.queryCount;
    deactivated = rhs.deactivated;
}


int dubPrime::query(int p){
    int tempVal;

    if(p < 0){  //if negative then take the absolute value
        p = abs(p);
    }
    if(p == 0){ //if 0, assign to 1
        p = 1;
    }

    if(!deactivated){
        if(upMode){
            tempVal = p + encapNum;
            while(!isPrime(tempVal))
                tempVal++;
        }
        else{
            tempVal = encapNum - p;
            while(!isPrime(tempVal))
                tempVal--;
            if(tempVal < 10)
                deactivated = true;
        }
        updateMode();
    }
    else{
        return ERROR;
    }
    return tempVal;
}
//Helper method to update the query count and to toggle the mode accordingly when ever reaches bounds
void dubPrime::updateMode() {
    queryCount++;
    if(queryCount >= bound){
        upMode = !upMode;
    }
}
int dubPrime::getQueryCount(){
    return queryCount;
}

bool dubPrime::getMode(){
    return upMode;
}

bool dubPrime::isPermanentlyDeactivated(){
    return deactivated;
}

//Reset method to help resets the object to upMode and its queryCount to 0
void dubPrime::reset(){
    upMode = true;
    queryCount = 0;
}

//Revive method to help revive the object
void dubPrime::revive(){
    if(deactivated)
        deactivated = false;
}
bool dubPrime::isPrime(int num) {
    if(num % 2 == 0 || num % 3 == 0)
        return false;

    for(int i = 3; i * i <= num; i +=2){
        if(num % i == 0)
            return false;
    }

    return true;
}

/* Implementation invariants:
 * query method returns succeeding prime number if object is in up mode and preceding prime number if in down mode
 * if the preceding prime number is not a two digit long number or a negative number, the object will be permanently deactivated.
 * The client will only get -1 if attempting to query a permanently deactivated object
 * reset method resets the mode to up mode and make the query count go to 0
 * revive method activates the object by making the deactivated to false so the program will work properly
 *
 *
 *
 */
