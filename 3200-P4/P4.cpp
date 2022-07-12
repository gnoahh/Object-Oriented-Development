/*
 * Hoang Do
 * P4.cpp
 * Description: Driver to test out clusterP and dubPrime objects
 * Date: 05/20/2021
 */
#include <iostream>
#include "dubPrime.h"
#include "clusterP.h"
#include <ctime>

using namespace std;
const int DEFAULT = 3; //array size
const int TESTNUM = 11; //number to add
const int MIN_BOUND = 100;
const int MAX_BOUND = 1000;

void createDubPrimeObj(dubPrime* arr);
void createClusterPObj(clusterP* arr);
void testPlusDP(dubPrime* arr);
void testPreIncrementDP(dubPrime* arr);
void testPostIncrementDP(dubPrime* arr);
void testPlusDPobjects(dubPrime* arr);
void testPlusDPobjects2(dubPrime* arr);

void testPlusCP(clusterP* arr);
void testPreIncrementCP(clusterP* arr);
void testPostIncrementCP(clusterP* arr);
void testPlusCPobjects(clusterP* arr);
void testPlusCPobjects2(clusterP* arr);
void queryCP(clusterP* arr);
void queryDP(dubPrime* arr);
void add_DP(dubPrime* dubPrimeArray);
void add_CP(clusterP* clusterPArray);
void addDPtoCP(clusterP* clusterPArray, dubPrime* dubPrimeArray);

void ComparisonDP(dubPrime testDP);
void ComparisonCP(clusterP testCP);

int main() {

    dubPrime *dubPrimeArray = new dubPrime [DEFAULT];
    clusterP *clusterPArray = new clusterP[DEFAULT];


    dubPrime testDP;
    clusterP testCP;
    //Test comparisons on individual level
    ComparisonDP(testDP);
    ComparisonCP(testCP);

    createDubPrimeObj(dubPrimeArray);
    createClusterPObj(clusterPArray);


    cout << "Query the current dubPrime objects: " << endl;
    queryDP(dubPrimeArray);
    cout << "**********************" << endl;
    add_DP(dubPrimeArray);



    cout << "Query the current clusterP objects: " << endl;
    queryCP(clusterPArray);
    cout << "**********************" << endl;
    add_CP(clusterPArray);

    cout << "Test adding dubPrime to clusterP:" << endl;
    addDPtoCP(clusterPArray, dubPrimeArray);
    queryCP(clusterPArray);
    cout << "**********************" << endl;

    return 0;
}

void ComparisonDP(dubPrime testDP){
    cout << "Testing dubPrime comparisons: " << endl;
    if(TESTNUM < testDP){
        cout << TESTNUM << " <" << " dubPrime object" << endl;
    }

    if(!(TESTNUM > testDP)){
        cout << TESTNUM << " is not >" << " dubPrime object" << endl;
    }

    if(TESTNUM != testDP){
        cout << TESTNUM << " !=" << " dubPrime object" << endl;
    }
    if(TESTNUM  == testDP){
        cout << TESTNUM << " is not ==" << " dubPrime object" << endl;
    }
    if(TESTNUM <= testDP){
        cout << TESTNUM << " <=" << " dubPrime object" << endl;
    }
    if(!(TESTNUM >= testDP)){
        cout << TESTNUM << " is not >=" << " dubPrime object" << endl;
    }
}
void ComparisonCP(clusterP testCP){
    cout << "Testing clusterP comparisons: " << endl;
    if(DEFAULT < testCP){
        cout << DEFAULT << " <" << " clusterP object" << endl;
    }

    if(!(DEFAULT > testCP)){
        cout << DEFAULT << " is not >" << " clusterP object" << endl;
    }

    if(DEFAULT != testCP){
        cout << DEFAULT << " !=" << " clusterP object" << endl;
    }
    if(DEFAULT  == testCP){
        cout << DEFAULT << " is not ==" << " clusterP object" << endl;
    }
    if(DEFAULT <= testCP){
        cout << DEFAULT << " <=" << " clusterP object" << endl;
    }
    if(!(DEFAULT >= testCP)){
        cout << DEFAULT << " is not >=" << " clusterP object" << endl;
    }
}
void add_DP(dubPrime* dubPrimeArray){
    cout << "Test adding dubPrime objects to an int: " << endl;
    testPlusDP(dubPrimeArray);
    queryDP(dubPrimeArray);
    cout << "**********************" << endl;

    cout << "Test Pre-increment dubPrime objects: " << endl;
    testPreIncrementDP(dubPrimeArray);
    queryDP(dubPrimeArray);
    cout << "**********************" << endl;

    cout << "Test Post-increment dubPrime objects: " << endl;
    testPostIncrementDP(dubPrimeArray);
    queryDP(dubPrimeArray);
    cout << "**********************" << endl;

    cout << "Test adding dubPrime objects together: " << endl;
    testPlusDPobjects(dubPrimeArray);
    queryDP(dubPrimeArray);
    cout << "**********************" << endl;

    cout << "Test adding dubPrime objects together using += : " << endl;
    testPlusDPobjects2(dubPrimeArray);
    queryDP(dubPrimeArray);
    cout << "**********************" << endl;
}

