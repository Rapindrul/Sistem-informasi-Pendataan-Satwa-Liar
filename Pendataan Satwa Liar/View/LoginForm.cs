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

            btnLogin.Click += (s, e) => BtnLoginClick?.Invoke(s, e);
            btnRegis.Click += (s, e) => btnToRegisterClick?.Invoke(s, e);

            // kalau ada tombol/link ke register
            // btnToRegister.Click += (s, e) => BtnToRegisterClick?.Invoke(s, e);

            // opsional: password char
            // txtPassword.UseSystemPasswordChar = true;
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
        }
    }
}
