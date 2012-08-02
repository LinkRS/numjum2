using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumJum2.Domain;

namespace NumJum2.Services
{
    public interface IService { }

    public interface IPlayerSvc : IService
    {
        bool SavePlayerToDb(Player player);
        Player GetPlayerFromDb(string playerName);
        bool DeletePlayer(string playerName);
        void SetGameState(Player player, bool state);
        void AddPlayerScore(Player player, int score);
        int GetIndexScore(Player player, int scoreIdx);
        int GetNumberOfScores(Player player);
    }

    public interface IJumbledNumberSvc : IService
    {
        // Returns with number of digits
        int GetJumbledNumber(JumbledNumber NumJumObj, int difficulty);
        bool GetGameStatus(JumbledNumber NumJumObj);

    }

    public interface IGameSvc : IService
    {
        // Add Guess
        void AddGuess(JumbledNumber NumJumObj, long guess);

        // Update Number of Correct digits
        void UpdateNumberCorrect(JumbledNumber NumJumObj, int numCorrect);

        // Compare guess and Jumbled Number
        // Returns number of correct digits
        int CompareGuessandNumJum(JumbledNumber NumJumObj);

        // Toggle Game Status
        void ChangeGameStatus(JumbledNumber NumJumObj, bool GameStatus);
    }
}
