/* Hoang Do
 * dataMirror.cs
 * 05/04/2021
 * Description: dataMirror class is a child class of the dataLine class. It inherits
 * all the data members and functionality. It encapsulates an array xx. When the number of fail
 * request exceeds the bound, dataMirror object is permanently deactivated
 * 
 * Interface Invariants:
 * the getElement method is only to get the middle element of xx for testing only. 
 * 
 * Class Invariants:
 * 
 * if a passed in array input has a length of 0, then default array will be set to be the encapsulated array
 * if the passed-in y is negative or larger than x size, then return array of -1
 */
using System;
namespace Project3
{
    public class dataMirror : dataLine
    {
        protected static int objCount = 0;
        protected int bound;
        protected int failCount;
        protected int[] xx;
        protected bool permaDead;
        public dataMirror(int[] input):base(input)
        {
            xx = new int[x.Length*2];
            failCount = 0;
            objCount++;
            bound = objCount;
            permaDead = false;
            addReverse();
        }

        //private utility method to add the reverse of x
        private void addReverse()
        {

            for(int i = 0; i < x.Length; i++)
            {
                xx[i] = x[i];
                xx[xx.Length - i - 1] = x[i];
            }

        }

        public override bool query(int y)
        {
            if (permaDead)
            {
                return false;
            }
            else
            {
                if (!active)
                {
                    return false;
                }
                else
                {
                    return base.query(y);
                }

            }
        }
        public override int[] retrieve(int y)
        {

            if (permaDead)
            {
                return new int[SIZE_SINGLE] { -1 };
            }
            else
            {
                if (!active)
                {
                    return new int[SIZE_SINGLE] { -1 };
                }
                else
                {
                    if (y > x.Length || y <= 0)
                    {
                        active = false;
                        failCount++;
                        if (failCount > bound)
                        {
                            permaDead = true;
                        }
                        return new int[SIZE_SINGLE] { -1 };
                    }

                    return getMiddle(y);
                }

            }
                       

            
        }

        private int[] getMiddle(int y)
        {
            int middleIndex = xx.Length / 2 - 1;
            int[] resultArr = new int[y];
            for(int i = 0; i < y; i++)
            {
                resultArr[i] = xx[middleIndex + i];
            }

            return resultArr;
        }


        //return the middle element of xx
        public override int getElement()
        {
            return xx[xx.Length/2];
        }
    }
}


/* Implementation Invariants:
 * dataMirror encapsulates an array xx on top of x from the parent class
 * xx's first half is the same as x and second half is the reverse of x
 * 
 * objCount is to count how many dataMirror object gets created
 * objCount is used to determine the bound of each object
 * each dataMirror object gets created, the bound goes up by 1
 * 
 * beside active bool, dataMirror object has permaDead bool to check if it's permanently
 * deactivated. Client can only reset active bool but not permaDead. Once the object is permanently
 * deactivated, object will only return -1 when called retrieve and false when called 
 * 
 * query method only returns true if the object is still active and not perma deactivated and
 * the passed in y has to exist in xx. Otherwise, always return false
 * 
 * retrieve method will always return -1 if the object is inactive or perma deactivated. 
 * 
 * Client can reset the object to be active. But once object is perma deactivated, it stays that way.
 * 
 * 
 */