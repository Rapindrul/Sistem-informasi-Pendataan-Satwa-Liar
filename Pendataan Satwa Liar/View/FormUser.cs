
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;

namespace Pendataan_Satwa_Liar
{
    public partial class FormUser : Form
    {
        public event EventHandler BtnEditClick;
        public event EventHandler BtnHapusClick;

        private readonly User _currentUser;

        // constructor baru untuk dipakai setelah login
        public FormUser(User currentUser)
        {
            InitializeComponent();

            _currentUser = currentUser;

            btnEdit.Click += (s, e) => BtnEditClick?.Invoke(s, e);
            btnHapus.Click += (s, e) => BtnHapusClick?.Invoke(s, e);
        }

        // kalau constructor tanpa parameter masih mau dipakai designer:
        public FormUser() : this(new User())
        {
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            SetUsername(_currentUser.Username);

            // contoh atur tampilan berdasar role
            bool isAdmin = _currentUser.Role == "admin";
            SetAdminMode(isAdmin);
        }

        public void SetUsername(string username)
        {
            lblUsername.Text = username;
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
            if (dgvUser.CurrentRow == null) return null;

            return new User
            {
                UserId = (int)dgvUser.CurrentRow.Cells["UserId"].Value,
                Username = dgvUser.CurrentRow.Cells["Username"].Value.ToString(),
                Password = dgvUser.CurrentRow.Cells["Password"].Value.ToString(),
                Role = dgvUser.CurrentRow.Cells["Role"].Value.ToString()
            };
        }

        public bool Confirm(string message)
        {
            return MessageBox.Show(message, "Konfirmasi",
                   MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
    }


}
