using MySql.Data.MySqlClient;

namespace LibraryApp.Data
{
    public static class Database
    {
        private const string ConnectionString =
             "Server=localhost;Database=library;Uid=root;Pwd=220055;SslMode=Disabled;AllowPublicKeyRetrieval=True;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