void add_CP(clusterP* clusterPArray){
    cout << "Test adding clusterP objects to an int: " << endl;
    testPlusCP(clusterPArray);
    queryCP(clusterPArray);
    cout << "**********************" << endl;

    cout << "Test Pre-increment dubPrime objects: " << endl;
    testPreIncrementCP(clusterPArray);
    queryCP(clusterPArray);
    cout << "**********************" << endl;

    cout << "Test Post-increment dubPrime objects: " << endl;
    testPostIncrementCP(clusterPArray);
    queryCP(clusterPArray);
    cout << "**********************" << endl;

    cout << "Test adding dubPrime objects together: " << endl;
    testPlusCPobjects(clusterPArray);
    queryCP(clusterPArray);
    cout << "**********************" << endl;

    cout << "Test adding dubPrime objects together using += : " << endl;
    testPlusCPobjects2(clusterPArray);
    queryCP(clusterPArray);
    cout << "**********************" << endl;


}

void addDPtoCP(clusterP* clusterPArray, dubPrime* dubPrimeArray){
    for(int i = 0;  i < DEFAULT; i++){
        clusterPArray[i] = dubPrimeArray[i] + clusterPArray[i];
    }
}

void createClusterPObj(clusterP* arr){
    srand(time(0));
    int randomNum;
    for(int i = 0; i < DEFAULT; i++){
        randomNum = rand() % (TESTNUM - 2) + 1;
        clusterP tempObj(randomNum);
        arr[i] = tempObj;
    }
}
void createDubPrimeObj(dubPrime* arr){
    srand(time(0));
    int randomNum;
    for(int i = 0; i < DEFAULT; i++){
        randomNum = rand() % (MAX_BOUND - MIN_BOUND) + 1;
        dubPrime tempObj(randomNum);
        arr[i] = tempObj;
    }
}

void queryCP(clusterP* arr){
    int *temp;
    for(int i = 0; i < DEFAULT; i++){
        temp = arr[i].query(DEFAULT);
        cout << "Min is: " << temp[0] << endl;
        cout << "Max is: " << temp[1] << endl;
        cout << "Inversion count is: " << temp[2] << endl;
    }


}
void queryDP(dubPrime* arr){
    for(int i = 0; i < DEFAULT; i++){
        cout << arr[i].query(DEFAULT) << " ";
    }
    cout << endl;

}
void testPlusDP(dubPrime* arr){
    for(int i = 0; i < DEFAULT; i++){
        arr[i] = TESTNUM + arr[i];
    }
}


void testPostIncrementDP(dubPrime* arr){
    for(int i = 0; i < DEFAULT; i++){
        arr[i]++;
    }
}
void testPreIncrementDP(dubPrime* arr){
    for(int i = 0; i < DEFAULT; i++){
        ++arr[i];
    }
}

void testPlusDPobjects(dubPrime* arr){
    for(int i = 0; i < DEFAULT; i++){
        arr[i] = arr[i] + arr[i];
    }
}

void testPlusDPobjects2(dubPrime* arr){
    for(int i = 0; i < DEFAULT; i++){
        arr[i] += arr[i];
    }
}

void testPlusCP(clusterP* arr){
    for(int i = 0; i < DEFAULT; i++){
        arr[i] = TESTNUM + arr[i];
    }
}

void testPostIncrementCP(clusterP* arr){
    for(int i = 0; i < DEFAULT; i++){
        arr[i]++;
    }
}
void testPreIncrementCP(clusterP* arr){
    for(int i = 0; i < DEFAULT; i++){
        ++arr[i];
    }
}

void testPlusCPobjects(clusterP* arr){
    for(int i = 0; i < DEFAULT; i++){
        arr[i] = arr[i] + arr[i];
    }
}

void testPlusCPobjects2(clusterP* arr){
    for(int i = 0; i < DEFAULT; i++){
        arr[i] += arr[i];
    }
}


clusterP operator+(const int num, const clusterP& rhs){
    return rhs + num;
}

dubPrime operator+(const int num, dubPrime& rhs){
    return rhs + num;
}
clusterP operator+(const dubPrime& lhs, const clusterP& rhs){
    return rhs + lhs;
}
bool operator<(const int num, const clusterP& rhs){
    return rhs > num;
}

bool operator>(const int num, const clusterP& rhs){
    return rhs < num;
}
bool operator==(const int num, const clusterP& rhs){
    return rhs == num;
}
bool operator!=(const int num, const clusterP& rhs) {
    return rhs != num;
}
bool operator<=(const int num, const clusterP& rhs){
    return rhs >= num;
}
bool operator>=(const int num, const clusterP& rhs){
    return rhs <= num;
}

bool operator<(const int num, const dubPrime& rhs){
    return rhs > num;
}
bool operator>(const int num, const dubPrime& rhs){
    return rhs < num;
}

bool operator<=(const int num, const dubPrime& rhs){
    return rhs >= num;
}
bool operator>=(const int num, const dubPrime& rhs){
    return rhs <= num;
}
bool operator==(const int num, const dubPrime& rhs){
    return rhs == num;
}
bool operator!=(const int num, const dubPrime& rhs){
    return rhs != num;
}