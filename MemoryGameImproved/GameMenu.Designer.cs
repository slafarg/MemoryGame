﻿namespace MemoryGameImproved
{
    /// <summary>
    /// Game Menu
    /// </summary>
    partial class GameMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnHighScores = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPlayerID = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPlayerID = new System.Windows.Forms.Label();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnCreateLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.picBoxOpening = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOpening)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(577, 353);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(97, 36);
            this.btnNewGame.TabIndex = 4;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Visible = false;
            this.btnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // btnHighScores
            // 
            this.btnHighScores.Location = new System.Drawing.Point(577, 401);
            this.btnHighScores.Name = "btnHighScores";
            this.btnHighScores.Size = new System.Drawing.Size(97, 36);
            this.btnHighScores.TabIndex = 6;
            this.btnHighScores.Text = "Show High Scores";
            this.btnHighScores.UseVisualStyleBackColor = true;
            this.btnHighScores.Visible = false;
            this.btnHighScores.Click += new System.EventHandler(this.BtnHighScores_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(577, 305);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(577, 279);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(156, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtPlayerID
            // 
            this.txtPlayerID.Location = new System.Drawing.Point(577, 235);
            this.txtPlayerID.Name = "txtPlayerID";
            this.txtPlayerID.Size = new System.Drawing.Size(156, 20);
            this.txtPlayerID.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Black;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(574, 258);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(88, 18);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password:";
            // 
            // lblPlayerID
            // 
            this.lblPlayerID.AutoSize = true;
            this.lblPlayerID.BackColor = System.Drawing.Color.Black;
            this.lblPlayerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerID.ForeColor = System.Drawing.Color.Transparent;
            this.lblPlayerID.Location = new System.Drawing.Point(574, 214);
            this.lblPlayerID.Name = "lblPlayerID";
            this.lblPlayerID.Size = new System.Drawing.Size(81, 18);
            this.lblPlayerID.TabIndex = 11;
            this.lblPlayerID.Text = "Player ID:";
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.BackColor = System.Drawing.Color.Transparent;
            this.lblDeveloper.ForeColor = System.Drawing.Color.White;
            this.lblDeveloper.Location = new System.Drawing.Point(42, 29);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(91, 152);
            this.lblDeveloper.TabIndex = 9;
            this.lblDeveloper.Text = "Created by Scot LaFargue. \r\n\r\nAll images and sound owned by their respective owne" +
    "rs. \r\nI do not claim any image or sound used in this demo.\r\n";
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(680, 353);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(97, 36);
            this.btnContinue.TabIndex = 5;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Visible = false;
            this.btnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // btnCreateLogin
            // 
            this.btnCreateLogin.Location = new System.Drawing.Point(658, 305);
            this.btnCreateLogin.Name = "btnCreateLogin";
            this.btnCreateLogin.Size = new System.Drawing.Size(75, 23);
            this.btnCreateLogin.TabIndex = 3;
            this.btnCreateLogin.Text = "Create Login";
            this.btnCreateLogin.UseVisualStyleBackColor = true;
            this.btnCreateLogin.Click += new System.EventHandler(this.BtnCreateLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(680, 401);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(97, 36);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // picBoxOpening
            // 
            this.picBoxOpening.Image = global::MemoryGameImproved.Properties.Resources.opening;
            this.picBoxOpening.Location = new System.Drawing.Point(-43, 4);
            this.picBoxOpening.Name = "picBoxOpening";
            this.picBoxOpening.Size = new System.Drawing.Size(847, 488);
            this.picBoxOpening.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxOpening.TabIndex = 10;
            this.picBoxOpening.TabStop = false;
            // 
            // GameMenu
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(804, 491);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreateLogin);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnHighScores);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtPlayerID);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblPlayerID);
            this.Controls.Add(this.lblDeveloper);
            this.Controls.Add(this.picBoxOpening);
            this.Name = "GameMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOpening)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnHighScores;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPlayerID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPlayerID;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.PictureBox picBoxOpening;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnCreateLogin;
        private System.Windows.Forms.Button btnExit;
    }
}

