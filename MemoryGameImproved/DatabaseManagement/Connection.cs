using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MemoryGameImproved.DatabaseManagement
{
    class Connection
    {
        public static MySqlConnection GetConnection()
        {
            string connStr = "server=192.168.1.67;Database=memory_game;Persist Security Info=False;Uid=Scot;Pwd=Test1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
    }
}
