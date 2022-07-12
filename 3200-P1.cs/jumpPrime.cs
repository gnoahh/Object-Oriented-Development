using System;
namespace jumpPrime.cs
{
    public class jumpPrime
    {
        private int encapNum;
        private bool ifActive;
        private bool ifDeactivated;
        private const int firstPrime = 1009;
        private int originalNum;
        private int queryCount;
        public jumpPrime()
        {
            originalNum = encapNum = firstPrime;
            ifActive = true;
            ifDeactivated = false;
            queryCount = 0;
        }
        public jumpPrime(int num)
        {
            originalNum = encapNum = num;
            ifActive = true;
            ifDeactivated = false;
            queryCount = 0;
        }
        public int getKey()
        {
            return encapNum;
        }
        public int up()
        {
            return nextPrime(encapNum);
        }

       
        public int down()
        {
            return precedingPrime(encapNum);
        }

        public bool isActive()
        {
            return ifActive;
        }

        public bool isDeactivated()
        {
            return ifDeactivated;
        }
        public void deactivate()
        {
            ifDeactivated = false;
        }

        public void reset()
        {
            encapNum = originalNum;
        }

        public void jump(int num)
        {
            encapNum = num;
        }
        private int nextPrime(int num)
        {
            int primeNum = num;
            bool foundPrime = false;

            while (!foundPrime)
            {
                primeNum++;

                if (isPrime(primeNum))
                    foundPrime = true;
            }

            return primeNum;
        }

        private int precedingPrime(int num)
        {
             
            int prePrime = num;
            bool foundPrime = false;

            
            while(!foundPrime)
            {
                prePrime--;

                if (isPrime(prePrime))
                    foundPrime = true;
            }

            return prePrime;
        }

        private static bool isPrime(int num)
        {
            if (num % 2 == 0 || num % 3 == 0)
            {
                return false;
            }

            for (int i = 3; i * i <= num; i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;

        }
    }
}
