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
        DataGridView dataGridViewHighScores = new DataGridView();
        MySqlDataReader reader;
        MySqlConnection conn = DatabaseManagement.Connection.GetConnection();

        public ShowHighScores()
        {
                InitializeComponent();
        }

        public void GetData()
        {
            try
            {
                dataGridViewHighScores.SetBounds(this.Location.X + 5, this.Location.Y + 5, (int)(this.Width * 0.8), (int)(this.Height * 0.8));
                conn.Open();
                reader = DatabaseManagement.Queries.GetHighScores().ExecuteReader();
                conn.Close();
                highscoreDataTable.Load(reader);
                dataGridViewHighScores.DataSource = highscoreDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
    }
}
