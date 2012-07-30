using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using NumJum2.Domain;
using NumJum2.Services;
using NumJum2.Services.Exceptions;
using NumJum2.Business;
using System.Linq;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumJum2.Tests
{
    [TestClass]
    public class PlayerManagerTest
    {

        [TestMethod]
        ///A test of using the PlayerManager to create a player
        ///
        public void PMCreatePlayerTest()
        {
            // Create file and data for testing
            // Test parameters
            string testName = "Zelda";
            bool testStatus = true;
            int testNumScores = 4;
            Player testPlayer = new Player();
            PlayerManager testManager = new PlayerManager();
            List<int> testScores = new List<int>() { 60, 32, 15, 4};    // Test score ArrayList
            Player newPlayer = new Player(testName, testStatus,
                                        testNumScores, testScores);

            Factory testFactory = Factory.GetInstance();                             
            IPlayerSvc testSVC = (IPlayerSvc)     
                testFactory.GetService(typeof(IPlayerSvc).Name);

            // Create file for test
            try
            {
                testSVC.SavePlayerToDb(newPlayer);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail("Unable to create test file");
            }


            // Create new player using business manager           
            try
            {
                testPlayer = testManager.LoadPlayer(testName);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail("Unable to create player!");
            }

            //Test if player data has been loaded
            Assert.AreEqual(testPlayer.PlayerName, testName);
            Assert.AreEqual(testPlayer.GameStatus, testStatus);
            Assert.AreEqual(testPlayer.NumberOfScores, testNumScores);

            //Test arbitrary list value
            // Sort test array first
            testScores.Sort();
            Assert.AreEqual(testPlayer.ScoreList[1], testScores[1]);
        }


        [TestMethod]
        ///A test of using the PlayerManager to create a player
        ///when the file does not exist
        ///This would create a "new" player
        public void PMCreateNewPlayerTest()
        {
            string fileName = "Tinker";                                     // File name for test that does not exist
            Player testPlayer = new Player();
            PlayerManager testManager = new PlayerManager();

            // Create player object from file
            try
            {
                testPlayer = testManager.LoadPlayer(fileName);
            }
            catch (PlayerNotFoundException)
            {
                Console.WriteLine("Caught Exception in Test");
            }
            finally
            {
                //Test if player is created based on input filename
                //If the exception is caught and handled,  it should
                //Create a new player with the specified name
                Assert.AreEqual(testPlayer.PlayerName, fileName);
            }
        }

        [TestMethod]
        ///A test of using the PlayerManager to save a player
        ///
        public void PMSavePlayerTest()
        {
            // Create player for testing
            // Test parameters
            string testName = "Link";
            bool testStatus = false,
                SaveGood = false;
            int testNumScores = 2;
            PlayerManager testManager;
            List<int> testScores = new List<int>() { 99, 23 };    // Test score ArrayList
            Player newPlayer = new Player(testName, testStatus,
                                        testNumScores, testScores);

            // Try to save Player using Manager
            testManager = new PlayerManager();
            try
            {
                SaveGood = testManager.SavePlayer(newPlayer, testName);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail("Unable to create player object");
            }

            //Test if player was saved to database
            //Create compare player using database
            Player comparePlayer = null;
            comparePlayer = testManager.LoadPlayer(testName);

            Assert.AreEqual(testName, comparePlayer.PlayerName);
            Assert.IsTrue(SaveGood);

        }

        [TestMethod]
        ///A test of using the Player Manager to retrive an indvidual
        ///score from player object
        ///
        public void PMGetAPlayerScoreTest()
        {
            // Test parameters
            string testName = "Zelda";
            bool testStatus = true;
            int testNumScores = 4,
                testScoreRet = 0;
            List<int> testScores = new List<int>() { 45, 10, 8, 4, 0 };    // Test score ArrayList
            Player newPlayer = new Player(testName, testStatus,
                                        testNumScores, testScores);

            PlayerManager testPlayMngr = new PlayerManager();

            // Use a For loop to check each value
            for (int i = 0; i < testNumScores; i++)
            {
                testScoreRet = testPlayMngr.GetAPlayerScore(newPlayer, i);
                Assert.AreEqual(testScores[i], testScoreRet);
            }
        }

        [TestMethod]
        /// A test of usign the player manager to retrive the number
        /// of scores from the player object
        /// 
        public void PMGetNumberOfPlayerScoresTest()
        {
            // Test parameters
            string testName = "Zelda";
            bool testStatus = true;
            int testNumScores = 4,
                testNumScoreRet = 0;
            List<int> testScores = new List<int>() { 45, 10, 8, 4, 0 };    // Test score ArrayList
            Player newPlayer = new Player(testName, testStatus,
                                        testNumScores, testScores);

            PlayerManager testPlayMnger = new PlayerManager();

            testNumScoreRet = testPlayMnger.GetNumberOfPlayerScores(newPlayer);

            Assert.AreEqual(testNumScores, testNumScoreRet);
   
        }
    }
}
