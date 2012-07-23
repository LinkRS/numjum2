using System;
using NumJum2.Business;
using NumJum2.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumJum2
{
    public partial class Default : System.Web.UI.Page
    {

        /* Properties for Form */
        private Player _GamePlayer;
        private int _SelectedDifficulty;
        private JumbledNumber _CurrentJumbledNumber;
        private int _NumDigits;

        /* Methods to set private values */
        public Player GamePlayer
        {
            set
            {
                _GamePlayer = value;
            }
            get
            {
                return _GamePlayer;
            }
        }

        public int SelectedDifficulty
        {
            set
            {
                _SelectedDifficulty = value;
            }
            get
            {
                return _SelectedDifficulty;
            }
        }

        public JumbledNumber CurrentJumbledNumber
        {
            set
            {
                _CurrentJumbledNumber = value;
            }
            get
            {
                return _CurrentJumbledNumber;
            }

        }

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

        /* Private Utility Methods */
        private void ClearForm()
        {
            this.NumDigitsTextBox.Text = "";
            this.GuessListBox.Items.Clear();
            this.FeedbackListBox.Items.Clear();
            this.NumCorrectDigitsTextBox.Text = "";
            this.CurrentGuessTextBox.Text = "";
            this.CurrentScoreBox.Text = "";
        }

        private void AddKeyPress(int KeyNum)
        {

            if (this.CurrentGuessTextBox.Text.Length < NumDigits)
            {
                this.CurrentGuessTextBox.Text = this.CurrentGuessTextBox.Text + KeyNum;
            }
        }

        private void FillScoreList(Player GamePlayer)
        {
            // Create Player Manager
            PlayerManager playerManager = new PlayerManager();

            // Clear current scores to populate in order
            this.ScoreListBox.Items.Clear();

            // Load player scores from object
            if (GamePlayer.NumberOfScores > 0)
            {

                for (int i = 0; i < GamePlayer.NumberOfScores; i++)
                {
                    this.ScoreListBox.Items.Add(playerManager.GetAPlayerScore(GamePlayer, i).ToString());
                }
            }

            // Change label to reflect player name
            this.ScoreListLabel.Text = "Top Scores for " + GamePlayer.PlayerName + "!";
        }

        // Methods for game functions //
        private void LoadPlayerAction()
        {
            if (this.EnteredNameTextBox.Text.Length > 0)
            {
                // Update play field
                this.PlayerNameTextBox.Text = this.EnteredNameTextBox.Text;

                // Use Manager to load player data
                PlayerManager playerManager = new PlayerManager();
                GamePlayer = playerManager.LoadPlayer(this.PlayerNameTextBox.Text);

                // Load player scores from object
                FillScoreList(GamePlayer);

                // Check to see if player is already stored in session object
                // remove if necessary
                if (Session["Player"] != null)
                    Session.Remove("Player");

                // Store player object in Session
                Session["Player"] = GamePlayer;

                // Update Message Window
                if (GamePlayer.PlayerName.Length > 0)
                {
                    this.FeedbackListBox.Items.Add(GamePlayer.PlayerName + " loaded!");

                }
            }
            else
            {
                this.FeedbackListBox.Items.Add("Load Player Aborted!  Name was blank.");

                // Clear name from play filed if aborted
                this.PlayerNameTextBox.Text = "";
            }

        }

        private void SavePlayerAction()
        {
            // Save player data if player is loaded //
            bool saveGood = false;
            if ((this.PlayerNameTextBox.Text.Length > 0) && (Session["Player"] != null))
            {
                // Get player object from session
                GamePlayer = (Player)Session["Player"];

                PlayerManager playerManager = new PlayerManager();
                saveGood = playerManager.SavePlayer(GamePlayer, GamePlayer.PlayerName);

                // Report save status to message window
                if (saveGood)
                {
                    this.FeedbackListBox.Items.Add(GamePlayer.PlayerName + " saved = " + saveGood);
                }
                else
                {
                    this.FeedbackListBox.Items.Add("Player save failed");
                }
            }
            else
            {
                this.FeedbackListBox.Items.Add("No player to save!");
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                MultiView1.ActiveViewIndex = 0;
        }

        protected void MainView_MenuItemClick(object sender, MenuEventArgs e)
        {
            MultiView1.ActiveViewIndex = Int32.Parse(MainView.SelectedValue);
        }

        protected void GameMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            // Use switch statement to handle menu items
            switch (GameMenu.SelectedValue)
            {
                case "LoadMenu":
                    // Use modal popup to get player name
                    mpe.Show();
                    break;
                case "SaveMenu":
                    SavePlayerAction();
                    break;
                case "StartGameMenu":
                    this.FeedbackListBox.Items.Add("TODO Start new game");
                    break;
                default:
                    this.FeedbackListBox.Items.Add("Punt!! No Action");
                    break;
            }
        }

        protected void OneButton_Click(object sender, EventArgs e)
        {
            AddKeyPress(1);
        }

        protected void TwoButton_Click(object sender, EventArgs e)
        {
            AddKeyPress(2);
        }

        protected void ThreeButton_Click(object sender, EventArgs e)
        {
            AddKeyPress(3);
        }

        protected void FourButton_Click(object sender, EventArgs e)
        {
            AddKeyPress(4);
        }

        protected void FiveButton_Click(object sender, EventArgs e)
        {
            AddKeyPress(5);
        }

        protected void SixButton_Click(object sender, EventArgs e)
        {
            AddKeyPress(6);
        }

        protected void SevenButton_Click(object sender, EventArgs e)
        {
            AddKeyPress(7);
        }

        protected void EightButton_Click(object sender, EventArgs e)
        {
            AddKeyPress(8);
        }

        protected void NineButton_Click(object sender, EventArgs e)
        {
            AddKeyPress(9);
        }

        protected void ZeroButton_Click(object sender, EventArgs e)
        {
            AddKeyPress(0);
        }
        protected void ResetButton_Click(object sender, EventArgs e)
        {
            this.CurrentGuessTextBox.Text = "";
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            LoadPlayerAction();
        }

        protected void AddScoreButton_Click(object sender, EventArgs e)
        {
            // Debug function to add scores to player object for testing

            // Get player session and add random scores
            if (this.PlayerNameTextBox.Text.Length > 0)
            {
                GamePlayer = (Player)Session["Player"];

                // Generate a random score and add to player
                Random random = new Random();
                int randomScore = random.Next(0, 100);
                GamePlayer.AddScore(randomScore);

                // Update Feedback
                this.FeedbackListBox.Items.Add("Added " + randomScore.ToString() + " to " + GamePlayer.PlayerName);

                // Load player scores from object
                FillScoreList(GamePlayer);

                // Store player object in Session
                Session["Player"] = GamePlayer;

            }
            else
            {
                this.FeedbackListBox.Items.Add("Punt!! - No player object");
            }

        }


    }
}