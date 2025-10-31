using LibraryApp.Forms;
using System;
using System.Windows.Forms;


namespace LibraryApp
{
    public partial class MainForm : Form
    {
        private Button btnBooks;
        private Button btnBorrowers;
        private Button btnLoans;


        public MainForm()
        {
            InitializeComponents();
        }


        private void InitializeComponents()
        {
            this.Text = "Phần mềm Quản lý Thư viện";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 400;
            this.Height = 250;


            btnBooks = new Button
            {
                Text = "Quản lý Sách",
                Width = 200,
                Height = 40,
                Top = 30,
                Left = 100
            };
            btnBooks.Click += (s, e) => new BooksForm().ShowDialog();


            btnBorrowers = new Button
            {
                Text = "Quản lý Bạn đọc",
                Width = 200,
                Height = 40,
                Top = 80,
                Left = 100
            };
            btnBorrowers.Click += (s, e) => new BorrowersForm().ShowDialog();


            btnLoans = new Button
            {
                Text = "Mượn / Trả sách",
                Width = 200,
                Height = 40,
                Top = 130,
                Left = 100
            };
            btnLoans.Click += (s, e) => new LoansForm().ShowDialog();


            this.Controls.AddRange(new Control[] { btnBooks, btnBorrowers, btnLoans });
        }
    }
}