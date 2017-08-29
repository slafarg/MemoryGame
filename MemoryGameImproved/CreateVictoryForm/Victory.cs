namespace MemoryGameImproved.CreateVictoryForm
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Victory Screen
    /// </summary>
    public partial class Victory : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Victory"/> class. 
        /// </summary>
        /// <param name="info">Current game info</param>
        public Victory()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Creates victory screen.
        /// </summary>
        public void CreateVictoryBoard()
        {
            // TODO: Last level completion gameVictory() Congratulations!
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.BackgroundImage = Properties.Resources.testrisContainer;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Invisible exit button set equal to Cancel Button
            Button btnExit = new Button()
            {
                Name = "btnExit",
                BackColor = Color.FromArgb(255, Color.White),
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
                Width = 1,
                Height = 1
            };
            btnExit.Click += new EventHandler(this.ExitForm);
            btnExit.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnExit);
            this.CancelButton = btnExit;

            // Victory Controls
            Label lblVictoryTitle = new Label();
            Label lblVictoryText = new Label();
            Button btnContinue = new Button();
            Label lblGrayBackground = new Label();

            this.Controls.Add(btnContinue);
            this.Controls.Add(lblGrayBackground);
            this.Controls.Add(lblVictoryTitle);
            this.Controls.Add(lblVictoryText);
            btnContinue.Click += this.ExitForm;

            // Must set text before calling position functions
            lblVictoryTitle.Text = "Level Complete!";
            lblVictoryText.Text = "Score: " + GameInfo.Instance.Score + "\n Time: " + GameInfo.Instance.TotalTime.ToString("N") + "\n Total Clicks: " + GameInfo.Instance.TotalClicks;
            btnContinue.Text = "Continue";

            lblGrayBackground.AutoSize = false;
            lblGrayBackground.Size = new Size(this.Width / 2, this.Height / 2);
            lblGrayBackground.BackColor = Color.Gray;
            lblGrayBackground.Location = new Point(this.Width / 4, this.Height / 4);

            // Font
            lblVictoryText.TextAlign = ContentAlignment.TopCenter;
            lblVictoryTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblVictoryTitle.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Regular);
            lblVictoryText.Font = new Font(FontFamily.GenericSansSerif, 15, FontStyle.Regular);
            btnContinue.Font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular);
            lblVictoryTitle.ForeColor = lblVictoryText.ForeColor = Color.Black;

            // Position
            // Change offset to alter whitespace between Victory Labels, Title and Text
            int offsetY = 20;
            lblVictoryTitle.Location = this.GetPointAlignment(lblVictoryTitle, lblGrayBackground, 0);
            lblVictoryText.Location = this.GetPointAlignment(lblVictoryText, lblGrayBackground, lblVictoryTitle.Size.Height + offsetY);
            btnContinue.Location = this.GetPointAlignment(btnContinue, lblGrayBackground, lblVictoryText.Size.Height + offsetY + 80);
            lblGrayBackground.SendToBack();
        }

        /// <summary>
        /// Gets point directly centered in a label. The label background should be
        /// a box filled with a color to help show the text for victory labels.
        /// </summary>
        /// <param name="control">Button for continuing or labels with information</param>
        /// <param name="background">Label filled with a color to contrast the other controls</param>
        /// <param name="offY">Y axis offset for controls</param>
        /// <returns>Point directly centered in label called background</returns>
        private Point GetPointAlignment(Control control, Label background, int offY)
        {
            if (control.GetType() == typeof(Label))
            {
                control.Anchor = AnchorStyles.None;
            }

            control.AutoSize = true;
            int posX;
            int posY;
            int whitespace;

            // Set top left point to middle of gray box
            whitespace = background.Size.Width - control.Width;
            whitespace /= 2;
            posX = background.Location.X + whitespace;

            posY = background.Location.Y + (background.Size.Height / 4) + offY;

            return new Point(posX, posY);
        }

        /// <summary>
        /// Closes form.
        /// </summary>
        /// <param name="sender">An object</param>
        /// <param name="e">Empty event arguments</param>
        private void ExitForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
