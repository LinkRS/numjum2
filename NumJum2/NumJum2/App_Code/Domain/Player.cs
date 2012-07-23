using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumJum2.Domain
{
    [Serializable()]                    // Allow the player class to be saved to a file
    public class Player
    {
        /// This class represents the player.

        /// List Attributes
        private string _PlayerName;
        private bool _GameStatus;        // True indicates last game has been won, while False indicates game has been lost
        private int _NumScores;          // Holds number of scores currently stored for player    
        private List<int> _ScoreList = new List<int>();

        /// Describe Behaviour

        public string PlayerName
        {
            set
            {
                _PlayerName = value;
            }

            get
            {
                return _PlayerName;
            }
        }

        public bool GameStatus
        {
            set
            {
                _GameStatus = value;
            }

            get
            {
                return _GameStatus;
            }
        }

        public int NumberOfScores
        {
            set
            {
                _NumScores = value;
            }

            get
            {
                return _NumScores;
            }

        }

        public List<int> ScoreList
        {
            set
            {
                _ScoreList = value;
            }

            get
            {
                return _ScoreList;
            }
        }

        public void AddScore(int score)
        {
            // Add score
            _ScoreList.Add(score);
            // Sort List
            _ScoreList.Sort();
           // Increment Counter
            IncScore();
        }

        public void DelScore()
        {
            // Remove lowest score as long as there is at least 1 score
            if (_NumScores > 0)
            {
                // Sort List<int>
                _ScoreList.Sort();
                // Decrement Counter
                DecScore();
                // Set last memeber to 0
                _ScoreList[_NumScores] = 0;

            }

        }
        public void IncScore()
        {
            // Add to score count
            _NumScores++;
        }

        public void DecScore()
        {
            // Decrement score count
            // Only decrement if score is greater than zero
            if (_NumScores > 0)
                _NumScores--;
        }

        /// Constructors
        public Player() { }             // Default Constructor
        public Player(string playerName, // Four argument constructor
                      bool gameStatus,
                      int numScores,
                      List<int> scoreList)
        {
            _PlayerName = playerName;
            _GameStatus = gameStatus;
            _NumScores = numScores;
            _ScoreList = scoreList;
        }
        public Player(string playerName)// Single Argument constructor, used for new player of new game
        {
            _PlayerName = playerName;
            _GameStatus = false;
            _NumScores = 0;
            _ScoreList.Clear();
        }

    }
}