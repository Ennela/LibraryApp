using System;
using System.Data;
using System.Windows.Forms;
using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Forms
{
    public partial class BorrowersForm : Form
    {
        private int? selectedId = null;

        public BorrowersForm()
        {
            InitializeComponent();
            LoadData();
        }

        //  Load dữ liệu từ MySQL
        private void LoadData()
        {
            try
            {
                dgvBorrowers.DataSource = BorrowersRepository.GetAll();
                dgvBorrowers.Columns["id"].HeaderText = "Mã độc giả";
                dgvBorrowers.Columns["full_name"].HeaderText = "Họ tên";
                dgvBorrowers.Columns["phone"].HeaderText = "Số điện thoại";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Làm sạch ô nhập
        private void ClearInputs()
        {
            txtName.Clear();
            txtPhone.Clear();
            selectedId = null;
        }

        //  Khi chọn 1 dòng
        private void dgvBorrowers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvBorrowers.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["id"].Value);
                txtName.Text = row.Cells["full_name"].Value.ToString();
                txtPhone.Text = row.Cells["phone"].Value.ToString();
            }
        }

        // Nút Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var b = new Borrower
            {
                FullName = txtName.Text,
                Phone = txtPhone.Text
            };

            BorrowersRepository.Insert(b);
            LoadData();
            ClearInputs();
        }

        // Nút Sửa
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Hãy chọn một độc giả để sửa.");
                return;
            }

            var b = new Borrower
            {
                Id = selectedId.Value,
                FullName = txtName.Text,
                Phone = txtPhone.Text
            };

            BorrowersRepository.Update(b);
            LoadData();
            ClearInputs();
        }

        //  Nút Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Hãy chọn độc giả để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa độc giả này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BorrowersRepository.Delete(selectedId.Value);
                LoadData();
                ClearInputs();
            }
        }

        //  Nút Làm mới
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }
    }
}
