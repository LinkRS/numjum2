using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumJum2.Domain;
using NumJum2.Services;

namespace NumJum2.Tests
{
    [TestClass]
    public class JumbledNumberServiceTest
    {
        [TestMethod]
        ///A test of using the factory to generate a new
        /// NumJum
        public void GenerateJumbledNumberTest()
        {

            JumbledNumber testJumbledNumber1 = new JumbledNumber();
            JumbledNumber testJumbledNumber2 = new JumbledNumber();
            JumbledNumber testJumbledNumber3 = new JumbledNumber();
            Factory testFactory = Factory.GetInstance();
            IJumbledNumberSvc testSVC = (IJumbledNumberSvc)
                testFactory.GetService(typeof(IJumbledNumberSvc).Name);

            // Create 1st Random Number
            int testdigit1 = testSVC.GetJumbledNumber(testJumbledNumber1, 0);
            Thread.Sleep(1000);
            Console.WriteLine("Jumbled Number is: " + testJumbledNumber1.JNumberValue.ToString());
            Console.WriteLine("Stored Number of Digits: " + testJumbledNumber1.NumDigits.ToString());
            Console.WriteLine("Returned Number of Digits: " + testdigit1.ToString());
            Console.WriteLine("");

            // Create 2nd Random Number
            int testdigits2 = testSVC.GetJumbledNumber(testJumbledNumber2, 1);
            Thread.Sleep(1000);
            Console.WriteLine("Jumbled Number is: " + testJumbledNumber2.JNumberValue.ToString());
            Console.WriteLine("Stored Number of Digits: " + testJumbledNumber2.NumDigits.ToString());
            Console.WriteLine("Returned Number of Digits: " + testdigits2.ToString());
            Console.WriteLine("");

            // Create 3rd Random Number
            int testdigits3 = testSVC.GetJumbledNumber(testJumbledNumber3, 2);
            Thread.Sleep(1000);
            Console.WriteLine("Jumbled Number is: " + testJumbledNumber3.JNumberValue.ToString());
            Console.WriteLine("Stored Number of Digits: " + testJumbledNumber3.NumDigits.ToString());
            Console.WriteLine("Returned Number of Digits: " + testdigits3.ToString());
            Console.WriteLine("");

            Assert.AreEqual(testJumbledNumber1.NumDigits, testdigit1);
            Assert.AreEqual(testJumbledNumber2.NumDigits, testdigits2);
            Assert.AreEqual(testJumbledNumber3.NumDigits, testdigits3);
        }

        [TestMethod]
        /// Test method of using the factory to get the 
        /// status of a game form a JumbledNumber object
        ///
        public void GetGameStatusTest()
        {
            bool test1 = false,
                test2 = true;

            JumbledNumber testJumbledNumber = new JumbledNumber();

            Factory testFactory = Factory.GetInstance();
            IJumbledNumberSvc testSVC = (IJumbledNumberSvc)
                testFactory.GetService(typeof(IJumbledNumberSvc).Name);

            // Set object to test
            testJumbledNumber.GameInProgress = true;
            test1 = testSVC.GetGameStatus(testJumbledNumber);
            Assert.IsTrue(test1);
            Assert.IsTrue(testJumbledNumber.GameInProgress);

            testJumbledNumber.GameInProgress = false;
            test2 = testSVC.GetGameStatus(testJumbledNumber);
            Assert.IsFalse(test2);
            Assert.IsFalse(testJumbledNumber.GameInProgress);

        }
    }
}
