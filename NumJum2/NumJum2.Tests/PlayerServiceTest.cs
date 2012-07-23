using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using NumJum2.Domain;
using NumJum2.Services;

namespace NumJum2.Tests
{
    [TestClass]
    public class PlayerServiceTest
    {
        [TestMethod]
        ///A test of using the factory to save PlayerState
        ///
        public void SavePlayerTest()
        {
            string fileName = "Link";                                       // File name for test
            List<int> scores = new List<int>() { 14, 3, 6, 0, 0 };          // Test score ArrayList       
            Player target = new Player(fileName, false, 3, scores);
            bool SaveGood = false;

            Factory testFactory = Factory.GetInstance();                    // Use Singleton pattern for Factory
            IPlayerSvc testSVC = (IPlayerSvc)
                testFactory.GetService(typeof(IPlayerSvc).Name);            // Test SVC via an interface

            // Try to save PlayerState
            try
            {
                SaveGood = testSVC.SavePlayerState(target, fileName);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail("Unable to create player object");
            }

            //Test if file has been created
            //Create path for test
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NumJum\\",
                filePath2 = Environment.GetEnvironmentVariable("TEMP") + "\\NumJum\\";
            Console.WriteLine("Path is: " + filePath + fileName + ".bin");
            Console.WriteLine("Temp Path is: " + filePath2 + fileName + ".bin");

            Assert.IsTrue(File.Exists(filePath + fileName + ".bin"));
            Assert.IsTrue(SaveGood);
        }

        [TestMethod]
        ///A test of using the factory to Load PlayerState
        ///
        public void LoadPlayerTest()
        {
            // Create file and data for testing
            // Test parameters
            string testName = "Zelda";
            bool testStatus = true;
            int testNumScores = 3;
            Player testPlayer = null;
            List<int> testScores = new List<int>() { 60, 32, 15, 4, 0 };    // Test score ArrayList
            Player newPlayer = new Player(testName, testStatus,
                                        testNumScores, testScores);

            string fileName = "Zelda";                                      // File name for test

            Factory testFactory = Factory.GetInstance();                    // Factory instance using Singleton pattern
            IPlayerSvc testSVC = (IPlayerSvc)                               // Test Service using in interface marker
                testFactory.GetService(typeof(IPlayerSvc).Name);


            // Create player data file for testing
            try
            {
                testSVC.SavePlayerState(newPlayer, fileName);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail("Save Player Failed");
            }

            // Try to Create player object from file
            try
            {
                testPlayer = testSVC.LoadPlayerData(fileName);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail("Unable to load player data from file");
            }

            //Test if player data has been loaded
            Assert.AreEqual(testPlayer.PlayerName, testName);
            Assert.AreEqual(testPlayer.GameStatus, testStatus);
            Assert.AreEqual(testPlayer.NumberOfScores, testNumScores);

            //Test arbitrary list value
            Assert.AreEqual(testPlayer.ScoreList[1], testScores[1]);
        }

        [TestMethod]
        ///A test of catching the exception in LoadPlayer()
        ///This creates a new player as the file is not found
        ///Service layer implementation throws an exception, catches
        ///it and then creates a new player object
        public void LoadPlayerExceptionTest()
        {
            string fileName = "Tinker";                                     // File name for test that does not exist
            Player testPlayer = new Player();
            Factory testFactory = Factory.GetInstance();                    // Factory instance using Singleton pattern
            IPlayerSvc testSVC = (IPlayerSvc)                               // Test service using a marker interface
                testFactory.GetService(typeof(IPlayerSvc).Name);

            // Create player object from file
            try
            {
                testPlayer = testSVC.LoadPlayerData(fileName);
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
        /// Test setting the game state using the Player Service
        ///
        public void SetGameStateTest()
        {
            bool testState1 = true,
                testState2 = false;

            // Test parameters
            string testName = "Zelda";
            bool testStatus = true;
            int testNumScores = 4;
            List<int> testScores = new List<int>() { 60, 32, 15, 4, 0 };    // Test score ArrayList
            Player newPlayer = new Player(testName, testStatus,
                                        testNumScores, testScores);
            Factory testFactory = Factory.GetInstance();

            IPlayerSvc testSVC = (IPlayerSvc)
               testFactory.GetService(typeof(IPlayerSvc).Name);

            // Set value  usign service and test
            testSVC.SetGameState(newPlayer, testState1);
            Assert.IsTrue(newPlayer.GameStatus);

            // Set value usign serivce and test
            testSVC.SetGameState(newPlayer, testState2);
            Assert.IsFalse(newPlayer.GameStatus);
        }

        [TestMethod]
        /// Test for adding score to player object List<int>
        /// 
        public void AddPlayerScoreTest()
        {
            // Test parameters
            string testName = "Zelda";
            bool testStatus = true;
            int testNumScores = 4;
            List<int> testScores = new List<int>() { 60, 32, 15, 4 };    // Test score ArrayList
            Player newPlayer = new Player(testName, testStatus,
                                        testNumScores, testScores);
            Factory testFactory = Factory.GetInstance();

            IPlayerSvc testSVC = (IPlayerSvc)
               testFactory.GetService(typeof(IPlayerSvc).Name);

            // Add new score
            // Should increment count to 5
            testSVC.AddPlayerScore(newPlayer, 2);
            Assert.IsTrue((newPlayer.NumberOfScores == 5));

            // Test if first score is now 2
            Assert.AreEqual(newPlayer.ScoreList[0], 2);
        }

        [TestMethod]
        /// Test for retrieiving specific score out of ArrayList
        /// 
        public void GetIndexScoreTest()
        {
            // Test parameters
            string testName = "Zelda";
            bool testStatus = true;
            int testNumScores = 4,
                testScoreRet = 0;
            List<int> testScores = new List<int>() { 60, 32, 15, 4, 0 };    // Test score ArrayList
            Player newPlayer = new Player(testName, testStatus,
                                        testNumScores, testScores);
            Factory testFactory = Factory.GetInstance();

            IPlayerSvc testPlaySvc = (IPlayerSvc)
                testFactory.GetService(typeof(IPlayerSvc).Name);

            // Use a For loop to check each value
            for (int i = 0; i < testNumScores; i++)
            {
                testScoreRet = testPlaySvc.GetIndexScore(newPlayer, i);
                Assert.AreEqual(testScores[i], testScoreRet);
            }
        }

        [TestMethod]
        /// Test for retrieving the number of scores
        /// stored in player object
        /// 
        public void GetNumberOfScoresTest()
        {
             // Test parameters
            string testName = "Zelda";
            bool testStatus = true;
            int testNumScores = 4,
                testNumScoreRet = 0;
            List<int> testScores = new List<int>() { 60, 32, 15, 4, 0 };    // Test score ArrayList
            Player newPlayer = new Player(testName, testStatus,
                                        testNumScores, testScores);
            Factory testFactory = Factory.GetInstance();


            IPlayerSvc testPlaySvc = (IPlayerSvc)
                testFactory.GetService(typeof(IPlayerSvc).Name);

            testNumScoreRet = testPlaySvc.GetNumberOfScores(newPlayer);

            Assert.AreEqual(testNumScores, testNumScoreRet);
        }
    }
}
