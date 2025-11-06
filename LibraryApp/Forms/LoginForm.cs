using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryApp.Data;

namespace LibraryApp.Forms
{
    public class LoginForm : Form
    {
        private TextBox txtUsername, txtPassword;
        private CheckBox chkRemember;
        private Button btnLogin;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Đăng nhập";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            Label lblTitle = new Label
            {
                Text = "Library Management System",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(70, 30),
                AutoSize = true
            };

            Label lblUsername = new Label { Text = "Username", Location = new Point(50, 90) };
            txtUsername = new TextBox { Location = new Point(50, 110), Width = 280 };

            Label lblPassword = new Label { Text = "Password", Location = new Point(50, 150) };
            txtPassword = new TextBox { Location = new Point(50, 170), Width = 280, UseSystemPasswordChar = true };

            chkRemember = new CheckBox { Text = "Remember me", Location = new Point(50, 200) };

            btnLogin = new Button
            {
                Text = "Log in",
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                Location = new Point(50, 240),
                Size = new Size(280, 35)
            };
            btnLogin.Click += BtnLogin_Click;

            this.Controls.AddRange(new Control[] {
                lblTitle, lblUsername, txtUsername,
                lblPassword, txtPassword, chkRemember, btnLogin
            });
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            var user = UsersRepository.Authenticate(username, password);
            if (user != null)
            {
                MessageBox.Show($"Xin chào {user.FullName}!", "Đăng nhập thành công");

                this.Hide();
                var mainForm = new MainForm();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
