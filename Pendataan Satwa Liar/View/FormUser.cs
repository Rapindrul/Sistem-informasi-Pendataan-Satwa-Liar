using Pendataan_Satwa_Liar.Model.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.View 
{
    public partial class FormUser : Form
    {
        public event EventHandler BtnEditClick;
        public event EventHandler BtnHapusClick;
        public event EventHandler BtnLogoutClick;
        public event EventHandler BtnResetPasswordClick;
        public event EventHandler BtnLaporClick;
        public event EventHandler BtnDataSatwaClick;

        private readonly User _currentUser;

        // Constructor utama - dipakai setelah login
        public FormUser(User currentUser)
        {
            InitializeComponent();

            _currentUser = currentUser;

            btnEdit.Click += (s, e) => BtnEditClick?.Invoke(s, e);
            btnHapus.Click += (s, e) => BtnHapusClick?.Invoke(s, e);
            btnLogout.Click += (s, e) => BtnLogoutClick?.Invoke(s, e);
            btnResetPw.Click += (s, e) => BtnResetPasswordClick?.Invoke(s, e);
            btnLapor.Click += (s, e) => BtnLaporClick?.Invoke(s, e);
            btnSatwa.Click += (s, e) => BtnDataSatwaClick?.Invoke(s, e);


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
            lblUsername.Text = $"Selamat Datang Kembali! {username}";
        }

        public void SetAdminMode(bool isAdmin)
        {
            dgvUser.Visible = isAdmin;
            btnEdit.Visible = isAdmin;
            btnHapus.Visible = isAdmin;
            btnResetPw.Visible = isAdmin;
        }

        public void SetUserGridData(object dataSource)
        {

            dgvUser.DataSource = dataSource;
            StyleDataGridView();
        }

        private void StyleDataGridView()
        {
            if (dgvUser.Columns.Count == 0) return;

            // Header style
            dgvUser.EnableHeadersVisualStyles = false;
            dgvUser.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94); // Dark gray
            dgvUser.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUser.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUser.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Row style
            dgvUser.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvUser.DefaultCellStyle.BackColor = Color.White;
            dgvUser.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvUser.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219); // Blue
            dgvUser.DefaultCellStyle.SelectionForeColor = Color.White;

            // Alternating row color
            dgvUser.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Column width
            dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Hide UserId column (kalau ada)
            if (dgvUser.Columns["UserId"] != null)
            {
                dgvUser.Columns["UserId"].Visible = false;
            }

            // Hide Password column (security!)
            if (dgvUser.Columns["Password"] != null)
            {
                dgvUser.Columns["Password"].Visible = false;  // ✅ Sembunyikan password!
            }

            // Set column headers yang lebih friendly
            if (dgvUser.Columns["Username"] != null)
                dgvUser.Columns["Username"].HeaderText = "Username";

            if (dgvUser.Columns["Role"] != null)
                dgvUser.Columns["Role"].HeaderText = "Role";
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


        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
