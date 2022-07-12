/*
 * Hoang Do
 * 06/04/2021
 * dataGuard.cs
 * 
 * This class is a composite of dataLine and Guard objects.
 * Interface Invariants: This class stores two interfaces representing the dataLine and Guard objects
 * It will use these two objects as a has-a relationship - double composition for simplicity and maintainability
 * 
 * Class Invariants:
 * 
 * All the public methods from the dataLine and Guard are echoed
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
namespace P5
{

    public interface iData
    {
        public bool query(int y);
        public int[] retrieve(int y);
        public void reset();
        public int getElement();
    }

    public interface iGuard
    {
        public char[] value(int x);
        public void modeSwitch();

    }

    public class dataGuard : iGuard, iData
    {
        private dataLine data;
        private Guard guard;

        public dataGuard(dataLine dataObj, Guard guardObj)
        {
            if(dataObj != null && guardObj != null)
            {
                data = dataObj;
                guard = guardObj;
            }
            else
            {
                data = new dataLine(null);
                guard = new Guard(null);
            }


        }
        public char[] value(int x)
        {
            return guard.value(x);
        }

        public void modeSwitch()
        {
            guard.modeSwitch();
        }

        public bool query(int y)
        {
            return data.query(y);
        }

        public int[] retrieve(int y)
        {
            return data.retrieve(y);
        }

        public void reset()
        {
            data.reset();
        }

        public int getElement()
        {
            return data.getElement();
        }

    }
}

/*
 * Implementation Invariants:
 * 
 * Whatever passed into the constructor will determine the mixed type.
 * If any of the passed in object is null, both dataLine and Guard objects will be default replacement
 * 
 * 
 */