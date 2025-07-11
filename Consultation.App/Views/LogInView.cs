﻿using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultation.App.Views
{
    public partial class LogInView : SfForm
    {
        public LogInView()
        {
            InitializeComponent();
            this.AllowRoundedCorners = true;
            SignInTextBox.TextChanged += SignInTextBox_TextChanged;
            PasswordTextBoxV2.TextChanged += PasswordTextBoxV2_TextChanged;
        }

        private void Log_In_Load(object sender, EventArgs e)
        {

        }

        private bool PasswordVisible = false;
        private const string LePassword = "admin";
        private bool EmailIsValid(string email)

        {
            return Regex.IsMatch(email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase);
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            string email = SignInTextBox.Text.Trim();
            string password = PasswordTextBoxV2.Text.Trim();

            bool Valid = true;

            resultlabel1.Text = "";
            ErrorPassLabel.Text = "";

            if (string.IsNullOrWhiteSpace(email))
            {
                resultlabel1.Text = "Please enter your Email";
                resultlabel1.ForeColor = Color.Red;
                SignInTextBox.Clear();
                Valid = false;
            }

            if (string.IsNullOrEmpty(password))
            {
                ErrorPassLabel.Text = "Please Enter your Password";
                ErrorPassLabel.ForeColor = Color.Red;
                PasswordTextBoxV2.Clear();
                Valid = false;
            }

            if (!string.IsNullOrWhiteSpace(email) && !EmailIsValid(email))
            {
                SignInTextBox.Clear();

                resultlabel1.Text = "Invalid Email, Please try again.";
                resultlabel1.ForeColor = Color.Red;
                Valid = false;
            }

            if (!string.IsNullOrWhiteSpace(password) && password != LePassword)
            {
                PasswordTextBoxV2.Clear();

                ErrorPassLabel.Text = "Incorrect Password";
                ErrorPassLabel.ForeColor = Color.Red;
                Valid = false;
            }

            if (Valid)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SignInTextBox_TextChanged(object sender, EventArgs e)
        {
            resultlabel1.Text = "";
        }

        private void PasswordTextBoxV2_TextChanged(object sender, EventArgs e)
        {
            ErrorPassLabel.Text = "";
        }

        private void ShowPassButton_Click(object sender, EventArgs e)
        {
            PasswordVisible = !PasswordVisible;
            PasswordTextBoxV2.UseSystemPasswordChar = !PasswordVisible;
        }
    }
}
