using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NumJum2.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumJum2.Tests
{
    [TestClass]
    public class JumbledNumberTest
    {
        [TestMethod]
        ///Test method to increment number of correct 
        ///digits
        ///
        public void TestIncNumberCorrect()
        {
            int TestNumDigits = 4;
            long TestJNumberValue = 1234;
            int TestExpIncVal = 2;
            JumbledNumber TestNumJum = new JumbledNumber(TestNumDigits, TestJNumberValue);

            TestNumJum.IncNumberCorrect();                      // Increment to 1
            TestNumJum.IncNumberCorrect();                      // Increment to 2

            Assert.AreEqual(TestExpIncVal, TestNumJum.NumCorrect);
        }

        [TestMethod]
        ///Test method to test increment the number
        ///of guesses
        ///
        public void TestIncNumberGuesses()
        {
            int TestNumDigits = 4;
            long TestJNumberValue = 5678;
            int TestGuessNum = 3;
            JumbledNumber TestNumJum = new JumbledNumber(TestNumDigits, TestJNumberValue);

            // Add 3 guesses
            TestNumJum.IncNumberGuesses();
            TestNumJum.IncNumberGuesses();
            TestNumJum.IncNumberGuesses();

            Assert.AreEqual(TestGuessNum, TestNumJum.NumGuesses);
        }
    }
}
