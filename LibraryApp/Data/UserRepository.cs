using LibraryApp.Models;
using MySql.Data.MySqlClient;

namespace LibraryApp.Data
{
    public static class UsersRepository
    {
        public static User Authenticate(string username, string password)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = @"
                SELECT id, username, password_hash, full_name, role, is_active
                FROM users
                WHERE username = @username AND password_hash = SHA2(@password, 256) AND is_active = 1
            ";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    PasswordHash = reader.GetString("password_hash"),
                    FullName = reader.GetString("full_name"),
                    Role = reader.GetString("role"),
                    IsActive = reader.GetBoolean("is_active")
                };
            }

            return null;
        }
    }
}
