using System;
using System.Data;

namespace ThuVienApp
{
    class Program
    {
        static void Main()
        {
            var db = new DatabaseHelper();

            if (db.TestConnection())
            {
                Console.WriteLine("Ket noi MySQL thanh cong!");
            }
            else
            {
                Console.WriteLine("Ket noi MySQL that bai!");
                return;
            }

            Console.WriteLine("\nDanh sach tac gia:");
            DataTable tacGiaTable = db.ExecuteQuery("SELECT * FROM TacGia;");

            foreach (DataRow row in tacGiaTable.Rows)
            {
                Console.WriteLine($"ID: {row["MaTacGia"]} | Ten: {row["TenTacGia"]} | Nam sinh: {row["NamSinh"]} | Quoc gia: {row["QuocGia"]}");
            }

            Console.WriteLine("\nThem tac gia moi...");
            int rows = db.ExecuteNonQuery("INSERT INTO TacGia (TenTacGia, NamSinh, QuocGia) VALUES ('Test Author', 1990, 'Viet Nam');");
            Console.WriteLine($"Da them {rows} dong.");

            object count = db.ExecuteScalar("SELECT COUNT(*) FROM TacGia;");
            Console.WriteLine($"\nTong so tac gia: {count}");
        }
    }
}
