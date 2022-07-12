/* Hoang Do
 * quirkyGuard.cs
 * 06/04/2021
 * This is a child class of the Guard class. 
 * 
 * Interface invariants: the passed in x needs to be smaller or equal to the size
 * of the encapsulated array character. If its larger, x will become the length
 * of the array
 * 
 * Class invariants:
 * mixedEncapChar is the new encapsulated array that will be utilized to return 
 * x elements from the value call
 * the quirkyGuard object is intially in up mode
 * each quirkyGuard object has a different bound
 * 
 */

using System;
namespace P5
{
    public class quirkyGuard:Guard
    {
        protected char[] mixedEncapChar;
        protected static int objCount = 0;
        protected int switchBound;
        protected int switchCount = 0;
        public quirkyGuard(char[] input):base(input)
        {
            objCount++;
            switchBound = objCount;
            mixedEncapChar = new char[encapCharacters.Length];
            for(int i = 0; i < encapCharacters.Length; i++)
            {
                if(i%2 == 0)
                {
                    mixedEncapChar[i] = char.ToUpper(encapCharacters[i]);
                }
                else
                {
                    mixedEncapChar[i] = char.ToLower(encapCharacters[i]);
                }
            }
        }

        public override char[] value(int x)
        {
            int valueSize;
            if(x > encapCharacters.Length)
            {
                valueSize = mixedEncapChar.Length;
            }
            else
            {
                valueSize = x;
            }
            int concatSize = valueSize - 1;
            char[] retVal = new char[x + concatSize];
            int index = 0;

            for (int i = 0; i < valueSize; i++)
            {

                retVal[index] = mixedEncapChar[i];
                if (index != x + concatSize - 1)
                    if(upMode)
                        retVal[index + 1] = '+';
                    else
                        retVal[index + 1] = '/';
                index += 2;

            }
            return retVal;
        }

        public override void modeSwitch()
        {
            if(switchCount < switchBound)
            {
                switchCount++;
                base.modeSwitch();
            }

        }
    }
}

/*
 * Implementation invariants:
 * 
 * The bound varies based on how many quirkyGuard objects there are. Each of the
 * object created will increment the bound for the next object by one.
 * 
 * mixedEncapChar will mix up the case of all the characters in the array. Even index 
 * character will be uppercase and odd index character will be lowercase.
 * 
 * The concatenation will do + or / if up or down. It 
 * 
 */