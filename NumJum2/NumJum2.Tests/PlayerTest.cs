using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NumJum2.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumJum2.Tests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        ///A test for AddScore
        ///Creates a test player using the 4 argument constructor and tests
        ///adding a new score to the score array within the player class
        public void AddScoreTest()
        {
            Player target = new Player("Link");
            int score1 = 10,
                score2 = 25,
                score3 = 6,
                score4 = 14;
            target.AddScore(score1);
            target.AddScore(score2);
            target.AddScore(score3);
            target.AddScore(score4);


            //Test if expected score was added
            // Method adds, and then sorts value so should be at top
            for (int i = 0; i < target.NumberOfScores; i++)
            {
                Console.Write(" " + target.ScoreList[i] + " ");
            }
            Console.WriteLine("");
            Assert.AreEqual(target.ScoreList[0], score3);
            //Test if number of scores has been incremented
            Assert.AreEqual(target.NumberOfScores, 4);
        }


        ///A test for DecScore
        ///Decrements the number of scores stored in the player class
        [TestMethod]
        public void DecScoreTest()
        {
            List<int> scores = new List<int>() { 14, 3, 6, 0, 0 };            // 1st Test score ArrayList

            Player target = new Player("Link", false, 3, scores);
            target.DecScore();

            Assert.AreEqual(target.NumberOfScores, 2);

        }

        ///A test for DelScore
        ///Deletes a score and then decrements the score count
        [TestMethod]
        public void DelScoreTest()
        {
            List<int> scores = new List<int>() { 14, 3, 6, 0, 0 };  // 1st Test score ArrayList
            Player target = new Player("Link", false, 3, scores);   // 1st Test Player
            target.DelScore();

            //Test that score decremented
            Assert.AreEqual(target.NumberOfScores, 2);

            //Test that 3rd score was set to 0
            Assert.AreEqual(target.ScoreList[2], 0);
        }

        ///A test for IncScore
        [TestMethod]
        public void IncScoreTest()
        {
            List<int> scores = new List<int>() { 14, 3, 6, 0, 0 };  // 1st Test score ArrayList

            Player target = new Player("Link", false, 3, scores);
            target.IncScore();

            // Test that the number of scores was incremented
            Assert.AreEqual(target.NumberOfScores, 4);
        }
    }
}