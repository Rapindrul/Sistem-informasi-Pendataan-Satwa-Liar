
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

        public FormUser()
        {
            InitializeComponent();

            btnEdit.Click += (s, e) => BtnEditClick?.Invoke(s, e);
            btnHapus.Click += (s, e) => BtnHapusClick?.Invoke(s, e);
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
