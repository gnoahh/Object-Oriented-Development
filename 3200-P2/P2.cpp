/* Hoang Do
 * P2.cpp
 * Date: 04/22/2021
 * Description: This is the driver to test the functionalities of clusterP objects
 * It will attempt to use shared pointers and unique pointers as well as use stl vector to
 * work on that
 *
 */

#include <iostream>
#include "clusterP.h"
#include <ctime>
#include <memory>
#include <stdlib.h>
#include <vector>
using namespace std;
void createUniquePtr(vector<unique_ptr<clusterP> > & uniqueVec);
void createSharedPtr(vector<shared_ptr<clusterP> > & sharedVec);
void testQuery(vector<unique_ptr<clusterP> > & uniqueVec, int x);
void testSharedPtr();

const int TEST_RANGE = 10;
const int OBJ_RANGE = 3;
const int LOWER_BOUND = 10;
const int UPPER_BOUND = 200;
int main() {

    //test out functionality of unique pointer objects
//    unique_ptr<clusterP> obj(new clusterP(5));
//    cout << "Min is: " << obj->query(TEST_RANGE)[0] << endl;
//    cout << "Max is: " <<obj->query(TEST_RANGE)[1] << endl;
//    cout << "Number of inversions are: " << obj->query(TEST_RANGE)[2] << endl;

    //Call this method to test shared pointers
    cout << "Testing shared pointers now!" << endl;
    testSharedPtr();



    return 0;
}

void testSharedPtr(){
    srand(time(0));
    int randomGen;
    vector<shared_ptr<clusterP> > sharedVec;
    for (int i = 0; i < OBJ_RANGE; i++) {
        randomGen = rand() % (UPPER_BOUND - LOWER_BOUND + 1) + LOWER_BOUND;
        sharedVec.push_back(make_shared<clusterP>(randomGen));
    }
    int* tempPtr;


    //Print 3 times to change the mode of dubPrime objects in the dubPrimeArr from clusterP objects
    for(int i = 0; i < OBJ_RANGE; i++){
        for (int j = 0; j < OBJ_RANGE; j++) {
            randomGen = rand() % (UPPER_BOUND - LOWER_BOUND + 1) + LOWER_BOUND;
            cout << "Min is: " << sharedVec[j]->query(randomGen)[0] << endl;
            cout << "Max is: " << sharedVec[j]->query(randomGen)[1] << endl;
            cout << "Number of inversions are: " << sharedVec[j]->query(randomGen)[2] << endl;
        }
    }

    //After replacing dead dubPrime objects
    cout << "Replacing now!" << endl;

    for(int i = 0; i < sharedVec.size(); i++){
        sharedVec[i]->replace();
        if(sharedVec[i]->checkDead())
            cout << "Failed to replace!" << endl;
        else
            cout << "Successfully replaced!" << endl;

    }


}

//Those following methods are for testing move semantics but all failed
//void createSharedPtr(vector<unique_ptr<clusterP> >& sharedVec){
//    int randomGen;
//    for(int i = 0; i < OBJ_RANGE; i++){
//        randomGen = rand() % (UPPER_BOUND - LOWER_BOUND + 1) + LOWER_BOUND;
//        unique_ptr<clusterP> shared(new clusterP(randomGen));
//        sharedVec.push_back(move(shared));
//    }
//}
//void testQuery(vector<unique_ptr<clusterP> > & uniqueVec, int x){
//    int* tempPtr;
//    for(int i = 0; i < OBJ_RANGE; i++){
//        tempPtr = uniqueVec[i]->query(x);
//        cout << "Min is: " << tempPtr[0] << "Max is: " << tempPtr[1] << "Number of Collisions are: " << tempPtr[2];
//
//    }
//
//}
//

//void createUniquePtr(vector<unique_ptr<clusterP> >& uniqueVec){
//    int randomGen;
//    for(int i = 0; i < OBJ_RANGE; i++){
//        randomGen = rand() % (UPPER_BOUND - LOWER_BOUND + 1) + LOWER_BOUND;
//        unique_ptr<clusterP> unique = make_unique<clusterP>(15);
//        uniqueVec.push_back(move(unique));
//    }
//}




