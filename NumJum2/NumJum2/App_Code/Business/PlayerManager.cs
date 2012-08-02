using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.IO;
using NumJum2.Domain;
using NumJum2.Services;
using NumJum2.Services.Exceptions;

namespace NumJum2.Business
{
    public class PlayerManager : Manager
    {
        public Player LoadPlayer(string storeName)
        {
            try
            {
                IPlayerSvc playSvc =
                    (IPlayerSvc)GetService(typeof(IPlayerSvc).Name);

                // Return loaded player
                return playSvc.GetPlayerFromDb(storeName);
            }
            catch (PlayerNotFoundException e)
            {
                Console.WriteLine(e.Message);

                // Player not found, crete a new one
                return new Player(storeName);
            }
        }

        public bool SavePlayer(Player player, string storeName)
        {
            bool SaveGood = false;

            IPlayerSvc playSvc =
                (IPlayerSvc)GetService(typeof(IPlayerSvc).Name);

            // Check for file exceptions
            try
            {
                //playSvc.SavePlayerState(player, storeName);
                SaveGood = playSvc.SavePlayerToDb(player);

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                // Catch file error and throw up to presentation layer
                SaveGood = false;
                throw e;
            }

            return SaveGood;
        }

        public bool DeletePlayerData(string playerName)
        {
            IPlayerSvc playSvc =
                (IPlayerSvc)GetService(typeof(IPlayerSvc).Name);

            return playSvc.DeletePlayer(playerName);
        }

        public void UpdateGameState(Player player, bool gamestate)
        {
            IPlayerSvc playSvc =
                (IPlayerSvc)GetService(typeof(IPlayerSvc).Name);

            playSvc.SetGameState(player, gamestate);
        }

        public void UpdatePlayerScore(Player player, int score)
        {
            IPlayerSvc playSvc =
                (IPlayerSvc)GetService(typeof(IPlayerSvc).Name);

            playSvc.AddPlayerScore(player, score);
        }

        public int GetAPlayerScore(Player player, int scoreIdx)
        {
            IPlayerSvc playSvc =
                (IPlayerSvc)GetService(typeof(IPlayerSvc).Name);

            return playSvc.GetIndexScore(player, scoreIdx);
        }

        public int GetNumberOfPlayerScores(Player player)
        {
            IPlayerSvc playSvc =
                (IPlayerSvc)GetService(typeof(IPlayerSvc).Name);

            return playSvc.GetNumberOfScores(player);
        }

    }


}
