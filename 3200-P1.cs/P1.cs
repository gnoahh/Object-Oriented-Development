//Henry Do
//9/17/2020
//P1.cs
//Description: This program is a driver to test all the funtionality of the jumpPrime class


using System;

namespace jumpPrime.cs
{
    class P1
    {
        public static void Main()
        {
            Random r = new Random();
            bool checkPrime = false;
            bool isRunning = true;
            int queryCount = 0;
            int bound;
    
            int genRand = r.Next(1000, 9999);
            while (!checkPrime)
            {
                if (isPrime(genRand))
                    checkPrime = true;
                else
                    genRand = r.Next(1000, 9999);
            }
            jumpPrime myObj = new jumpPrime(genRand);
            bound = myObj.up() - myObj.down();


            Console.WriteLine("Welcome in!");
            Console.WriteLine("The encapsulated number is " + genRand);
            Console.WriteLine("The current bound is " + bound);
        
            while(isRunning)
            {
                Console.WriteLine("There are 5 keywords you are allowed to do");
                Console.WriteLine("Enter \"up\" to get the next prime number ");
                Console.WriteLine("Enter \"down\" to get the preceding prime number ");
                Console.WriteLine("Enter \"reset\" to set the prime number to its original value");
                Console.WriteLine("Enter \"revive\" to revive an inactive object");
                Console.WriteLine("Enter \"stop\" to exit");
                Console.WriteLine("What would you like to do ? \n");

                string input = Console.ReadLine();

                if(input == "up")
                {
                    myObj.up();
                    queryCount++;
                    if(queryCheck(bound, queryCount))
                    {
                        myObj.jump(myObj.up());
                        Console.WriteLine("The encapsulated has jumped up to: " + myObj.getKey());
                    }
                    
                }
                else if(input == "down")
                {
                    myObj.down();
                    queryCount++;
                    if (queryCheck(bound, queryCount))
                    {
                        myObj.jump(myObj.down());
                        Console.WriteLine("The encapsulated has jumped down to: " + myObj.getKey());
                    }
                }
                else if(input == "reset")
                {
                    myObj.reset();
                    queryCount = 0;
                }
                else if(input == "revive")
                {
                    if(myObj.isActive())
                    {
                        Console.WriteLine("The object is now permanently deactivated");
                        Console.WriteLine("This is because you attempted to revive an active object!");
                        myObj.deactivate();
                        Console.WriteLine("The program ends now. Good bye!");
                        isRunning = false;
                    }
                    myObj.deactivate();
                }
                else if(input == "stop")
                {
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid command");
                }
                     

            }
        }

        //
        public static bool queryCheck(int bound, int queryCount)
        {
            if (bound == queryCount)
                return true;
            return false;
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

