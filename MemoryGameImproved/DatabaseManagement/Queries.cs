using System;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;

namespace MemoryGameImproved.DatabaseManagement
{
    public class Queries
    {
        static MySqlConnection conn = Connection.GetConnection();

        public static bool ValidateLogin(string username, string password)
        {
            try
            {
                ParseUsernameAndPassword(username, password);

                bool LoginValidated;
                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = conn,
                    CommandText = "ValidateLogin",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@userPassword", password);

                conn.Open();
                if(cmd.ExecuteReader().HasRows)
                {
                    LoginValidated = true;
                }
                else
                {
                    LoginValidated = false;
                }

                conn.Close();
                return LoginValidated;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool InsertLogin(string username, string password)
        {
            try
            {
                ParseUsernameAndPassword(username, password);

                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = conn,
                    CommandText = "InsertLogin",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@userPassword", password);

                conn.Open();

                if(cmd.ExecuteNonQuery() < 1)
                {
                    throw new Exception("Unable to insert credidentials into database.");
                }

                conn.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                if(ex.Number == 1062)
                {
                    throw new Exception("Username already exists.");
                }
                else
                {
                    throw new Exception("Error code: " + ex.Number + ", write down MySQL error code and report to supervisor if error persists.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ParseUsernameAndPassword(string name, string pass)
        {
            //Numbers correlate with constraints in MySQL database.
            if (name.Length > 10 || name.Length < 1)
            {
                throw new ArgumentOutOfRangeException("username", "Username must be between atleast 1 character and no more than 10 characters long.");
            }
            else if (!name.All(x => char.IsLetterOrDigit(x) || x.Equals('_')))
            {
                throw new ArgumentException("username", "Username must contain only letters, numbers, and underscores.");
            }
            else if (pass.Length < 1 || pass.Length > 45)
            {
                throw new ArgumentException("password", "Password must have atleast 1 character, and have no more than 45 characters.");
            }
        }

        public static void InsertHighScore(int score, DateTime date, string playerId)
        {
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = "InsertHighScore",
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@score", score);
            cmd.Parameters.AddWithValue("@gameDateTime", date);
            cmd.Parameters.AddWithValue("@playerId", playerId);
            conn.Open();

            if (cmd.ExecuteNonQuery() < 1)
            {
                throw new Exception("Unable to insert highscore into database.");
            }

            conn.Close();
        }

        public static DataTable GetHighScores()
        {
            DataTable data = new DataTable();
            MySqlDataReader reader;
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = "GetHighScores",
                CommandType = System.Data.CommandType.StoredProcedure
            };

            conn.Open();
            reader = cmd.ExecuteReader();
            data.Load(reader);
            conn.Close();

            return data;
        }
    }
}
