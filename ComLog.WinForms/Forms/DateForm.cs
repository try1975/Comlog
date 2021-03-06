﻿using System;
using System.Windows.Forms;

namespace ComLog.WinForms.Forms
{
    public partial class DateForm : Form
    {
        public DateForm()
        {
            InitializeComponent();
        }

        public DateTime Date
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        public string DateText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
    }
}
