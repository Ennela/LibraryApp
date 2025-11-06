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
        private Button btnLogout;
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide(); // Ẩn MainForm
                var loginForm = new LoginForm();
                loginForm.ShowDialog(); // Mở lại form đăng nhập
                this.Close(); // Đóng MainForm khi LoginForm bị đóng
            }
        }


        public MainForm()
        {
            InitializeComponents();
        }

        private void Logout()
        {
            this.Hide();
            new LoginForm().ShowDialog();
            this.Close();
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

            btnLogout = new Button
            {
                Text = "Đăng xuất",
                Location = new System.Drawing.Point(250, 180),
                Size = new System.Drawing.Size(100, 30),
                BackColor = System.Drawing.Color.LightCoral,
                ForeColor = System.Drawing.Color.White
            };
            btnLogout.Click += BtnLogout_Click;

            this.Controls.AddRange(new Control[]
            {
                btnBooks,
                btnBorrowers,
                btnLoans,
                btnLogout
             });
        }

    }
}