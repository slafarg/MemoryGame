namespace MemoryGameImproved
{
    partial class ShowHighScores
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
            this.dataGridViewHighScores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHighScores)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHighScores
            // 
            this.dataGridViewHighScores.AllowUserToAddRows = false;
            this.dataGridViewHighScores.AllowUserToDeleteRows = false;
            this.dataGridViewHighScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHighScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHighScores.Location = new System.Drawing.Point(37, 32);
            this.dataGridViewHighScores.Name = "dataGridViewHighScores";
            this.dataGridViewHighScores.ReadOnly = true;
            this.dataGridViewHighScores.Size = new System.Drawing.Size(892, 507);
            this.dataGridViewHighScores.TabIndex = 0;
            // 
            // ShowHighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 564);
            this.Controls.Add(this.dataGridViewHighScores);
            this.Name = "ShowHighScores";
            this.Text = "ShowHighScores";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHighScores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHighScores;
    }
}