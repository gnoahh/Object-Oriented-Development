using System;
namespace P5
{
    public class P5
    {
        private const int NUM_TEST = 3;
        private const int TYPE = 3;
        private const int INVALID = -1;
        private const int MAX_SIZE = NUM_TEST * TYPE;
        private const int RANDOM_CAP = 10;
        private const int RANCOM_MAX = 200;
        private const int RANDOM_MIN = 1;
        static void Main(string[] args)
        {

            heterogeneousTest(); //test the dataLine hetergeneous collection

            Random rand = new Random();

            int[] intArr = new int[MAX_SIZE];
            for (int i = 0; i < MAX_SIZE; i++)
            {
                intArr[i] = rand.Next(RANDOM_MIN, RANCOM_MAX);
            }
            string holder = "():;\"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!?.";
            char[] charArr = new char[MAX_SIZE];
            for (int i = 0; i < charArr.Length; i++)
            {
                charArr[i] = holder[rand.Next(holder.Length)];
            }

            Console.WriteLine("Start testing the Guard objects: ");
            for(int i = 1; i < 4; i++)
            {
                testGuardObj(charArr, i);
            }
            Console.WriteLine("Start testing the mixed objects: ");
            for(int i = 1; i < 10; i++)
            {
                testMixedObj(intArr, charArr, i);
            }


        }

        public static void testGuardObj(char[] charArr, int modeNum)
        {
            Guard guardObj;
            if(modeNum == 1)
            {
                Console.WriteLine("Test a guard object: ");
                guardObj = new Guard(charArr);
            }
            else if(modeNum == 2)
            {
                Console.WriteLine("Test a skipGuard object: ");
                guardObj = new skipGuard(charArr);
            }
            else
            {
                Console.WriteLine("Test a quirkyGuard object: ");
                guardObj = new quirkyGuard(charArr);
            }
             
            char[] placeHolder = guardObj.value(NUM_TEST * 2);
            foreach(char ch in placeHolder)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("Switch to down mode:");
            guardObj.modeSwitch();
            placeHolder = guardObj.value(NUM_TEST * 2);
            foreach (char ch in placeHolder)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("Switch back to up mode:");
            guardObj.modeSwitch();
            placeHolder = guardObj.value(NUM_TEST * 2);
            foreach (char ch in placeHolder)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine("");

        }


        //public static void 
        public static void testMixedObj(int[] intArr,char[] charArr, int modeNum)
        {
            dataLine dataObj;
            Guard guardObj;
            if(modeNum == 1)
            {
                Console.WriteLine(">>>Test dataMirrorGuard: ");
                dataObj = new dataMirror(intArr);
                guardObj = new Guard(charArr);
            }
            else if(modeNum == 2)
            {
                Console.WriteLine(">>>Test dataMirrorSkipGuard: ");
                dataObj = new dataMirror(intArr);
                guardObj = new skipGuard(charArr);
            }
            else if(modeNum == 3)
            {
                Console.WriteLine(">>>Test dataMirrorQuirkyGuard: ");
                dataObj = new dataMirror(intArr);
                guardObj = new skipGuard(charArr);
            }
            else if(modeNum == 4)
            {
                Console.WriteLine(">>>Test dataInsertGuard: ");
                dataObj = new dataInsert(intArr);
                guardObj = new Guard(charArr);
            }
            else if(modeNum == 5)
            {
                Console.WriteLine(">>>Test dataInsertSkipGuard: ");
                dataObj = new dataInsert(intArr);
                guardObj = new skipGuard(charArr);
            }
            else if(modeNum == 6)
            {
                Console.WriteLine(">>>Test dataInsertQuirkyGuard: ");
                dataObj = new dataInsert(intArr);
                guardObj = new quirkyGuard(charArr);
            }
            else if(modeNum == 7)
            {
                Console.WriteLine(">>>Test dataLineGuard: ");
                dataObj = new dataLine(intArr);
                guardObj = new Guard(charArr);
            }
            else if(modeNum == 8)
            {
                Console.WriteLine(">>>Test dataLineSkipGuard: ");
                dataObj = new dataLine(intArr);
                guardObj = new skipGuard(charArr);
            }
            else
            {
                Console.WriteLine(">>>Test dataLineQuirkyGuard: ");
                dataObj = new dataInsert(intArr);
                guardObj = new quirkyGuard(charArr);
            }

            dataGuard mixedObj = new dataGuard(dataObj, guardObj);
            Console.WriteLine("Query call: ");
            Console.WriteLine(mixedObj.query(mixedObj.getElement()));
            Console.WriteLine("Retrieve call: ");
            int[] tempInt = mixedObj.retrieve(NUM_TEST);
            foreach(int i in tempInt)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("Switch to inactive for data:");
            mixedObj.query(-1);
            tempInt = mixedObj.retrieve(-1);
            foreach (int i in tempInt)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");

            //Test Guard methods:
            char[] placeHolder = mixedObj.value(NUM_TEST * 2);
            mixedObj.reset();
            Console.WriteLine("Reset to active for data:");
            Console.WriteLine(mixedObj.query(NUM_TEST));
            Console.WriteLine("Value call:");
            foreach(char ch in placeHolder)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("Switch to down mode: ");
            mixedObj.modeSwitch();
            placeHolder = mixedObj.value(NUM_TEST * 2);
            foreach (char ch in placeHolder)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("Switch back to up mode: ");
            mixedObj.modeSwitch();
            placeHolder = mixedObj.value(NUM_TEST * 2);
            foreach (char ch in placeHolder)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine("");


        }

        public static void heterogeneousTest() {
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
            for (int i = 0; i < NUM_TEST; i++)
            {
                tempArr = new int[rand.Next(RANDOM_CAP)];
                for (int j = 0; j < tempArr.Length; j++)
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
            for (int i = 0; i < NUM_TEST; i++)
            {
                tempArr = arrObj[i].retrieve(NUM_TEST);
                foreach (int j in tempArr)
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

            for (int i = NUM_TEST; i < NUM_TEST * 2; i++)
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