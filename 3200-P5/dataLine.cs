/* Hoang Do
 * dataLine.cs
 * 06/04/2021
 * Description: dataLine object encapsulates an array of positive integers
 * It has query(y) method to check if y is in the array
 * has retrieve(y) method to get the first y values
 * 
 * Interface Invariants:
 * Pre-condition for query(y): passed-in y has to be positive
 * Pre-condition for retrieve(y): passed-in y has to be positive and less than array length
 * Both of these methods can make objects inactive if violated
 * 
 * Class Invariants:
 * After the constructor called, active is set to true
 * The encapsulated array will be set to input if input doesn't violate the conditions
 * 
 */

using System;
namespace P5
{


    public class dataLine:iData
    {
        protected const int DEFAULT_SIZE = 5;
        protected const int SIZE_SINGLE = 1;
        protected const int SIZE_MIDDLE = 2;
        protected int[] DEFAULT_ARR = { 3, 44, 7, 56, 2 };
        protected int[] x;
        protected int minimumSize;
        protected bool active = true;

        public dataLine(int[] input)
        {
            if (input.Length == 0)
            {
                x = DEFAULT_ARR;
            }
            else
            {
                if(input.Length < input[0])
                {
                    int newSize = input[0];
                    x = new int[newSize];
                    for(int i = 0; i < newSize && i < input.Length; i++)
                    {
                        x[i] = input[i];

                    }

                    for(int i = input.Length; i < newSize; i++)
                    {
                        x[i] = input[0];
                    }
                }
                else
                {
                    x = input;
                }

            }
        }

        public virtual bool query(int y)
        {
            if (y < 0)
            {
                active = false;
                return false;
            }


            if (!active)
            {
                return false;
            }

            foreach (int i in x)
            {
                if (i == y)
                    return true;
            }
            return false;
        }

        public virtual int[] retrieve(int y)
        {
            if (!active)
            {
                return new int[SIZE_SINGLE] { -1 };
            }

            if (y > x.Length || y < 0)
            {
                active = false;
                return new int[SIZE_SINGLE] { -1 };
            }

            int[] resultArr = new int[y];

            for (int i = 0; i < y; i++)
            {
                resultArr[i] = x[i];

            }

            return resultArr;

        }


        public void reset()
        {
            active = true;
        }

        public virtual int getElement()
        {
            return x[0];
        }

        public void printArr()
        {
            foreach(int num in x)
            {
                Console.Write(num + " ");
            }
        }
    }
}

/* Implementation Invariants:
 * 
 * dataLine uses constructor injection. The passed in array will be checked to see
 * if it's length is 0. If it is, then a default array will be used as the encapsulated 
 * integer array.
 * 
 * When every y is passed in query and retrieve method, both method will check if y 
 * is negative or larger than the length of the encapsulated array. If yes, return an array
 * of length 1 with -1 in it. 
 * 
 * getElement is to get the first element of the encapsulated array so that it can be used
 * in the client to test query method
 * 
 * 
 * 
 * 
 */