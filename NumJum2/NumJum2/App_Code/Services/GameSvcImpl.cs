using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumJum2.Domain;

namespace NumJum2.Services
{
    public class GameSvcImpl : IGameSvc
    {
        // Add Guess
        public void AddGuess(JumbledNumber NumJumObj, long guess)
        {
            // Store guess in object
            NumJumObj.CurGuess = guess;

            // Incremnt Count
            NumJumObj.IncNumberGuesses();

        }

        // Update Number of Correct digits
        public void UpdateNumberCorrect(JumbledNumber NumJumObj, int numCorrect)
        {
            // Update number of correct digits
            NumJumObj.NumCorrect = numCorrect;

        }

        // Compare guess and Jumbled Number
        // Returns number of correct digits
        public int CompareGuessandNumJum(JumbledNumber NumJumObj)
        {
            long currGuess,
                currNumJum;

            int numDigits,
                numCorrect = 0,
                gint,
                njint;

            // Get values form NumJum Object
            currGuess = NumJumObj.CurGuess;
            currNumJum = NumJumObj.JNumberValue;
            numDigits = NumJumObj.NumDigits;

            ArrayList guessArray = new ArrayList(),
                numJumArray = new ArrayList();

            // Build array for both the guess and the NumJum for comparison

            for (int i = 0; i < numDigits; i++)
            {
                guessArray.Add((int)(currGuess % 10));
                numJumArray.Add((int)(currNumJum % 10));

                currGuess = (currGuess / 10);
                currNumJum = (currNumJum / 10);
            }

            // Reverse arrays to get in correct order
            guessArray.Reverse();
            numJumArray.Reverse();

            // Use for loops and if statements to compare values

            for (int i = 0; i < numDigits; i++)
            {
                // Use CompareTo method to determine if values are the same
                gint = (int)guessArray[i];
                njint = (int)numJumArray[i];

                if ((gint.CompareTo(njint) == 0))
                {
                    numCorrect++;
                }
            }

            return numCorrect;
        }

        // Change value of game status property 
        public void ChangeGameStatus(JumbledNumber NumJumObj, bool status)
        {
            NumJumObj.GameInProgress = status;
        }
    }
}
