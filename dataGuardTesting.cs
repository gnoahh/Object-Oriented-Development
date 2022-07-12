using Microsoft.VisualStudio.TestTools.UnitTesting;
using P5;

namespace dataGuardUnitTesting
{
    [TestClass]
    public class dataGuardTesting
    {

        [TestMethod]
        public void TestdataGuard()
        {
            int[] intArr = { 7, 15, 4, 10, 8 };
            char[] charArr = { 'n', '?', 'a', '!', 'h' };
            dataLine dataObj = new dataLine(intArr);
            Guard guardObj = new Guard(charArr);
            dataGuard compositeObj = new dataGuard(dataObj, guardObj);
            char[] temp = compositeObj.value(3);
            char[] test = { 'N', '?', 'A' };
            Assert.IsTrue(temp[0] == test[0]);
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);

            compositeObj.modeSwitch(); //change mode
            temp = compositeObj.value(3);
            Assert.IsTrue(temp[0] == char.ToLower(test[0]));
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == char.ToLower(test[2]));

            int[] tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 15);
            Assert.IsTrue(tempInt[2] == 4);

            compositeObj.query(-1);
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == -1);

            compositeObj.reset();
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 15);
            Assert.IsTrue(tempInt[2] == 4);

        }

        [TestMethod]
        public void TestdataMirrorQuirkyGuard()
        {
            int[] intArr = { 7, 15, 4, 10, 8 };
            char[] charArr = { 'n', '?', 'a', '!', 'h' };
            dataLine dataObj = new dataMirror(intArr);
            Guard guardObj = new skipGuard(charArr);
            dataGuard compositeObj = new dataGuard(dataObj, guardObj);
            char[] temp = compositeObj.value(3);
            char[] test = { 'N', '?', '!', 'H' };
            Assert.IsTrue(temp[0] == test[0]);
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);
            Assert.IsTrue(temp[3] == test[3]);

            compositeObj.modeSwitch(); //change mode
            temp = compositeObj.value(3);
            Assert.IsTrue(temp[0] == char.ToLower(test[0]));
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);
            Assert.IsTrue(temp[3] == char.ToLower(test[3]));

            int[] tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 7);
            Assert.IsTrue(tempInt[2] == 7);

            compositeObj.query(-1);
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == -1);

            compositeObj.reset();
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 7);
            Assert.IsTrue(tempInt[2] == 7);
        }

        [TestMethod]
        public void TestdataQuirkyGuard()
        {
            int[] intArr = { 7, 15, 4, 10, 8 };
            char[] charArr = { 'n', '?', 'a', '!', 'h' };
            dataLine dataObj = new dataMirror(intArr);
            Guard guardObj = new quirkyGuard(charArr);
            dataGuard compositeObj = new dataGuard(dataObj, guardObj);
            char[] temp = compositeObj.value(3);
            char[] test = { 'N', '+', '?', '+', 'A' };
            Assert.IsTrue(temp[0] == test[0]);
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);
            Assert.IsTrue(temp[3] == test[3]);
            Assert.IsTrue(temp[4] == test[4]);

            compositeObj.modeSwitch(); //change mode
            temp = compositeObj.value(3);
            Assert.IsTrue(temp[0] == test[0]);
            Assert.IsTrue(temp[1] == '/');
            Assert.IsTrue(temp[2] == test[2]);
            Assert.IsTrue(temp[3] == '/');
            Assert.IsTrue(temp[4] == test[4]);

            int[] tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 7);
            Assert.IsTrue(tempInt[2] == 7);

            compositeObj.query(-1);
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == -1);

            compositeObj.reset();
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 7);
            Assert.IsTrue(tempInt[2] == 7);
        }
    
        [TestMethod]
        public void TestdataMirrorSkipGuard()
        {
            int[] intArr = { 7, 15, 4, 10, 8 };
            char[] charArr = { 'n', '?', 'a', '!', 'h' };
            dataLine dataObj = new dataMirror(intArr);
            Guard guardObj = new skipGuard(charArr);
            dataGuard compositeObj = new dataGuard(dataObj, guardObj);
            char[] temp = compositeObj.value(3);
            char[] test = { 'N', '?', '!', 'H' };
            Assert.IsTrue(temp[0] == test[0]);
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);
            Assert.IsTrue(temp[3] == test[3]);

            compositeObj.modeSwitch(); //change mode
            temp = compositeObj.value(3);
            Assert.IsTrue(temp[0] == char.ToLower(test[0]));
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);
            Assert.IsTrue(temp[3] == char.ToLower(test[3]));

            int[] tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 7);
            Assert.IsTrue(tempInt[2] == 7);

            compositeObj.query(-1);
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == -1);

            compositeObj.reset();
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 7);
            Assert.IsTrue(tempInt[2] == 7);
        }

        [TestMethod]
        public void TestdataMirrorGuard()
        {
            int[] intArr = { 7, 15, 4, 10, 8 };
            char[] charArr = { 'n', '?', 'a', '!', 'h' };
            dataLine dataObj = new dataMirror(intArr);
            Guard guardObj = new Guard(charArr);
            dataGuard compositeObj = new dataGuard(dataObj, guardObj);
            char[] temp = compositeObj.value(3);
            char[] test = { 'N', '?', 'A' };
            Assert.IsTrue(temp[0] == test[0]);
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);

            compositeObj.modeSwitch(); //change mode
            temp = compositeObj.value(3);
            Assert.IsTrue(temp[0] == char.ToLower(test[0]));
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == char.ToLower(test[2]));

            int[] tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 7);
            Assert.IsTrue(tempInt[2] == 7);

            compositeObj.query(-1);
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == -1);

            compositeObj.reset();
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 7);
            Assert.IsTrue(tempInt[2] == 7);
        }

        
        public void TestdataInsertGuard()
        {
            int[] intArr = { 7, 15, 4, 10, 8 };
            char[] charArr = { 'n', '?', 'a', '!', 'h' };
            dataLine dataObj = new dataInsert(intArr);
            Guard guardObj = new Guard(charArr);
            dataGuard compositeObj = new dataGuard(dataObj, guardObj);
            char[] temp = compositeObj.value(3);
            char[] test = { 'N', '?', 'A' };
            Assert.IsTrue(temp[0] == test[0]);
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);

            compositeObj.modeSwitch(); //change mode
            temp = compositeObj.value(3);
            Assert.IsTrue(temp[0] == char.ToLower(test[0]));
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == char.ToLower(test[2]));

            int[] tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 65);
            Assert.IsTrue(tempInt[2] == 7);

            compositeObj.query(-1);
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == -1);

            compositeObj.reset();
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 65);
            Assert.IsTrue(tempInt[2] == 7);
        }

        
        public void TestdataInsertskipGuard()
        {
            int[] intArr = { 7, 15, 4, 10, 8 };
            char[] charArr = { 'n', '?', 'a', '!', 'h' };
            dataLine dataObj = new dataInsert(intArr);
            Guard guardObj = new skipGuard(charArr);
            dataGuard compositeObj = new dataGuard(dataObj, guardObj);
            char[] temp = compositeObj.value(3);
            char[] test = { 'N', '?','!', 'H' };
            Assert.IsTrue(temp[0] == test[0]);
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);
            Assert.IsTrue(temp[3] == test[3]);

            compositeObj.modeSwitch(); //change mode
            temp = compositeObj.value(3);
            Assert.IsTrue(temp[0] == char.ToLower(test[0]));
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);
            Assert.IsTrue(temp[3] == char.ToLower(test[3]));

            int[] tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 65);
            Assert.IsTrue(tempInt[2] == 7);

            compositeObj.query(-1);
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == -1);

            compositeObj.reset();
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 65);
            Assert.IsTrue(tempInt[2] == 7);
        }

        public void TestdataInsertquirkyGuard()
        {
            int[] intArr = { 7, 15, 4, 10, 8 };
            char[] charArr = { 'n', '?', 'a', '!', 'h' };
            dataLine dataObj = new dataInsert(intArr);
            Guard guardObj = new skipGuard(charArr);
            dataGuard compositeObj = new dataGuard(dataObj, guardObj);
            char[] temp = compositeObj.value(3);
            char[] test = { 'N','+', '?', 'A'};
            Assert.IsTrue(temp[0] == test[0]);
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);
            Assert.IsTrue(temp[3] == test[3]);

            compositeObj.modeSwitch(); //change mode
            temp = compositeObj.value(3);
            Assert.IsTrue(temp[0] == char.ToLower(test[0]));
            Assert.IsTrue(temp[1] == test[1]);
            Assert.IsTrue(temp[2] == test[2]);
            Assert.IsTrue(temp[3] == char.ToLower(test[3]));

            int[] tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 65);
            Assert.IsTrue(tempInt[2] == 7);

            compositeObj.query(-1);
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == -1);

            compositeObj.reset();
            tempInt = compositeObj.retrieve(3);
            Assert.IsTrue(tempInt[0] == 7);
            Assert.IsTrue(tempInt[1] == 65);
            Assert.IsTrue(tempInt[2] == 7);
        }
    }
}
