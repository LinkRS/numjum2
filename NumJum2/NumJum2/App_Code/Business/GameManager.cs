using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumJum2.Domain;
using NumJum2.Services;

namespace NumJum2.Business
{
    public class GameManager : Manager
    {
        public int StartGame(JumbledNumber NumJum, int difficulty)
        {
            int numDigits;

            IGameSvc gameSvc =
                (IGameSvc)GetService(typeof(IGameSvc).Name);

            IJumbledNumberSvc numjumSvc =
                (IJumbledNumberSvc)GetService(typeof(IJumbledNumberSvc).Name);

            // Create Jumbled Number
            numDigits = numjumSvc.GetJumbledNumber(NumJum, difficulty);

            // Toggle Game Status
            gameSvc.ChangeGameStatus(NumJum, true);

            return numDigits;

        }

        public void StopGame(JumbledNumber NumJum)
        {
            IGameSvc gameSvc =
                (IGameSvc)GetService(typeof(IGameSvc).Name);

            gameSvc.ChangeGameStatus(NumJum, false);
        }

        public void CheckGuess(JumbledNumber NumJum, long guess)
        {
            int NumCorrect = 0;

            IGameSvc gameSvc =
                (IGameSvc)GetService(typeof(IGameSvc).Name);

            // Add guess and increment number of guesses in object
            gameSvc.AddGuess(NumJum, guess);

            // Compare guess with Jumbled Number
            NumCorrect = gameSvc.CompareGuessandNumJum(NumJum);

            // Store number of correct digits in object
            gameSvc.UpdateNumberCorrect(NumJum, NumCorrect);

            //return NumCorrect;
        }

        public bool CheckWin(JumbledNumber NumJum, Player player)
        {

            if (NumJum.NumCorrect == NumJum.NumDigits)
            {
                // Set player win value to true
                player.GameStatus = true;
                return true;
            }
            else
            {
                // Set player win to false
                player.GameStatus = false;
                return false;
            }
        }
    }
}
