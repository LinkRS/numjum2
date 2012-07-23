using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumJum2.Domain;
using System.IO;                                        // Used for file serialization
using System.Runtime.Serialization;                     // Used for file serialization
using System.Runtime.Serialization.Formatters.Binary;   // Used for file serialization

namespace NumJum2.Services
{
    public class PlayerSvcWebImpl : IPlayerSvc
    {
        // Private method to get location to save files
        // Just a stub, will be fleshed out later
        private string GetFilePath()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NumJum\\";

            if ((Directory.Exists(filePath) == false))
            {
                // AppData folder not there, create
                try
                {
                    Directory.CreateDirectory(filePath);
                }
                catch (IOException)
                {
                    // IF unable to write to AppData, put files in system temp folder
                    Console.WriteLine("Filesystemm Error: Using temp folder");
                    filePath = Environment.GetEnvironmentVariable("TEMP") + "\\NumJum\\";
                }
            }

            return filePath;

        }

        public bool SavePlayerState(Player player, string storeName)
        {
            FileStream fileStream = null;
            string filePath;
            bool SaveGood = false;

            // Try to save player data to filesystem
            try
            {
                // Use internal method to get path for save files
                filePath = GetFilePath();

                fileStream = new FileStream(filePath + storeName + ".bin", FileMode.Create, FileAccess.Write);

                // Use IFormatter interface to send data to FS
                IFormatter PlayerState = new BinaryFormatter();
                PlayerState.Serialize(fileStream, player);
                SaveGood = true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("IOException caugt from filestream");
                SaveGood = false;
                throw;
            }
            finally
            {
                fileStream.Close();

            }

            return SaveGood;
        }

        public Player LoadPlayerData(string storeName)
        {
            // Attempt to load player specified file data
            Player player;
            string filePath;
            FileStream fileStream = null;
            try
            {
                // Use internal method to get path for save files
                filePath = GetFilePath();

                fileStream = new FileStream(filePath + storeName + ".bin", FileMode.Open, FileAccess.Read);

                // Use IFormatter interface to pull data from FS
                IFormatter PlayerState = new BinaryFormatter();
                player = PlayerState.Deserialize(fileStream) as Player;
            }
            catch (SerializationException)
            {
                Console.WriteLine("Error with the file serialization, ignoring file");

                // Throw custom exception to treat as a new player
                try
                {
                    throw new PlayerNotFoundException("File not found, continuing");
                }
                catch (PlayerNotFoundException)
                {
                    // If file not found, create new player object
                    Console.WriteLine("Caught PlayerNotFound in Impl File!");
                    player = new Player(storeName);

                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid format found in loaded file");

                // Throw a custom exception to create a new copy of player
                try
                {
                    throw new PlayerNotFoundException("File not found, continuing");
                }
                catch (PlayerNotFoundException)
                {
                    // If file not found, create new player object
                    Console.WriteLine("Caught PlayerNotFound in Impl File!");
                    player = new Player(storeName);

                }
            }
            catch (FileNotFoundException)
            {
                //File not found, throw custom exception
                Console.WriteLine("File not found, continuing...");

                // Throw a custom exception to create the player
                try
                {
                    throw new PlayerNotFoundException("File not found, continuing");
                }
                catch (PlayerNotFoundException)
                {
                    // If file not found, create new player object
                    Console.WriteLine("Caught PlayerNotFound in Impl File!");
                    player = new Player(storeName);

                }
            }
            finally
            {
                Console.WriteLine("Process finally block");
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            // Return player object
            Console.WriteLine("Out of try....catch");
            return player;
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
            return (int)player.ScoreList[scoreIdx];;
        }

        public int GetNumberOfScores(Player player)
        {
            return player.NumberOfScores;
        }

    }
        // Define Custom Exceptions
        [Serializable()]
        public class PlayerNotFoundException : ApplicationException, ISerializable
        {
            public PlayerNotFoundException() { }
            public PlayerNotFoundException(string message)
                : base(message) { }
            public PlayerNotFoundException(string message, Exception inner)
                : base(message) { }

            // For serialization
            protected PlayerNotFoundException(SerializationInfo info, StreamingContext context) { }

        }
}
