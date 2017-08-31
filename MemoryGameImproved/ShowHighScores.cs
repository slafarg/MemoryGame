﻿using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MemoryGameImproved
{
    public partial class ShowHighScores : Form
    {
        DataTable highscoreDataTable = new DataTable();
        BindingSource highscoreSource = new BindingSource();
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
                MySqlCommand cmd = DatabaseManagement.Queries.GetHighScores();
                cmd.Connection = conn;
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(highscoreDataTable);
                conn.Close();
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