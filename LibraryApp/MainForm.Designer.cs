namespace LibraryApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.btnBooks = new System.Windows.Forms.Button();
            this.btnBorrowers = new System.Windows.Forms.Button();
            this.btnLoans = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(110, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Phần mềm Quản lý Thư viện";
            // 
            // btnBooks
            // 
            this.btnBooks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBooks.Location = new System.Drawing.Point(150, 120);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(220, 50);
            this.btnBooks.TabIndex = 1;
            this.btnBooks.Text = "Quản lý Sách";
            this.btnBooks.UseVisualStyleBackColor = true;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // btnBorrowers
            // 
            this.btnBorrowers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBorrowers.Location = new System.Drawing.Point(150, 190);
            this.btnBorrowers.Name = "btnBorrowers";
            this.btnBorrowers.Size = new System.Drawing.Size(220, 50);
            this.btnBorrowers.TabIndex = 2;
            this.btnBorrowers.Text = "Quản lý Bạn đọc";
            this.btnBorrowers.UseVisualStyleBackColor = true;
            this.btnBorrowers.Click += new System.EventHandler(this.btnBorrowers_Click);
            // 
            // btnLoans
            // 
            this.btnLoans.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoans.Location = new System.Drawing.Point(150, 260);
            this.btnLoans.Name = "btnLoans";
            this.btnLoans.Size = new System.Drawing.Size(220, 50);
            this.btnLoans.TabIndex = 3;
            this.btnLoans.Text = "Mượn / Trả sách";
            this.btnLoans.UseVisualStyleBackColor = true;
            this.btnLoans.Click += new System.EventHandler(this.btnLoans_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 370);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnLoans);
            this.Controls.Add(this.btnBorrowers);
            this.Controls.Add(this.btnBooks);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Thư viện";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnBorrowers;
        private System.Windows.Forms.Button btnLoans;
        private System.Windows.Forms.Label lblTitle;
    }
}
