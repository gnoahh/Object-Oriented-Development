/* Hoang Do
 * quirkyGuard.cs
 * 05/04/2021
 * This is a child class of the Guard class. 
 * 
 * Interface invariants: the passed in x needs to be smaller or equal to the size
 * of the encapsulated array character. If its larger, x will become the length
 * of the array
 * 
 * 
 * Class invariants:
 * the value call will return all the characters (in uppercase if in up mode
 * and lower case if in down mode) execept the Kth ones. 
 * 
 * Client can switch mode indefinitely
 */

using System;
namespace P5
{
    public class skipGuard:Guard
    {
        public skipGuard(char[] input):base(input)
        {}

        public override char[] value(int k)
        {
           
            int newSize = encapCharacters.Length / k;
            char[] retVal = new char[encapCharacters.Length - newSize];
            int retIndex = 0;
            for(int i = 0; i < encapCharacters.Length; i++)
            {
                if((i + 1) % k != 0)
                {
                    if (upMode)
                    {
                        retVal[retIndex] = char.ToUpper(encapCharacters[i]);
                    }
                    else
                    {
                        retVal[retIndex] = char.ToLower(encapCharacters[i]);
                    }
                    retIndex++;
                }
            }
            return retVal;
        }

        public override void modeSwitch()
        {
            base.modeSwitch();
        }
    }
}

/*
 * Implementation invariants:
 * The size of the returned character array will be equal to the size of the array 
 * substract how many Kth index characters there are
 * 
 * 
 */