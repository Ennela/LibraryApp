using System.Windows.Forms;

namespace LibraryApp.Forms
{
    public partial class LoansForm : Form
    {
        public LoansForm()
        {
            InitializeComponent();
        }
    }
}
﻿using System;
using System.Windows.Forms;


namespace LibraryApp
{
    public class LoansForm : Form
    {
        public LoansForm()
        {
            Text = "Mượn / Trả sách";
            Width = 600;
            Height = 400;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
