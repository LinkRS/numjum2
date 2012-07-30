using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumJum2.Domain;
using NumJum2.Services.DAL;
using NumJum2.Services.Exceptions;
using System.IO;
using System.Data.Entity;

namespace NumJum2.Services
{
    public class PlayerSvcWebImpl : IPlayerSvc
    {
        public bool SavePlayerToDb(Player player)
        {
            bool SaveGood = false,
                NewPlayer = true;

            PlayerDb AddPlayer = null;
            int HoldPlayerDbID = 0;

            /* Get a context to the DB and save the passed object*/
            using (var db = new PlayerDbContext())
            {
                try
                {
                    // If a player exisits in db, find and attach to a context to update
                
                    foreach (PlayerDb findPlayer in db.PlayersDb)
                    {
                        if (findPlayer.PlayerName == player.PlayerName)
                        {
                            NewPlayer = false;
                            // Copy values to object
                            HoldPlayerDbID = findPlayer.PlayerDbID;
                            findPlayer.PlayerName = player.PlayerName;
                            findPlayer.GameStatus = player.GameStatus;
                            findPlayer.NumScores = player.NumberOfScores;
                        }
                    }

                    // If new player, add to DB
                    if (NewPlayer)
                    {
                        AddPlayer = new PlayerDb();
                        AddPlayer.PlayerName = player.PlayerName;
                        AddPlayer.GameStatus = player.GameStatus;
                        AddPlayer.NumScores = player.NumberOfScores;
                        db.PlayersDb.Add(AddPlayer);
                        db.SaveChanges();
                        HoldPlayerDbID = AddPlayer.PlayerDbID;
                    }

                    // If there are scores, update PlayerScores object
                    if (player.NumberOfScores > 0)
                    {
                        // Remove Scores first to compensate for score
                        // auto-sorting in domain object
                        foreach (PlayerScore checkScore in db.PlayerScores)
                        {
                            if (checkScore.PlayerDbID == HoldPlayerDbID)
                                db.PlayerScores.Remove(checkScore);
                        }

                        PlayerScore SaveScores = new PlayerScore();
                        for (int i = 0; i < player.NumberOfScores; i++)
                        {
                            SaveScores.PlayerDbID = HoldPlayerDbID;
                            SaveScores.Score = player.ScoreList[i];
                            db.PlayerScores.Add(SaveScores);

                            // Start next entry
                            SaveScores = new PlayerScore();
                        }
                    }

                    db.SaveChanges();
                    // No errors, set return value
                    SaveGood = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DB store exception" + e.Message);
                    SaveGood = false;
                }

                // Close db connection
                db.Dispose();
            }
            return SaveGood;
        }

        public Player GetPlayerFromDb(string PlayerName)
        {
            Player getPlayer = null;

            // Get a context to the DB and find passed player
            using (var db = new PlayerDbContext())
            {
                // Holding Entity Object
                PlayerDb holdPlayer = new PlayerDb();

                // Get data from database
                foreach (PlayerDb findPlayer in db.PlayersDb)
                {
                    if (findPlayer.PlayerName == PlayerName)
                    {
                        getPlayer = new Player();
                        getPlayer.PlayerName = findPlayer.PlayerName;
                        getPlayer.GameStatus = findPlayer.GameStatus;
                        // Set number of scores to 0, and let value be built when loading
                        getPlayer.NumberOfScores = 0;

                        // If there are scores, need to load up player
                        if (findPlayer.NumScores > 0)
                        {
                            foreach (PlayerScore findScore in db.PlayerScores)
                            {
                                if (findScore.PlayerDbID == findPlayer.PlayerDbID)
                                {
                                    getPlayer.AddScore(findScore.Score);
                                }
                            }
                        }
                    }
                }

                // Check to see if player was loaded, and if not throw exception
                if (getPlayer == null)
                    throw new PlayerNotFoundException("Player not found in DB");

                // Close db connection
                db.Dispose();
            }

            return getPlayer;            
        }

        public void SetGameState(Player player, bool gamestate)
        {
            player.GameStatus = gamestate;
        }

        public void AddPlayerScore(Player player, int score)
        {
            // Update player object with score
            player.AddScore(score);
        }

        public int GetIndexScore(Player player, int scoreIdx)
        {
            return (int)player.ScoreList[scoreIdx];
        }

        public int GetNumberOfScores(Player player)
        {
            return player.NumberOfScores;
        }

    }
}
