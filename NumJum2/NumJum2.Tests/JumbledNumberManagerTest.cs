using System;
using System.Text;
using NumJum2.Domain;
using NumJum2.Services;
using NumJum2.Business;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumJum2.Tests
{
 
    [TestClass]
    public class JumbledNumberManagerTest
    {
        [TestMethod]
        ///Test method to test NumJum generation
        ///Generating 3 numbers and sleeping
        ///between each run
        ///
        public void JNMGenerateJumbledNumberTest()
        {
            JumbledNumber testJumbledNumber1 = new JumbledNumber();
            JumbledNumber testJumbledNumber2 = new JumbledNumber();
            JumbledNumber testJumbledNumber3 = new JumbledNumber();

            JumbledNumberManager testJumNumManager = new JumbledNumberManager();
            
            // Create 1st Random Number
            int catchDigits1 = testJumNumManager.CreateJumbledNumber(testJumbledNumber1, 0);
            Thread.Sleep(1000);
            Console.WriteLine("Jumbled Number is: " + testJumbledNumber1.JNumberValue.ToString());
            Console.WriteLine("Stored Number of Digits: " + testJumbledNumber1.NumDigits.ToString());
            Console.WriteLine("Returned Number of Digits: " + catchDigits1.ToString());
            Console.WriteLine("");

            // Create 2nd Random Number
            int catchDigits2 = testJumNumManager.CreateJumbledNumber(testJumbledNumber2, 1);
            Thread.Sleep(1000);
            Console.WriteLine("Jumbled Number is: " + testJumbledNumber2.JNumberValue.ToString());
            Console.WriteLine("Stored Number of Digits: " + testJumbledNumber2.NumDigits.ToString());
            Console.WriteLine("Returned Number of Digits: " + catchDigits2.ToString());
            Console.WriteLine("");

            // Create 3rd Random Number
            int catchDigits3 = testJumNumManager.CreateJumbledNumber(testJumbledNumber3, 2);
            Thread.Sleep(1000);
            Console.WriteLine("Jumbled Number is: " + testJumbledNumber3.JNumberValue.ToString());
            Console.WriteLine("Stored Number of Digits: " + testJumbledNumber3.NumDigits.ToString());
            Console.WriteLine("Returned Number of Digits: " + catchDigits3.ToString());
            Console.WriteLine("");

            Assert.AreEqual(testJumbledNumber1.NumDigits, catchDigits1);
            Assert.AreEqual(testJumbledNumber2.NumDigits, catchDigits2);
            Assert.AreEqual(testJumbledNumber3.NumDigits, catchDigits3);
        }

        [TestMethod]
        /// A test method to test changing the game status  using 
        /// the manager
        /// 
        public void GMCheckGameStatusTest()
        {
            bool test1 = false,
                test2 = true;

            JumbledNumber testJumbledNumber = new JumbledNumber();

            JumbledNumberManager testJumNumManager = new JumbledNumberManager();

            // Set game status and test
            testJumbledNumber.GameInProgress = true;
            test1 = testJumNumManager.CheckGameStatus(testJumbledNumber);
            Assert.IsTrue(test1);
            Assert.IsTrue(testJumbledNumber.GameInProgress);

            testJumbledNumber.GameInProgress = false;
            test2 = testJumNumManager.CheckGameStatus(testJumbledNumber);
            Assert.IsFalse(test2);
            Assert.IsFalse(testJumbledNumber.GameInProgress);
        }
    }
}
