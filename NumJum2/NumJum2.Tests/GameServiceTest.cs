using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumJum2.Domain;
using NumJum2.Services;

namespace NumJum2.Tests
{
    [TestClass]
    public class GameServiceTest
    {
        [TestMethod]
        ///A test of using the factory to add a guess
        ///to the NumJum Object
        ///
        public void AddGuessTest()
        {
            long testGuess = 1234,
                testnumJum = 5678;

            Factory testFactory = Factory.GetInstance();

            JumbledNumber testJumbledNumObj = new JumbledNumber(4, testnumJum);

            IGameSvc testSVC = (IGameSvc)
                testFactory.GetService(typeof(IGameSvc).Name);

            // Create JumbledNumber Object using Factory
            testSVC.AddGuess(testJumbledNumObj, testGuess);


            Assert.AreEqual(testGuess, testJumbledNumObj.CurGuess);
            Assert.AreEqual(1, testJumbledNumObj.NumGuesses);
        }

        [TestMethod]
        ///A test of using the factory to update
        ///the number of correct digits in the
        ///NumJum object
        ///
        public void UpdateNumberCorrectTest()
        {
            int testCorrect,
                testNumDigits = 4;
            long testNumJum = 5678,
                testGuess = 1628;

            Factory testFactory = Factory.GetInstance();
            IGameSvc testSvc = (IGameSvc)
                testFactory.GetService(typeof(IGameSvc).Name);

            JumbledNumber testJumNum = new JumbledNumber(testNumDigits, testNumJum);

            // Add guess to object
            testSvc.AddGuess(testJumNum, testGuess);

            // Use Factory to get number of correct digits
            testCorrect = testSvc.CompareGuessandNumJum(testJumNum);

            // Test
            Assert.AreEqual(2, testCorrect);
        }

        [TestMethod]
        ///A test of using the factory to check
        ///a guess against a NumJum
        ///
        public void CompareGuessandNumJumTest()
        {
            long testGuess1 = 1234,
                testGuess2 = 5612,
                testGuess3 = 5278,
                testnumJum = 5678;

            int testNumCorrect = 0;

            JumbledNumber testJumbledNumObj = new JumbledNumber(4, testnumJum);

            Factory testFactory = Factory.GetInstance();
            IGameSvc testSVC = (IGameSvc)
                testFactory.GetService(typeof(IGameSvc).Name);

            // Update guess with test 1
            testSVC.AddGuess(testJumbledNumObj, testGuess1);

            // Compare values and store number correct
            testNumCorrect = testSVC.CompareGuessandNumJum(testJumbledNumObj);

            // Update number correct
            testSVC.UpdateNumberCorrect(testJumbledNumObj, testNumCorrect);

            // Perform Test
            Assert.AreEqual(0, testNumCorrect);
            Assert.AreEqual(0, testJumbledNumObj.NumCorrect);

            // Update guess with test 2
            testSVC.AddGuess(testJumbledNumObj, testGuess2);

            // Compare values and store number correct
            testNumCorrect = testSVC.CompareGuessandNumJum(testJumbledNumObj);

            // Update number correct
            testSVC.UpdateNumberCorrect(testJumbledNumObj, testNumCorrect);

            // Perform Test
            Assert.AreEqual(2, testNumCorrect);
            Assert.AreEqual(2, testJumbledNumObj.NumCorrect);

            // Update guess with test 3
            testSVC.AddGuess(testJumbledNumObj, testGuess3);

            // Compare values and store number correct
            testNumCorrect = testSVC.CompareGuessandNumJum(testJumbledNumObj);

            // Update number correct
            testSVC.UpdateNumberCorrect(testJumbledNumObj, testNumCorrect);

            // Perform Test
            Assert.AreEqual(3, testNumCorrect);
            Assert.AreEqual(3, testJumbledNumObj.NumCorrect);

            // Final Test
            Assert.AreEqual(3, testJumbledNumObj.NumGuesses);
        }

        [TestMethod]
        ///A test of using the factory to
        ///update the GameInProgresss property
        ///in the NumJum Object
        ///
        public void ChangeGameStatusTest()
        {
            JumbledNumber testJumbledNumber = new JumbledNumber();

            Factory testFactory = Factory.GetInstance();

            IGameSvc testGameSvc =
                (IGameSvc)testFactory.GetService(typeof(IGameSvc).Name);

            testGameSvc.ChangeGameStatus(testJumbledNumber, true);

            Assert.IsTrue(testJumbledNumber.GameInProgress);

            testGameSvc.ChangeGameStatus(testJumbledNumber, false);

            Assert.IsFalse(testJumbledNumber.GameInProgress);

        }
    }
}
