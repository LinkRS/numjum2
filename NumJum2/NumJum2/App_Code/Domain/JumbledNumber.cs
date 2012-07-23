using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumJum2.Domain
{
    public class JumbledNumber
    {
        private int _NumDigits;
        private long _JNumberValue;
        private long _CurGuess;
        private int _NumGuesses;
        private int _NumCorrect;
        private bool _GameInProgress;

        public int NumDigits
        {
            set
            {
                _NumDigits = value;
            }

            get
            {
                return _NumDigits;
            }
        }

        public long JNumberValue
        {
            set
            {
                _JNumberValue = value;
            }

            get
            {
                return _JNumberValue;
            }
        }

        public long CurGuess
        {
            set
            {
                _CurGuess = value;
            }

            get
            {
                return _CurGuess;
            }
        }

        public int NumGuesses
        {
            set
            {
                _NumGuesses = value;
            }
            get
            {
                return _NumGuesses;
            }
        }

        public int NumCorrect
        {
            set
            {
                _NumCorrect = value;
            }

            get
            {
                return _NumCorrect;
            }
        }

        public bool GameInProgress
        {
            set
            {
                _GameInProgress = value;
            }
            get
            {
                return _GameInProgress;
            }
        }

        /// Methods

        public void IncNumberCorrect()
        {
            _NumCorrect++;
        }

        public void IncNumberGuesses()
        {
            _NumGuesses++;
        }
        
        /// Constructors
        public JumbledNumber() {}                   // Default Constructor

        public JumbledNumber(int numDigits,         // Four Argument Constructor
                             long jnumberValue,
                             long curGuess,
                             int numGuess,
                             int numCorrect,
                             bool gameStart)
        {
            _NumDigits = numDigits;
            _JNumberValue = jnumberValue;
            _CurGuess = curGuess;
            _NumGuesses = numGuess;
            _NumCorrect = numCorrect;
            _GameInProgress = gameStart;

        }

        public JumbledNumber(int numDigits,         // Two argument constructor
                             long jnumberValue)
        {
            _NumDigits = numDigits;
            _JNumberValue = jnumberValue;
            _CurGuess = 0;
            _NumGuesses = 0;
            _NumCorrect = 0;
            _GameInProgress = false;

        }

    }
}
