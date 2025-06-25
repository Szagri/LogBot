using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverlayWidgetApp.Services;

namespace OverlayWidgetApp
{
    public partial class RegistrationForm : Form
    {
        private readonly UserDataService _user;
        private int originalFormHeight;
        private Point originalButtonLocation;

        public RegistrationForm(UserDataService user)
        {
            InitializeComponent();
            _user = user;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            originalFormHeight = this.Height;
            originalButtonLocation = this.ConfirmBtn.Location;
            this.ErrorLBL.Visible = false;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            string login = this.LoginTXB.Text.Trim();
            string password = this.PasswordTXB.Text.Trim();

            Validate(login, password);

            if (!this.ErrorLBL.Visible)
            {
                DateTime date = DateTime.MinValue;
                try
                {
                    _user.Update(login, password, date);
                    _user.Save();

                    MessageBox.Show("Zmiana hasła zakończona sukcesem!", "Zapisany", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas zapisu danych: {ex.Message}", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Close();
                    this.Dispose();
                }
            }
        }

        private void Validate(string login, string password)
        {
            bool hasError = false;
            LoginTXB.BackColor = SystemColors.Window;
            PasswordTXB.BackColor = SystemColors.Window;

            if (string.IsNullOrWhiteSpace(login) && string.IsNullOrWhiteSpace(password))
            {
                ErrorLBL.Text = "Podaj login i hasło";
                hasError = true;
                LoginTXB.BackColor = Color.MistyRose;
                PasswordTXB.BackColor = Color.MistyRose;
            }
            else if (string.IsNullOrWhiteSpace(login))
            {
                ErrorLBL.Text = "Podaj login";
                hasError = true;
                LoginTXB.BackColor = Color.MistyRose;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                ErrorLBL.Text = "Podaj hasło";
                hasError = true;
                PasswordTXB.BackColor = Color.MistyRose;
            }

            ErrorLBL.Visible = hasError;

            if (hasError)
            {
                if (this.Height == originalFormHeight)
                {
                    this.Height += ErrorLBL.Height + 10;
                    this.ConfirmBtn.Location = new Point(ConfirmBtn.Location.X, ConfirmBtn.Location.Y + 20);
                }
            }
            else
            {
                this.Height = originalFormHeight;
                this.ConfirmBtn.Location = originalButtonLocation;
            }
        }
    }
}
