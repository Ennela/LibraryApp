using System;
using System.Data;
using MySql.Data.MySqlClient;
using LibraryApp.Models;

namespace LibraryApp.Data
{
    public static class BorrowersRepository
    {
        public static DataTable GetAll()
        {
            using var conn = Database.GetConnection();
            conn.Open();
            string sql = "SELECT id, full_name, phone FROM borrowers";
            using var cmd = new MySqlCommand(sql, conn);
            using var adapter = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static void Insert(Borrower b)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            string sql = "INSERT INTO borrowers (full_name, phone) VALUES (@name, @phone)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", b.FullName);
            cmd.Parameters.AddWithValue("@phone", b.Phone);
            cmd.ExecuteNonQuery();
        }

        public static void Update(Borrower b)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            string sql = "UPDATE borrowers SET full_name = @name, phone = @phone WHERE id = @id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", b.FullName);
            cmd.Parameters.AddWithValue("@phone", b.Phone);
            cmd.Parameters.AddWithValue("@id", b.Id);
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            string sql = "DELETE FROM borrowers WHERE id = @id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
