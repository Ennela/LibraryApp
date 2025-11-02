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

        // ================== NẠP DỮ LIỆU ==================
        private void LoadData()
        {
            dgvBorrowers.DataSource = BorrowersRepository.GetAll();
            dgvBorrowers.ClearSelection();

            // Đặt lại tên cột hiển thị
            if (dgvBorrowers.Columns.Contains("id"))
                dgvBorrowers.Columns["id"].HeaderText = "Mã bạn đọc";
            if (dgvBorrowers.Columns.Contains("name"))
                dgvBorrowers.Columns["name"].HeaderText = "Tên bạn đọc";
            if (dgvBorrowers.Columns.Contains("phone"))
                dgvBorrowers.Columns["phone"].HeaderText = "Số điện thoại";
        }

        // ================== THÊM ==================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên bạn đọc không được để trống!");
                return;
            }

            Borrower b = new Borrower
            {
                FullName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim()
            };

            BorrowersRepository.Insert(b);
            LoadData();
            ClearForm();
        }

        // ================== SỬA ==================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Hãy chọn bạn đọc để sửa!");
                return;
            }

            Borrower b = new Borrower
            {
                Id = selectedId.Value,
                FullName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim()
            };

            BorrowersRepository.Update(b);
            LoadData();
            ClearForm();
        }

        // ================== XÓA ==================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Hãy chọn bạn đọc để xóa!");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa bạn đọc này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    BorrowersRepository.Delete(selectedId.Value);
                    LoadData();
                    ClearForm();
                }
                catch
                {
                    MessageBox.Show("Không thể xóa bạn đọc này (có thể đang mượn sách).");
                }
            }
        }

        // ================== CLICK VÀO BẢNG ==================
        private void dgvBorrowers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvBorrowers.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["id"].Value);
                txtName.Text = row.Cells["name"].Value.ToString();
                txtPhone.Text = row.Cells["phone"].Value.ToString();
            }
        }

        // ================== LÀM MỚI FORM ==================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            selectedId = null;
            dgvBorrowers.ClearSelection();
        }
    }
}
