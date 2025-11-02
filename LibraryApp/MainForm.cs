using System;
using System.Windows.Forms;

namespace LibraryApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Xử lý khi nhấn nút "Quản lý Sách"
        private void btnBooks_Click(object sender, EventArgs e)
        {
            new BookForm().ShowDialog();
        }

        // Xử lý khi nhấn nút "Quản lý Bạn đọc"
        private void btnBorrowers_Click(object sender, EventArgs e)
        {
            new BorrowersForm().ShowDialog();
        }

        // Xử lý khi nhấn nút "Mượn / Trả sách"
        private void btnLoans_Click(object sender, EventArgs e)
        {
            new LoansForm().ShowDialog();
        }
    }
}
