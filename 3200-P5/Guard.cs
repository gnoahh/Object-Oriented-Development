/* Hoang Do
 * quirkyGuard.cs
 * 06/04/2021
 * This is a child class of the Guard class. 
 * 
 * Interface invariants: the passed in x needs to be smaller or equal to the size
 * of the encapsulated array character. If its larger, x will become the length
 * of the array
 * 
 * constructor injection checks if the passed char array is empty. Also checks if
 * there are any punctuation marks.
 * 
 * Punctuation marks are defined as ! ( ) : " ? ; . ,
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


    public class Guard
    {
        protected char[] encapCharacters;
        protected char[] DEFAULT = { 'h', 'o', 'a', 'n', 'g', '?', '!' };
        protected bool upMode = true;

        public Guard(char[] input)
        {
            if (input.Length == 0)
            {
                encapCharacters = DEFAULT;
            }
            else if (!hasPunctuation(input))
            {
                string punctuations = "!():\"?;.,";
                //char.IsPunctuation
                int randomMark = input.Length;
                while(randomMark >= 10)
                {
                    randomMark /= 10;
                }

                
                encapCharacters = new char[input.Length + 1];
                encapCharacters[0] = punctuations[randomMark - 1];
                for (int i = 0; i < input.Length; i++)
                {
                    encapCharacters[i + 1] = input[i];
                }

            }
            else
            {
                encapCharacters = removeDuplicateChar(input);
            }

        }

        protected bool hasPunctuation(char[] input)
        {
            string punctuations = "!():\"?;.,";
            foreach (char ch in input)
            {
                foreach (char punc in punctuations)
                {
                    if (ch == punc)
                        return true;
                }
            }
            return false;
        }

        protected char[] removeDuplicateChar(char[] input)
        {
            string tempStr = new string(input);
            string table = "";
            string result = "";

            foreach (char ch in tempStr)
            {
                if (table.IndexOf(ch) == -1)
                {
                    table += ch;
                    result += ch;
                }

            }

            char[] retVal = result.ToCharArray();
            return retVal;

        }
        public virtual char[] value(int x)
        {
            int valueSize;
            if (x > encapCharacters.Length || x < 0)
            {
                valueSize = encapCharacters.Length;
            }
            else
            {
                valueSize = x;
            }
            char[] tempStr = new char[x];

            for (int i = 0; i < valueSize; i++)
            {
                if (upMode)
                    tempStr[i] = char.ToUpper(encapCharacters[i]);
                else
                    tempStr[i] = char.ToLower(encapCharacters[i]);
            }

            return tempStr;
        }

        public virtual void modeSwitch()
        {
            upMode = !upMode;
        }
    }
}

/*
 * Implementation Invariants:
 * 
 * If the client passes in a null char array. A default char array will be encapsulated.
 * 
 * if the passed char array does not have any punctuation marks, a random (1 - 10) punctuation mark
 * will be added to the front of the array. The randomness is dependable on the first 
 * digit of the char array size 
 * 
 * If there are duplicate characters in the array, they will be all removed by the helper method
 * removeDuplicates.
 * 
 * Helper method hasPunctuation is to check if there is any punctuation marks in the whole array
 * 
 * 
 * If in up mode, all the characters returned from the call value will be uppercase otherwise lowercase
 * 
 * 
 * 
 * 
 */
