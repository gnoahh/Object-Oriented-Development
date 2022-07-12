/* Hoang Do
 * P3.cs
 * 05/04/2021
 * Driver class to test the dataLine, dataMirror and dataInsert objects
 * This class will call 4 other methods (createObject, testdataLine, testdataMirror, testdataInsert) to conduct testing 
 * 
 * 
 */
using System;

namespace Project3
{
    class Program
    {
        private const int NUM_TEST = 3;
        private const int TYPE = 3;
        private const int INVALID = -1;
        private const int MAX_SIZE = NUM_TEST * TYPE;
        private const int RANDOM_CAP = 10;
        private const int RANCOM_MAX = 200;
        private const int RANDOM_MIN = 1;
        public static void Main(string[] args)
        {

            Random rand = new Random();
            dataLine[] arrObj = new dataLine[MAX_SIZE];
            createObjects(rand, arrObj);

            Console.WriteLine(">>>Test dataLine objects: ");
            testDataline(arrObj);
            Console.WriteLine();

            Console.WriteLine(">>>Test dataMirror objects: ");
            testDataMirror(arrObj);
            Console.WriteLine();

            Console.WriteLine(">>>Test dataInsert objects: ");
            testDataInsert(arrObj);
            Console.WriteLine();


            
           
        }
        //Create a heterogenous collection
        private static void createObjects(Random rand, dataLine[] arrObj)
        {
            int[] tempArr;
            for(int i = 0; i < NUM_TEST; i++)
            {
                tempArr = new int[rand.Next(RANDOM_CAP)];
                for(int j = 0; j < tempArr.Length; j++)
                {
                    tempArr[j] = rand.Next(RANDOM_MIN, RANCOM_MAX); 
                }
                arrObj[i] = new dataLine(tempArr);
            }

            for (int i = NUM_TEST; i < NUM_TEST * 2; i++)
            {
                tempArr = new int[rand.Next(RANDOM_CAP)];
                for (int j = 0; j < tempArr.Length; j++)
                {
                    tempArr[j] = rand.Next(RANDOM_MIN, RANCOM_MAX);
                }
                arrObj[i] = new dataMirror(tempArr);
            }

            for (int i = NUM_TEST * 2; i < MAX_SIZE; i++)
            {
                tempArr = new int[rand.Next(RANDOM_CAP)];
                for (int j = 0; j < tempArr.Length; j++)
                {
                    tempArr[j] = rand.Next(RANDOM_MIN, RANCOM_MAX);
                }
                arrObj[i] = new dataInsert(tempArr);
            }

            


        }

        //test dataLine objects
        private static void testDataline(dataLine[] arrObj)
        {
            int[] tempArr;
            for(int i = 0; i < NUM_TEST; i++)
            {
                tempArr = arrObj[i].retrieve(NUM_TEST);
                foreach(int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Passing in invalide y now: ");
            for (int i = 0; i < NUM_TEST; i++)
            {
                tempArr = arrObj[i].retrieve(INVALID);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Attempt to retrieve inactive objects: ");
            for (int i = 0; i < NUM_TEST; i++)
            {
                tempArr = arrObj[i].retrieve(NUM_TEST);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("After resetting Dataline objects: ");
            for (int i = 0; i < NUM_TEST; i++)
            {
                arrObj[i].reset();
                tempArr = arrObj[i].retrieve(NUM_TEST);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Test query method in dataLine objects: ");
            int placeHolder; 
            for (int i = 0; i < NUM_TEST; i++)
            {
                placeHolder = arrObj[i].getElement();
                if (arrObj[i].query(placeHolder))
                {
                    Console.WriteLine(placeHolder + " exists in the encapsulated array!");
                }
                else
                {
                    Console.WriteLine(placeHolder + " doesn't exist in the encapsulated array!");
                }
            }

        }

        //Test dataMirror objects
        private static void testDataMirror(dataLine[] arrObj)
        {
            int[] tempArr;

            for (int i = NUM_TEST; i < NUM_TEST*2; i++)
            {
                tempArr = arrObj[i].retrieve(NUM_TEST);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Test passing in invalid y to dataMirror objects: ");
            for (int i = NUM_TEST; i < NUM_TEST * 2; i++)
            {
                tempArr = arrObj[i].retrieve(INVALID);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Attempt to retrieve inactive dataMirror objects: ");
            for (int i = NUM_TEST; i < NUM_TEST * 2; i++)
            {
                tempArr = arrObj[i].retrieve(INVALID);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("After resetting dataMirror objects: ");
            for (int i = NUM_TEST; i < NUM_TEST * 2; i++)
            {
                arrObj[i].reset();
                tempArr = arrObj[i].retrieve(NUM_TEST);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Attempting to make the first object permanently deactivated: ");
            for (int i = NUM_TEST; i < NUM_TEST * 2; i++)
            {
                tempArr = arrObj[i].retrieve(INVALID);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("The first object is now permanently deactivated: ");
            for (int i = NUM_TEST; i < NUM_TEST * 2; i++)
            {
                arrObj[i].reset();
                tempArr = arrObj[i].retrieve(NUM_TEST);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Attempt to call query method on a permanently dead object: ");
            int placeHolder = arrObj[NUM_TEST].getElement();
            if (arrObj[NUM_TEST].query(placeHolder))
            {
                Console.WriteLine(placeHolder + " exists in the encapsulated array!");
            }
            else
            {
                Console.WriteLine(placeHolder + " doesn't exist in the encapsulated array!");
            }
            

        }

        //test dataInsert objects
        private static void testDataInsert(dataLine[] arrObj)
        {
            int[] tempArr;

            for (int i = NUM_TEST * 2; i < MAX_SIZE; i++)
            {
                tempArr = arrObj[i].retrieve(NUM_TEST);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Call each dataInsert object again to make the largest number decremented");
            Console.WriteLine("First object to have k replace a: ");
            for (int i = NUM_TEST * 2; i < MAX_SIZE; i++)
            {
                tempArr = arrObj[i].retrieve(NUM_TEST);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Call each dataInsert object again to make the largest number decremented");
            Console.WriteLine("Second object to have k replace a: ");
            for (int i = NUM_TEST * 2; i < MAX_SIZE; i++)
            {
                tempArr = arrObj[i].retrieve(NUM_TEST);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Test passing in invalid y: ");
            for (int i = NUM_TEST * 2; i < MAX_SIZE; i++)
            {
                tempArr = arrObj[i].retrieve(INVALID);
                foreach (int j in tempArr)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Test query method in inactive dataInsert objects:");
            int placeHolder;
            for (int i = NUM_TEST * 2; i < MAX_SIZE; i++)
            {
                placeHolder = arrObj[i].getElement();
                if (arrObj[i].query(placeHolder))
                {
                    Console.WriteLine(placeHolder + " exists in the encapsulated array!");
                }
                else
                {
                    Console.WriteLine(placeHolder + " doesn't exist in the encapsulated array!");
                }
            }



        }


    }
}
