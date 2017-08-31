namespace MemoryGameImproved.CreateGameForm
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// A class containing info for the Matching Pairs game.
    /// <para>Be sure to use SendData to link the game's info</para>
    /// </summary>
    public partial class Gameboard : Form
    {
        const int clickDelay = 700;
        const int totalTimeTimerInverval = 100;
        const double framePercentageSize = 0.75;

        #region Get Sets

        /// <summary>
        /// List of buttons that will contain images
        /// </summary>
        public List<Button> btnList
        {
            get;
            private set;
        }

        /// <summary>
        /// List of buttons to cover other list of buttons
        /// </summary>
        public List<Button> coverList
        {
            get;
            private set;
        }

        /// <summary>
        /// A list of integers that represent indexes
        /// </summary>
        public List<int> indexList
        {
            get;
            private set;
        }

        /// <summary>
        /// Integer to count how many buttons clicked
        /// <remarks>The game only wants to determine if two buttons
        /// contain the same pictures, a pair.</remarks>
        /// </summary>
        public int pairIndex
        {
            get;
            private set;
        }

        /// <summary>
        /// Integer that counts how many buttons have been revealed correctly.
        /// </summary>
        public int revealed
        {
            get;
            private set;
        }

        /// <summary>
        /// Total clicks for current level.
        /// </summary>
        public int totalClicks
        {
            get;
            private set;
        }

        /// <summary>
        /// Total time for current level.
        /// </summary>
        public double score
        {
            get;
            private set;
        }

        /// <summary>
        /// Holds total time for scoring.
        /// </summary>
        public double totalTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Timer that is intended for stopping the player from clicking
        /// while a pair is being evaluated for similarity.
        /// </summary>
        public Timer clickDelayTimer
        {
            get;
            private set;
        }

        /// <summary>
        /// Timer to keep track of total time playing.
        /// </summary>
        public Timer totalTimeTimer
        {
            get;
            private set;
        }

        /// <summary>
        /// Label to contain the Width, Height, and Location for spawning buttons.
        /// </summary>
        public Label buttonFrame
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gameboard"/> class. 
        /// </summary>
        public Gameboard()
        {
            this.InitializeComponent();
            indexList = new List<int>();
            pairIndex = -1;
            revealed = 0;
            totalClicks = 0;
            score = 0;
            clickDelayTimer = new Timer();
            totalTimeTimer = new Timer();
            buttonFrame = new Label();
        }
        #endregion

        /// <summary>
        /// Constructor creates the level for Match Pair game.
        /// </summary>                        
        public void CreateGameBoard()
        {
            try
            {
                // Timer initialization            
                clickDelayTimer.Interval = clickDelay;
                clickDelayTimer.Tick += ClickDelay_Tick;
                totalTimeTimer.Interval = totalTimeTimerInverval;
                totalTimeTimer.Tick += TotalTime_Tick;

                // Setting form
                this.Size = Screen.PrimaryScreen.Bounds.Size;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.BackgroundImage = Properties.Resources.testrisContainer;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                //Exit button
                Button btnExit = new Button()
                {
                    Name = "btnExit",
                    BackColor = Color.FromArgb(0, Color.White),
                    TabStop = false,
                    FlatStyle = FlatStyle.Flat,
                    Width = 1,
                    Height = 1
                };
                btnExit.Click += new EventHandler(this.ExitForm);
                btnExit.FlatAppearance.BorderSize = 0;
                this.Controls.Add(btnExit);
                this.CancelButton = btnExit;

                //Create frame to fit buttons in.
                buttonFrame.Width = (int)Math.Floor(framePercentageSize * this.Width);
                buttonFrame.Height = (int)Math.Floor(framePercentageSize * this.Height);
                buttonFrame.Location = new Point((Width - buttonFrame.Width) / 2, (Height - buttonFrame.Height) / 2);

                btnList = CreateButtons.SpawnButtonList(buttonFrame);
                coverList = CreateButtons.SpawnButtonList(buttonFrame);

                for (int i = 0; i < this.btnList.Count(); ++i)
                {
                    coverList[i].Click += new EventHandler(RevealClick);
                    this.Controls.Add(this.btnList[i]);
                    this.Controls.Add(this.coverList[i]);
                    coverList[i].BringToFront();
                    coverList[i].BackColor = Color.Gray;
                }

                SetButtonImagesRandomly.RandomizeImages(btnList);

                //Start timer as late as possible
                totalTimeTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to create level.", ex);
            };
        }

        /// <summary>
        /// Removes covers and detects if the buttons underneath
        /// have similar pictures.
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">No event arguments</param>
        private void RevealClick(object sender, EventArgs e)
        {
            if (this.clickDelayTimer.Enabled != true)
            {
                ++totalClicks;

                // Find cover and button
                Button cover = (Button)sender;
                this.indexList.Add((int)cover.Tag);

                ++this.pairIndex;
                cover.Hide();

                // See if two pictures are revealed
                if (this.pairIndex == 1)
                {
                    if (this.btnList[this.indexList[0]].BackgroundImage.Tag != this.btnList[this.indexList[1]].BackgroundImage.Tag)
                    {
                        // If not same picture, then hide pictures
                        this.clickDelayTimer.Enabled = true;
                    }
                    else
                    {
                        // If same pictures, leave unhidden and increment amount revealed
                        this.revealed += 2;

                        // Test if all are revealed
                        if (this.revealed == GameInfo.Instance.GetSize())
                        {
                            // You won the level
                            totalTimeTimer.Enabled = false;
                            MessageBox.Show("You finished!");
                            GameInfo.Instance.LevelComplete = true;
                            this.ExitForm(this, EventArgs.Empty);
                        }
                    }

                    // Remove pair
                    this.pairIndex = -1;
                    if (this.clickDelayTimer.Enabled == false)
                    {
                        this.indexList.Clear();
                    }                    
                }
            }
        }

        /// <summary>
        /// Covers up Buttons after a brief delay
        /// </summary>
        /// <param name="sender">A timer</param>
        /// <param name="e">No event arguments</param>
        private void ClickDelay_Tick(object sender, EventArgs e)
        {
            this.coverList[this.indexList[0]].Show();
            this.coverList[this.indexList[1]].Show();
            this.indexList.Clear();
            this.clickDelayTimer.Stop();
        }

        /// <summary>
        /// Increments totalTime by 0.1 seconds.
        /// </summary>
        /// <param name="sender">Timer sent</param>
        /// <param name="e">Empty arguments</param>
        private void TotalTime_Tick(object sender, EventArgs e)
        {
            totalTime += .1;
            
            // Score handled here in case somebody leaves a game before completing level
            this.score = Math.Floor((GameInfo.Instance.GetSize() - (totalClicks / (GameInfo.Instance.LevelPlus1 - Math.Floor(GameInfo.Instance.Level / 3d)))) * (revealed / 2) - totalTime);
        }

        /// <summary>
        /// Exits form after updating points.
        /// </summary>
        /// <param name="sender">A button object</param>
        /// <param name="e">No event arguments</param>
        private void ExitForm(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show("Score: " + this.score.ToString() + ", Time: " + this.totalTime.ToString() + ", Clicks: " + this.totalClicks.ToString());
                UpdateInfo.UpdateGameInfo(score, totalClicks, totalTime);

                // If you beat the final level (there is one more picture than there is the level
                if (GameInfo.Instance.Level == (GameInfo.Instance.ImageList.Count() - 1) && GameInfo.Instance.LevelComplete == true)
                {
                    // Create final score screen and update database
                    GameInfo.Instance.Reset();
                    this.Close();
                }
                else if (GameInfo.Instance.LevelComplete == true)
                {
                    // If you beat a level that isn't the final level
                    CreateVictoryForm.Victory victoryForm = new CreateVictoryForm.Victory();
                    victoryForm.CreateVictoryBoard();
                    victoryForm.ShowDialog();
                    ++GameInfo.Instance.Level;
                    this.Close();
                }
                else
                {
                    // Exiting prematurely
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }        
    }
}
