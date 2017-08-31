namespace MemoryGameImproved
{
    partial class CreateLoginMenu
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.btnCreateLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPlayerID = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPlayerID = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateLogin
            // 
            this.btnCreateLogin.Location = new System.Drawing.Point(61, 193);
            this.btnCreateLogin.Name = "btnCreateLogin";
            this.btnCreateLogin.Size = new System.Drawing.Size(75, 23);
            this.btnCreateLogin.TabIndex = 24;
            this.btnCreateLogin.Text = "Create Login";
            this.btnCreateLogin.UseVisualStyleBackColor = true;
            this.btnCreateLogin.Click += new System.EventHandler(this.BtnCreateLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(61, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(156, 20);
            this.txtPassword.TabIndex = 23;
            // 
            // txtPlayerID
            // 
            this.txtPlayerID.Location = new System.Drawing.Point(61, 123);
            this.txtPlayerID.Name = "txtPlayerID";
            this.txtPlayerID.Size = new System.Drawing.Size(156, 20);
            this.txtPlayerID.TabIndex = 22;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Black;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(58, 146);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(88, 18);
            this.lblPassword.TabIndex = 21;
            this.lblPassword.Text = "Password:";
            // 
            // lblPlayerID
            // 
            this.lblPlayerID.AutoSize = true;
            this.lblPlayerID.BackColor = System.Drawing.Color.Black;
            this.lblPlayerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerID.ForeColor = System.Drawing.Color.Transparent;
            this.lblPlayerID.Location = new System.Drawing.Point(58, 102);
            this.lblPlayerID.Name = "lblPlayerID";
            this.lblPlayerID.Size = new System.Drawing.Size(81, 18);
            this.lblPlayerID.TabIndex = 20;
            this.lblPlayerID.Text = "Player ID:";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(142, 193);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 36);
            this.label1.TabIndex = 26;
            this.label1.Text = "Create Login";
            // 
            // CreateLoginMenu
            // 
            this.AcceptButton = this.btnCreateLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(286, 270);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreateLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtPlayerID);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblPlayerID);
            this.Name = "CreateLoginMenu";
            this.Text = "CreateLoginMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPlayerID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPlayerID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
    }
}