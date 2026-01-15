using System;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.View
{
    public partial class LoginForm : Form
    {
        public event EventHandler BtnLoginClick;
        public event EventHandler btnToRegisterClick;

        public LoginForm()
        {
            InitializeComponent();

            // Wire button events
            btnLogin.Click += (s, e) => BtnLoginClick?.Invoke(s, e);
            btnRegis.Click += (s, e) => btnToRegisterClick?.Invoke(s, e);

            // Password masking
            txtPassword.UseSystemPasswordChar = true;

            // Auto focus ke username saat load
            this.Load += (s, e) => txtUsername.Focus();

            // Enter key support - tekan Enter di password = login
            txtPassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    BtnLoginClick?.Invoke(s, e);
                }
            };
        }

        public string GetUsername() => txtUsername.Text.Trim();
        public string GetPassword() => txtPassword.Text;

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ClearInput()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();  // Kembali ke username setelah clear
        }
    }
}
