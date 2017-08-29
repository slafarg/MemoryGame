namespace MemoryGameImproved
{
    using System;
    using System.Media;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;
    using DatabaseManagement;

    /// <summary>
    /// Game Menu.
    /// </summary>
    public partial class GameMenu : Form
    {
        /// <summary>
        /// Background music.
        /// </summary>                   
        private SoundPlayer backgroundMusic = new SoundPlayer(Properties.Resources.tetrisBackground);

        

        /// <summary>
        /// Initializes a new instance of the <see cref="GameMenu"/> class.
        /// </summary>
        public GameMenu()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Plays music on load.
        /// </summary>
        /// <param name="sender">Object form</param>
        /// <param name="e">Empty arguments</param>
        private void Menu_Load(object sender, EventArgs e)
        {
            this.backgroundMusic.PlayLooping();

            // Set label parent to picture box containing gif to make it transparent.
            this.lblDeveloper.Parent = this.picBoxOpening;  
        }

        /// <summary>
        /// Brings up a login creation form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateLogin_Click(object sender, EventArgs e)
        {
            var newLogin = new CreateLoginMenu();
            newLogin.ShowDialog();
        }

        /// <summary>
        /// Accesses database for login information.
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">Empty event arguments</param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtPlayerID.Text != string.Empty && this.txtPassword.Text != string.Empty)
            {
                try
                {
                    // If statement checks to see if it pulls an unique row from the database. There cannot be more than 1.
                    if (!Queries.ValidateLogin(this.txtPlayerID.Text, this.txtPassword.Text))
                    {
                        MessageBox.Show("Invalid Login Credentials");
                        txtPassword.Clear();
                        txtPlayerID.Clear();
                        txtPlayerID.Focus();
                    }
                    else
                    {
                        // Saving valid playerID for scoreboard
                        GameInfo.Instance.PlayerID = this.txtPlayerID.Text;

                        // Removing visibility of login boxes
                        lblPassword.Hide();
                        lblPlayerID.Hide();
                        txtPassword.Hide();
                        txtPlayerID.Hide();
                        btnLogin.Hide();
                        btnCreateLogin.Hide();
                        this.AcceptButton = btnNewGame;
                        btnNewGame.Select();

                        // Adding visibility of hidden buttons
                        btnNewGame.Show();
                        btnHighScores.Show();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }        

        /// <summary>
        /// Starts a new game.
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">Empty event arguments</param>
        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            // Reseting game
            GameInfo.Instance.Reset();
            this.btnContinue.Show();
            this.btnContinue.Select();
            this.BtnContinue_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Shows high-scores.
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">Empty event arguments</param>
        private void BtnHighScores_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Starts the next level.
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">Empty event arguments</param>
        private void BtnContinue_Click(object sender, EventArgs e)
        {
            GameInfo.Instance.LevelComplete = false;
            CreateGameForm.Gameboard attempt = new CreateGameForm.Gameboard();
            attempt.CreateGameBoard();
            attempt.ShowDialog();
            this.btnContinue.Select();
        }
    }
}
