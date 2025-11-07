namespace LibraryApp.Forms
{
    partial class BorrowersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtPhone = new TextBox();
            dgvBorrowers = new DataGridView();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            lblName = new Label();
            lblPhone = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBorrowers).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(255, 192, 255);
            txtName.Location = new Point(120, 300);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 23);
            txtName.TabIndex = 0;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(255, 192, 255);
            txtPhone.Location = new Point(420, 300);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(180, 23);
            txtPhone.TabIndex = 1;
            // 
            // dgvBorrowers
            // 
            dgvBorrowers.BackgroundColor = Color.FromArgb(255, 192, 255);
            dgvBorrowers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBorrowers.Location = new Point(20, 20);
            dgvBorrowers.Name = "dgvBorrowers";
            dgvBorrowers.Size = new Size(760, 250);
            dgvBorrowers.TabIndex = 2;
            dgvBorrowers.CellClick += dgvBorrowers_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(255, 128, 255);
            btnAdd.ForeColor = Color.Green;
            btnAdd.Location = new Point(120, 360);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 30);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Lime;
            btnUpdate.ForeColor = Color.Navy;
            btnUpdate.Location = new Point(250, 360);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 30);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.CornflowerBlue;
            btnDelete.ForeColor = Color.Maroon;
            btnDelete.Location = new Point(380, 360);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 30);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Coral;
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(510, 360);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(60, 303);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 15);
            lblName.TabIndex = 7;
            lblName.Text = "Họ tên:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.ForeColor = Color.Purple;
            lblPhone.Location = new Point(340, 303);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(79, 15);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Số điện thoại:";
            // 
            // BorrowersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(lblPhone);
            Controls.Add(lblName);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgvBorrowers);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            ForeColor = Color.CornflowerBlue;
            Name = "BorrowersForm";
            Text = "Quản lý bạn đọc";
            Load += BorrowersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBorrowers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        private void BorrowersForm_Load(object? sender, EventArgs e)
        {
            LoadData();
        }
        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            btnClear_Click(sender!, e);
        }


        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DataGridView dgvBorrowers;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
    }
}
