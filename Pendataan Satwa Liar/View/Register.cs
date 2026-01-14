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

            btnRegister.Click += (s, e) => BtnRegisterClick?.Invoke(s, e);
            btnBacktoLogin.Click += (s, e) => BackToLoginClick?.Invoke(s, e);
            // optional:
            // txtPassword.UseSystemPasswordChar = true;
            // txtRePassword.UseSystemPasswordChar = true;
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
        }

        private void txt_Load(object sender, EventArgs e)
        {

        }
    }
}
