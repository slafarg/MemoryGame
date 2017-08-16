namespace MemoryGameImproved
{
    using System;
    using System.Media;
    using System.Windows.Forms;

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
        /// Accesses database for high-score information.
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">Empty event arguments</param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtPlayerID.Text != string.Empty && this.txtPassword.Text != string.Empty)
            {
                // If statement checks to see if it pulls an unique row from the database. There cannot be more than 1.
                if (this.gameLoginTableAdapter.ValidateLogin(this.gameDBDataSet.Login, this.txtPlayerID.Text, this.txtPassword.Text) != 1)
                {
                    MessageBox.Show("Invalid Login Credentials");
                    this.txtPassword.Clear();
                    this.txtPlayerID.Clear();
                    this.txtPlayerID.Focus();
                }
                else
                {
                    // Saving valid playerID for scoreboard
                    GameInfo.Instance.PlayerID = this.txtPlayerID.Text;

                    // Removing visibility of login boxes
                    this.lblPassword.Hide();
                    this.lblPlayerID.Hide();
                    this.txtPassword.Hide();
                    this.txtPlayerID.Hide();
                    this.btnLogin.Hide();
                    this.AcceptButton = this.btnNewGame;
                    this.btnNewGame.Select();

                    // Adding visibility of hidden buttons
                    this.btnNewGame.Show();
                    this.btnHighScores.Show();
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
