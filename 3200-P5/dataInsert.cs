/* Hoang Do
 * dataInsert.cs
 * 06/04/2021
 * Description: dataInsert class is a child class of the dataLine class
 * dataInsert object supports functionality of xax
 * upon kth query, k replaces a
 * every query decrements the largest value in xax
 * 
 * Interface Invariants:
 * query only yields true if object is still active. If not, always returns false
 * retrieve only yields a snippet of xax array only if the object is still active.
 * If not, return an array of -1
 * 
 * In the constructor, if the passed-in array has a length of 0, a default array will be
 * used as the encapsulated array
 * 
 * The client can use the reset method (from the parent) to reactivate the object when it's inactive
 * 
 * Class Invariants:
 * dataInsert has its own encapsulated array called xax. It has a length of x * 2 + 1. 
 * static objCount to update whenever new dataInsert created and to determine the bound
 * 
 */

using System;
using System.Collections.Generic;

namespace P5
{
    public class dataInsert : dataLine
    {
        protected int[] xax;
        protected int queryCount;
        protected int bound;
        protected static int objCount = 0;


        public dataInsert(int[] input) : base(input)
        {
            objCount++;
            bound = objCount;
            queryCount = 0;
            xax = new int[x.Length * 2 + 1];
            addInsert();
        }

        //helper method to used in the constructor only
        private void addInsert()
        {
            int accumulator = bound;
            for (int i = 0; i < x.Length; i++)
            {
                accumulator += x[i];

                xax[x.Length] = accumulator;
            }
            for (int i = 0; i < x.Length; i++)
            {
                xax[i] = x[i];
                xax[x.Length + i + 1] = x[i];
            }
        }

        //helper method to help update the query and change a when needed
        private void queryUpdate()
        {
            queryCount++;
            if (queryCount > bound)
            {
                xax[x.Length] = bound;
            }

        }

        public override int[] retrieve(int y)
        {
            queryUpdate();
            updateMax();
            if (!active)
            {
                return new int[SIZE_SINGLE] { -1 };
            }

            if (y > xax.Length || y < 0)
            {
                active = false;
                return new int[SIZE_SINGLE] { -1 };
            }


            return getMiddle(y);
        }

        private int[] getMiddle(int y)
        {
            int middleIndex = xax.Length / 2 - 1;
            int[] resultArr = new int[y];
            for (int i = 0; i < y; i++)
            {
                resultArr[i] = xax[middleIndex + i];
            }

            return resultArr;
        }

        //private utility method to update the maximas
        private void updateMax()
        {
            int max = xax[0];
            List<int> maxList = new List<int>();
            for (int i = 0; i < xax.Length; i++)
            {
                if (max < xax[i])
                {
                    max = xax[i];
                }
            }

            for (int i = 0; i < xax.Length; i++)
            {
                if (max == xax[i])
                {
                    maxList.Add(i);
                }
            }

            foreach (int i in maxList)
            {
                xax[i]--;
            }
        }
        public override bool query(int y)
        {
            queryUpdate();
            updateMax();
            if (y < 0)
            {
                active = false;
                return false;
            }

            if (!active)
            {
                return false;
            }

            return base.query(y);
        }

        public override int getElement()
        {
            return xax[xax.Length / 2];
        }
    }
}

/* Implementation invariants:
 * xax has the length of x * 2 + 1 to account for the second half of x and a
 * 
 * dataInsert object has queryCount to keep tracks of how many times query(y) and
 * retrieve(y) are called. Whenever they are called, the largest element in the xax array
 * will decrement by 1, the queryCount will increase by 1. Once the queryCount is larger 
 * than the object bound, k will replace a
 * 
 * The bound is determined by how many object of dataInsert class there are. 
 * 
 * getElement will return the middle element of xax for client's testing the query method only
 * 
 * 
 * upDateMax is to find the maximum then decrement it. Since there may be more than one max
 * (duplicate numbers), a list is used to capture the indexes of the maximas then decrement. 
 * 
 * a is calculated as the sum of all the elements in x plus the bound
 * a = sum x + bound
 */