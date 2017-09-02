using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MemoryGameImproved
{
    public partial class ShowHighScores : Form
    {
        DataTable highscoreDataTable = new DataTable();
        BindingSource highscoreSource = new BindingSource();

        public ShowHighScores()
        {
            try
            {
                InitializeComponent();
                highscoreDataTable = DatabaseManagement.Queries.GetHighScores();
                dataGridViewHighScores.DataSource = highscoreDataTable;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error code: " + ex.ErrorCode + ", " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
    }
}
