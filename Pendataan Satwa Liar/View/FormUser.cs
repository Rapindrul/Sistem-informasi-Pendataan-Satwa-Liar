using System;
using System.Windows.Forms;
using Pendataan_Satwa_Liar.Model.Entities;

namespace Pendataan_Satwa_Liar.View  // ✅ Fix namespace
{
    public partial class FormUser : Form
    {
        public event EventHandler BtnEditClick;
        public event EventHandler BtnHapusClick;

        private readonly User _currentUser;

        // Constructor utama - dipakai setelah login
        public FormUser(User currentUser)
        {
            InitializeComponent();

            _currentUser = currentUser;

            btnEdit.Click += (s, e) => BtnEditClick?.Invoke(s, e);
            btnHapus.Click += (s, e) => BtnHapusClick?.Invoke(s, e);

            this.Load += FormUser_Load;
        }

        // Constructor default untuk Form Designer
        public FormUser() : this(new User())
        {
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            SetUsername(_currentUser.Username);

            // Atur tampilan berdasar role
            bool isAdmin = _currentUser.Role == "admin";
            SetAdminMode(isAdmin);
        }

        public void SetUsername(string username)
        {
            lblUsername.Text = $"User: {username}";
        }

        public void SetAdminMode(bool isAdmin)
        {
            dgvUser.Visible = isAdmin;
            btnEdit.Visible = isAdmin;
            btnHapus.Visible = isAdmin;
        }

        public void SetUserGridData(object dataSource)
        {
            dgvUser.DataSource = dataSource;
        }

        public User GetSelectedUser()
        {
            if (dgvUser.CurrentRow == null || dgvUser.CurrentRow.Index < 0)
                return null;

            try
            {
                return new User
                {
                    UserId = Convert.ToInt32(dgvUser.CurrentRow.Cells["UserId"].Value),
                    Username = dgvUser.CurrentRow.Cells["Username"].Value?.ToString() ?? "",
                    Password = dgvUser.CurrentRow.Cells["Password"].Value?.ToString() ?? "",
                    Role = dgvUser.CurrentRow.Cells["Role"].Value?.ToString() ?? "user"
                };
            }
            catch
            {
                return null;
            }
        }

        public bool Confirm(string message)
        {
            return MessageBox.Show(message, "Konfirmasi",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
