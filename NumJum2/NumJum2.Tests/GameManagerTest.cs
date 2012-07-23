using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NumJum2.Domain;
using NumJum2.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumJum2.Tests
{
    [TestClass]
    public class GameManagerTest
    {
        [TestMethod]
        ///Test method to test the initial game setup
        ///
        public void GMStartGameTest()
        {
            string testName = "Link";
            int testDiff = 1,
                testNumdigts = 0;

            Player testPlayer = new Player(testName);

            JumbledNumber testNumJum = new JumbledNumber();

            GameManager testGameManager = new GameManager();

            testNumdigts = testGameManager.StartGame(testNumJum, testDiff);

            Console.WriteLine("Generated Number is: " + testNumJum.JNumberValue.ToString());
            Console.WriteLine("Player Name is: " + testPlayer.PlayerName);
            Console.WriteLine("Game status is: " + testNumJum.GameInProgress.ToString());

            Assert.IsTrue((testNumdigts > 0));
            Assert.IsTrue(testNumJum.GameInProgress);
            
        }

        [TestMethod]
        ///Test method to set NumJum Object
        ///property to indicate game has stopped
        ///
        public void GMStopGameTest()
        {
            JumbledNumber testNumJum = new JumbledNumber();

            GameManager testGameManager = new GameManager();

            testGameManager.StopGame(testNumJum);

            Assert.IsFalse(testNumJum.GameInProgress);

        }

        [TestMethod]
        ///Test method to compare user input guess
        ///against the NumJum stored in the object
        ///
        public void GMCheckGuessTest()
        {
            int testNumDigits = 4;
            long testCurrNumJum = 1234;
            long testCurrGuess = 1111;

            JumbledNumber testNumJum = new JumbledNumber();

            testNumJum.JNumberValue = testCurrNumJum;
            testNumJum.CurGuess = testCurrGuess;
            testNumJum.NumDigits = testNumDigits;

            Console.WriteLine("Stored NumJum " + testNumJum.JNumberValue.ToString());
            Console.WriteLine("Stored Guess " + testNumJum.CurGuess.ToString());

            GameManager testGameManager = new GameManager();

            testGameManager.CheckGuess(testNumJum, testCurrGuess);

            Assert.AreEqual(1, testNumJum.NumCorrect);
        }

        [TestMethod]
        /// Test method to determine if user provied guess
        /// matches the jumbled number
        /// 
        public void GMCheckWinTest()
        {
            int testNumDigits = 4,
                testNumCorrect1 = 4,
                testNumCorrect2 = 3;
            long testCurrNumJum = 1234;
            long testCurrGuess = 1111;
            bool testStatus = false;

            JumbledNumber testNumJum = new JumbledNumber(testNumDigits, testCurrNumJum, testCurrGuess, 0, 0, true);
            Player testPlayer = new Player("Link");

            GameManager testGameManager = new GameManager();

            // Set win condition and test
            testNumJum.NumCorrect = testNumCorrect1;
            
            testStatus = testGameManager.CheckWin(testNumJum, testPlayer);
            Assert.IsTrue(testStatus);

            // Set win condition and test
            testNumJum.NumCorrect = testNumCorrect2;

            testStatus = testGameManager.CheckWin(testNumJum, testPlayer);
            Assert.IsFalse(testStatus);

        }
    }
}
