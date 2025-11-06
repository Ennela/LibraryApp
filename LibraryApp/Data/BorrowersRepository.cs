using System;
using System.Data;
using MySql.Data.MySqlClient;
using LibraryApp.Models;

namespace LibraryApp.Data
{
    public class BorrowersRepository
    {
        private static readonly string connectionString =
            "Server=localhost;Port=3306;Database=library;Uid=root;Pwd=220055;SslMode=Disabled;AllowPublicKeyRetrieval=True;";


        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // ====== LẤY DANH SÁCH BẠN ĐỌC ======
        public static DataTable GetAll()
        {
            // CHÚ Ý: dùng 'name' đúng với bảng MySQL
            string query = "SELECT id, name, phone FROM borrowers ORDER BY id DESC";



            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // ====== THÊM ======
        public static void Insert(Borrower b)
        {
            const string query = "INSERT INTO borrowers (name, phone) VALUES (@name, @phone)";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", b.FullName);   // model dùng FullName
                    cmd.Parameters.AddWithValue("@phone", b.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ====== SỬA ======
        public static void Update(Borrower b)
        {
            const string query = "UPDATE borrowers SET name=@name, phone=@phone WHERE id=@id";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", b.Id);
                    cmd.Parameters.AddWithValue("@name", b.FullName);
                    cmd.Parameters.AddWithValue("@phone", b.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ====== XÓA ======
        public static void Delete(int id)
        {
            const string query = "DELETE FROM borrowers WHERE id=@id";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
