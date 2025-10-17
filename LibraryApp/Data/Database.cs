using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibraryApp.Data
{
    public class Database
    {
        private const string ConnStr = "Server=localhost;Database=librarydb;Uid=app;Pwd=Kien2005@;SslMode=None;AllowPublicKeyRetrieval=True;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnStr);
        }
    }
}

