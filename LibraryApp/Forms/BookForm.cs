using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LibraryApp.Data;
using LibraryApp.Models;

namespace LibraryApp.Forms
{
    public class BooksForm : Form
    {
        private Label lblTitle, lblAuthor, lblGenre, lblISBN, lblQuantity, lblYear, lblSearch;
        private TextBox txtTitle, txtAuthor, txtGenre, txtISBN, txtYear, txtSearch;
        private NumericUpDown nudQuantity;
        private Button btnAdd, btnUpdate, btnDelete, btnClear;
        private DataGridView dgvBooks;
        private int? selectedBookId = null;

        public BooksForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "Quản lý sách";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(230, 240, 255);

            lblSearch = new Label { Text = "Tìm kiếm:", Location = new Point(20, 20), AutoSize = true };
            txtSearch = new TextBox { Location = new Point(100, 18), Width = 300 };
            txtSearch.TextChanged += (s, e) => LoadData(txtSearch.Text.Trim());

            dgvBooks = new DataGridView { Location = new Point(20, 50), Size = new Size(840, 250) };
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.CellClick += DgvBooks_CellClick;

            lblTitle = new Label { Text = "Tiêu đề:", Location = new Point(20, 320), AutoSize = true };
            txtTitle = new TextBox { Location = new Point(100, 318), Width = 200 };

            lblAuthor = new Label { Text = "Tác giả:", Location = new Point(340, 320), AutoSize = true };
            txtAuthor = new TextBox { Location = new Point(420, 318), Width = 200 };

            lblGenre = new Label { Text = "Thể loại:", Location = new Point(20, 360), AutoSize = true };
            txtGenre = new TextBox { Location = new Point(100, 358), Width = 200 };

            lblISBN = new Label { Text = "ISBN:", Location = new Point(340, 360), AutoSize = true };
            txtISBN = new TextBox { Location = new Point(420, 358), Width = 200 };

            lblQuantity = new Label { Text = "Số lượng:", Location = new Point(20, 400), AutoSize = true };
            nudQuantity = new NumericUpDown { Location = new Point(100, 398), Width = 100, Minimum = 0, Maximum = 1000 };

            lblYear = new Label { Text = "Năm XB:", Location = new Point(340, 400), AutoSize = true };
            txtYear = new TextBox { Location = new Point(420, 398), Width = 100 };

            btnAdd = new Button { Text = "Thêm", Location = new Point(650, 310), Size = new Size(100, 35), BackColor = Color.LightSkyBlue };
            btnAdd.Click += BtnAdd_Click;

            btnUpdate = new Button { Text = "Sửa", Location = new Point(650, 355), Size = new Size(100, 35), BackColor = Color.LightSkyBlue };
            btnUpdate.Click += BtnUpdate_Click;

            btnDelete = new Button { Text = "Xóa", Location = new Point(650, 400), Size = new Size(100, 35), BackColor = Color.LightSkyBlue };
            btnDelete.Click += BtnDelete_Click;

            btnClear = new Button { Text = "Làm mới", Location = new Point(650, 445), Size = new Size(100, 35), BackColor = Color.LightSteelBlue };
            btnClear.Click += (s, e) => ClearForm();

            this.Controls.AddRange(new Control[]
            {
                lblSearch, txtSearch, dgvBooks,
                lblTitle, txtTitle, lblAuthor, txtAuthor,
                lblGenre, txtGenre, lblISBN, txtISBN,
                lblQuantity, nudQuantity, lblYear, txtYear,
                btnAdd, btnUpdate, btnDelete, btnClear
            });
        }

        private void LoadData(string keyword = null)
        {
            dgvBooks.DataSource = BooksRepository.GetAll(keyword);
            dgvBooks.ClearSelection();
            selectedBookId = null;
        }

        private void ClearForm()
        {
            txtTitle.Text = txtAuthor.Text = txtGenre.Text = txtISBN.Text = txtYear.Text = "";
            nudQuantity.Value = 0;
            selectedBookId = null;
            dgvBooks.ClearSelection();
        }

        private void DgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBooks.Rows[e.RowIndex].Cells["id"].Value != null)
            {
                var row = dgvBooks.Rows[e.RowIndex];

                // Xử lý ID an toàn
                if (row.Cells["id"].Value != DBNull.Value)
                    selectedBookId = Convert.ToInt32(row.Cells["id"].Value);
                else
                    selectedBookId = null;

                // Gán giá trị vào các ô nhập liệu (xử lý DBNull)
                txtTitle.Text = row.Cells["title"].Value?.ToString() ?? "";
                txtAuthor.Text = row.Cells["author"].Value?.ToString() ?? "";
                txtGenre.Text = row.Cells["genre"].Value?.ToString() ?? "";
                txtISBN.Text = row.Cells["isbn"].Value?.ToString() ?? "";
                txtYear.Text = row.Cells["published_year"].Value?.ToString() ?? "";

                nudQuantity.Value = row.Cells["quantity"].Value != DBNull.Value
                    ? Convert.ToInt32(row.Cells["quantity"].Value)
                    : 0;
            }
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Tiêu đề không được để trống.");
                return;
            }

            var b = new Book
            {
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Genre = txtGenre.Text.Trim(),
                ISBN = txtISBN.Text.Trim(),
                Quantity = (int)nudQuantity.Value,
                PublishedYear = int.TryParse(txtYear.Text.Trim(), out int y) ? y : 0
            };

            BooksRepository.Insert(b);
            LoadData(txtSearch.Text);
            ClearForm();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBookId == null)
            {
                MessageBox.Show("Hãy chọn sách để sửa.");
                return;
            }

            var b = new Book
            {
                Id = selectedBookId.Value,
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Genre = txtGenre.Text.Trim(),
                ISBN = txtISBN.Text.Trim(),
                Quantity = (int)nudQuantity.Value,
                PublishedYear = int.TryParse(txtYear.Text.Trim(), out int y) ? y : 0
            };

            BooksRepository.Update(b);
            LoadData(txtSearch.Text);
            ClearForm();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookId == null)
            {
                MessageBox.Show("Hãy chọn sách để xóa.");
                return;
            }

            var result = System.Windows.Forms.MessageBox.Show("Bạn có chắc muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                BooksRepository.Delete(selectedBookId.Value);
                LoadData(txtSearch.Text);
                ClearForm();
            }

        }
    }
}
