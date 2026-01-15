using System;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.View
{
    public partial class Register : Form
    {
        public event EventHandler BtnRegisterClick;
        public event EventHandler BackToLoginClick;

        public Register()
        {
            InitializeComponent();

            // Wire button events
            btnRegister.Click += (s, e) => BtnRegisterClick?.Invoke(s, e);
            btnBacktoLogin.Click += (s, e) => BackToLoginClick?.Invoke(s, e);

            // Password masking
            txtPassword.UseSystemPasswordChar = true;
            txtRePassword.UseSystemPasswordChar = true;

            // Auto focus ke username saat load
            this.Load += (s, e) => txtUsername.Focus();

            // Enter key support
            txtRePassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    BtnRegisterClick?.Invoke(s, e);
                }
            };
        }

        public string GetUsername() => txtUsername.Text.Trim();
        public string GetPassword() => txtPassword.Text;
        public string GetRePassword() => txtRePassword.Text;

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ClearInput()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtRePassword.Clear();
            txtUsername.Focus();  // Kembali ke username setelah clear
        }
    }
}
