using Pendataan_Satwa_Liar.Model.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.View
{
    public partial class FormDataSatwa : Form
    {
        private readonly User _currentUser;

        public event EventHandler BtnTambahClick;
        public event EventHandler BtnEditClick;
        public event EventHandler BtnHapusClick;
        public event EventHandler BtnKelolaJenisClick;
        public event EventHandler BtnKelolaHabitatClick;
        public event EventHandler BtnCariClick;

        public FormDataSatwa(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            btnTambah.Click += (s, e) => BtnTambahClick?.Invoke(s, e);
            btnEdit.Click += (s, e) => BtnEditClick?.Invoke(s, e);
            btnHapus.Click += (s, e) => BtnHapusClick?.Invoke(s, e);

            btnKelolaJenis.Click += (s, e) => BtnKelolaJenisClick?.Invoke(s, e);
            btnKelolaHabitat.Click += (s, e) => BtnKelolaHabitatClick?.Invoke(s, e);
            btnCari.Click += (s, e) => BtnCariClick?.Invoke(s, e);

            Load += (s, e) => SetAdminMode(string.Equals(_currentUser?.Role, "admin", StringComparison.OrdinalIgnoreCase));
        }

        public void SetDataGridSatwa(object dataSource)
        {
            dgvSatwa.AutoGenerateColumns = true;
            dgvSatwa.DataSource = dataSource;
            StyleDataGridView();
        }

        public Satwa GetSelectedSatwa()
        {
            if (dgvSatwa.SelectedRows.Count == 0) return null; // [web:249]
            return dgvSatwa.SelectedRows[0].DataBoundItem as Satwa; // [web:230]
        }

        public bool Confirm(string message)
        {
            return MessageBox.Show(message, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StyleDataGridView()
        {
            if (dgvSatwa.Columns.Count == 0) return;

            dgvSatwa.EnableHeadersVisualStyles = false;
            dgvSatwa.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvSatwa.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSatwa.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSatwa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSatwa.ColumnHeadersHeight = 40;

            dgvSatwa.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvSatwa.DefaultCellStyle.BackColor = Color.White;
            dgvSatwa.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvSatwa.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvSatwa.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSatwa.RowTemplate.Height = 35;
            dgvSatwa.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dgvSatwa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSatwa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSatwa.MultiSelect = false;
            dgvSatwa.ReadOnly = true;
            dgvSatwa.AllowUserToAddRows = false;
            dgvSatwa.AllowUserToDeleteRows = false;
            dgvSatwa.BackgroundColor = Color.White;
            dgvSatwa.BorderStyle = BorderStyle.None;

            if (dgvSatwa.Columns["SatwaId"] != null) dgvSatwa.Columns["SatwaId"].Visible = false;
            if (dgvSatwa.Columns["JenisSatwaId"] != null) dgvSatwa.Columns["JenisSatwaId"].Visible = false;
            if (dgvSatwa.Columns["HabitatId"] != null) dgvSatwa.Columns["HabitatId"].Visible = false;

            if (dgvSatwa.Columns["NamaSatwa"] != null) dgvSatwa.Columns["NamaSatwa"].HeaderText = "Nama Satwa";
            if (dgvSatwa.Columns["NamaJenisSatwa"] != null) dgvSatwa.Columns["NamaJenisSatwa"].HeaderText = "Jenis Satwa";
            if (dgvSatwa.Columns["NamaHabitat"] != null) dgvSatwa.Columns["NamaHabitat"].HeaderText = "Habitat";
            if (dgvSatwa.Columns["Kelamin"] != null) dgvSatwa.Columns["Kelamin"].HeaderText = "Kelamin";
        }

        public void SetAdminMode(bool isAdmin)
        {
            btnTambah.Visible = isAdmin;
            btnEdit.Visible = isAdmin;
            btnHapus.Visible = isAdmin;
            btnKelolaJenis.Visible = isAdmin;
            btnKelolaHabitat.Visible = isAdmin;
        }

        public string GetSearchText() => txtCari.Text.Trim();
        public string GetSearchCriteria() => cmbKriteria.SelectedItem?.ToString() ?? "nama";
    }
}
