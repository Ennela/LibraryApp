using System.Data;
using LibraryApp.Models;
using MySql.Data.MySqlClient;

namespace LibraryApp.Data
{
    public static class BooksRepository
    {
        public static DataTable GetAll(string keyword = null)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = @"SELECT id, title, author, genre, isbn, quantity, published_year
                           FROM books";
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql += @" WHERE title LIKE CONCAT('%', @kw, '%')
                          OR author LIKE CONCAT('%', @kw, '%')
                          OR isbn LIKE CONCAT('%', @kw, '%')";
            }

            using var cmd = new MySqlCommand(sql, conn);
            if (!string.IsNullOrWhiteSpace(keyword))
                cmd.Parameters.AddWithValue("@kw", keyword.Trim());

            using var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void Insert(Book b)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            string sql = @"INSERT INTO books (title, author, genre, isbn, quantity, published_year)
                           VALUES (@title, @auth, @genre, @isbn, @qty, @year)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@title", b.Title);
            cmd.Parameters.AddWithValue("@auth", b.Author);
            cmd.Parameters.AddWithValue("@genre", b.Genre);
            cmd.Parameters.AddWithValue("@isbn", b.ISBN);
            cmd.Parameters.AddWithValue("@qty", b.Quantity);
            cmd.Parameters.AddWithValue("@year", b.PublishedYear);
            cmd.ExecuteNonQuery();
        }

        public static void Update(Book b)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            string sql = @"UPDATE books
                           SET title=@title, author=@auth, genre=@genre, isbn=@isbn,
                               quantity=@qty, published_year=@year
                           WHERE id=@id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", b.Id);
            cmd.Parameters.AddWithValue("@title", b.Title);
            cmd.Parameters.AddWithValue("@auth", b.Author);
            cmd.Parameters.AddWithValue("@genre", b.Genre);
            cmd.Parameters.AddWithValue("@isbn", b.ISBN);
            cmd.Parameters.AddWithValue("@qty", b.Quantity);
            cmd.Parameters.AddWithValue("@year", b.PublishedYear);
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            string sql = "DELETE FROM books WHERE id=@id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
