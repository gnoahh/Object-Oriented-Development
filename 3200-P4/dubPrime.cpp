/*
 * Hoang Do
 * dubPrime.cpp
 * Date: 05/20/2021
 * Interface Invariants:
 * query(x) method:
 *      //Public utility method that allows the client to get a pr
        //Pre-condition: gives a positive integer
        //if it's passed in a negative number then will take the absolute value of it
        //if p is 0, then p is assigned to be 1
        //Post-condition: returns preceding prime number if in down mode and succeeing prime number if in up mode

 * dubPrime +/+= dubPrime: add the two encapsulated together, bound and queryCount are also added. other data members are as default
 * dubPrime +/+= int: add the integer to the encapsulated number
 *
 * dubPrime++: if in up mode increment til the next prime found, decrement til the preceding prime found if in down mode
 * dubPrime </<=/>=/>/==/!= int: compare the encapsulated number with the integer
 * dubPrime </<=/>=/>/==/!= dubPrime: compare the encapsulated numbers
 *
 * Class Invariants:
 * This class only supports copy constructor. No copy assignment or move semantics are supported (these are set private
 * to limit the use)
 *
 * Parameterized constructor
 * Passed in number needs to be at least 3 digit long and a prime number
 * If not the encapsulated number will be set to a default number
 *
 */

#include "dubPrime.h"
#include <cstdlib>
using namespace std;
int dubPrime::objCount = 0;

dubPrime::dubPrime(int num){
    if(num/LIMIT < 1)
        encapNum = DEFAULT_NUM;
    else{
        if(isPrime(num))
            encapNum = num;
        else{
            encapNum = num;
            while(!isPrime(encapNum)){
                encapNum++;
            }
        }

    }
    objCount++;
    bound = objCount;
    upMode = true;
    queryCount = 0;
    deactivated = false;
}

dubPrime dubPrime::operator+(int num){
    int temp = encapUpdate(num);
    dubPrime local(temp);
    return local;
}

dubPrime dubPrime::operator+(const dubPrime& rhs){
    dubPrime result;
    result.encapNum = encapUpdate(rhs.encapNum);
    result.bound = this->bound + rhs.bound;
    result.queryCount = this->queryCount + rhs.queryCount;
    return result;
}

dubPrime& dubPrime::operator+=(const dubPrime& rhs){
    *this = *this + rhs;
    return *this;
}
dubPrime& dubPrime::operator=(const dubPrime& rhs){
    encapNum = rhs.encapNum;
    upMode = rhs.upMode;
    deactivated = rhs.deactivated;
    return *this;
}

dubPrime& dubPrime::operator+=(const int num){
    *this = *this + num;
    return *this;
}
bool dubPrime::operator<(const dubPrime& rhs)const{
    return encapNum < rhs.encapNum;
}
bool dubPrime::operator>(const dubPrime& rhs)const{
    return encapNum > rhs.encapNum;
}
bool dubPrime::operator==(const dubPrime& rhs)const{
    return encapNum == rhs.encapNum;
}
bool dubPrime::operator!=(const dubPrime& rhs)const{
    return encapNum != rhs.encapNum;
}
bool dubPrime::operator<=(const dubPrime& rhs)const{
    return encapNum <= rhs.encapNum;
}

bool dubPrime::operator>=(const dubPrime& rhs)const{
    return encapNum >= rhs.encapNum;
}

bool dubPrime::operator<(const int num)const{
    return encapNum < num;
}
bool dubPrime::operator>(const int num)const{
    return encapNum > num;
}
bool dubPrime::operator==(const int num)const{
    return encapNum == num;
}
bool dubPrime::operator!=(const int num)const{
    return encapNum != num;
}
bool dubPrime::operator<=(const int num)const{
    return encapNum <= num;
}
bool dubPrime::operator>=(const int num)const{
    return encapNum >= num;
}
dubPrime dubPrime::operator++(){
    encapNum = encapUpdate(INCREMENT);
    return *this;
}

dubPrime dubPrime::operator++(int){
    dubPrime temp;
    temp.copy(*this);
    encapNum = encapUpdate(INCREMENT);
    return temp;
}

int dubPrime::encapUpdate(const int num) {
    int placeHolder = encapNum;
    if(upMode){
        placeHolder += num;
        while(!isPrime(placeHolder)){
            placeHolder++;
        }
    }
    else{
        placeHolder -= num;
        while(!isPrime(placeHolder)){
            placeHolder--;
        }
    }
    if(placeHolder/LIMIT < 1){
        placeHolder = DEFAULT_NUM;
    }
    return placeHolder;
}

void dubPrime::copy(const dubPrime& rhs){
    if(this != &rhs){
        encapNum = rhs.encapNum;
        queryCount = rhs.queryCount;
        bound = rhs.bound;
        upMode = rhs.upMode;
        deactivated = rhs.deactivated;
    }
}

//Copy constructor that copies over all the data members
//Pre-conditions: the passed in object needs to be initialized
dubPrime::dubPrime(const dubPrime & rhs){
    encapNum = rhs.encapNum;
    upMode = rhs.upMode;
    queryCount = rhs.queryCount;
    deactivated = rhs.deactivated;
}


int dubPrime::query(int p){
    int tempVal = 0;

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
        return tempVal;
    }
    else{
        return ERROR;
    }
    return tempVal;
}
//Helper method to update the query count and to toggle the mode accordingly when ever reaches bounds
void dubPrime::updateMode() {
    queryCount++;
    if(queryCount > bound){
        upMode = !upMode;
    }
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

bool dubPrime::getMode() {
    return upMode;
}
/* Implementation invariants:
 *
 * Helper method encapUpdate is meant to check what's the current mode. If it's up, increment til the next prime found. If down
 * decrement til the preceding prime found.
 * whenever addition occurs, the encapsulated number is passed to the helper method to determine the mode before doing any increment/decrement
 *
 * Equality only copies over the encapsulated number, the current mode and if deactivated
 *
 * Helper method updateMode to update the query count and to toggle the mode accordingly when ever reaches bounds
 * query method returns succeeding prime number if object is in up mode and preceding prime number if in down mode
 * if the preceding prime number is not a two digit long number or a negative number, the object will be permanently deactivated.
 * The client will only get -1 if attempting to query a permanently deactivated object
 * reset method resets the mode to up mode and make the query count go to 0
 * revive method activates the object by making the deactivated to false so the program will work properly
 *
 * a private copy method is to help with copying all the data members over. THis is only for internal change
 *
 *
 *
 */
