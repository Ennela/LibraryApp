using MySql.Data.MySqlClient;

namespace LibraryApp.Data
{
    public class Database
    {
        private const string ConnStr = "Server=localhost;Database=librarydb;Uid=app;Pwd=Kien2005@;SslMode=Disabled;AllowPublicKeyRetrieval=True;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnStr);
        }
    }
}
