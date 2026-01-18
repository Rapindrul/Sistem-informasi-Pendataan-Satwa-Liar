using Pendataan_Satwa_Liar.Controller;
using Pendataan_Satwa_Liar.Model.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.View
{
    public partial class FormDataSatwa : Form
    {
        private readonly User _currentUser;

        // Events
        public event EventHandler BtnTambahClick;
        public event EventHandler BtnEditClick;
        public event EventHandler BtnHapusClick;
        public event EventHandler BtnCariClick;
        public event EventHandler BtnKelolaJenisClick;
        public event EventHandler BtnKelolaHabitatClick;

        public FormDataSatwa(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            // Wire events
            btnTambah.Click += (s, e) => BtnTambahClick?.Invoke(s, e);
            btnEdit.Click += (s, e) => BtnEditClick?.Invoke(s, e);
            btnHapus.Click += (s, e) => BtnHapusClick?.Invoke(s, e);
            btnCari.Click += (s, e) => BtnCariClick?.Invoke(s, e);
            btnKelolaJenis.Click += (s, e) => BtnKelolaJenisClick?.Invoke(s, e);
            btnKelolaHabitat.Click += (s, e) => BtnKelolaHabitatClick?.Invoke(s, e);

            this.Load += FormDataSatwa_Load;
        }

        private void FormDataSatwa_Load(object sender, EventArgs e)
        {
            // Set visibility berdasarkan role
            SetAdminMode(_currentUser.Role == "admin");
        }

        // ✅ Method untuk set data grid
        public void SetDataGridSatwa(object dataSource)
        {
            dgvSatwa.DataSource = dataSource;
            StyleDataGridView();  // ✅ Call styling
        }

        // ✅ STYLING DATAGRIDVIEW (Sama seperti FormUser)
        private void StyleDataGridView()
        {
            if (dgvSatwa.Columns.Count == 0) return;

            // Header style
            dgvSatwa.EnableHeadersVisualStyles = false;
            dgvSatwa.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185); // Blue
            dgvSatwa.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSatwa.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSatwa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSatwa.ColumnHeadersHeight = 40;

            // Row style
            dgvSatwa.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvSatwa.DefaultCellStyle.BackColor = Color.White;
            dgvSatwa.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvSatwa.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219); // Blue
            dgvSatwa.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSatwa.RowTemplate.Height = 35;

            // Alternating row color (baris selang-seling)
            dgvSatwa.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Grid settings
            dgvSatwa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSatwa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSatwa.MultiSelect = false;
            dgvSatwa.ReadOnly = true;
            dgvSatwa.AllowUserToAddRows = false;
            dgvSatwa.AllowUserToDeleteRows = false;
            dgvSatwa.BackgroundColor = Color.White;
            dgvSatwa.BorderStyle = BorderStyle.None;

            // ✅ Hide ID column (kalau ada)
            if (dgvSatwa.Columns["SatwaId"] != null)
            {
                dgvSatwa.Columns["SatwaId"].Visible = false;
            }
            if (dgvSatwa.Columns["JenisId"] != null)
            {
                dgvSatwa.Columns["JenisId"].Visible = false;
            }
            if (dgvSatwa.Columns["HabitatId"] != null)
            {
                dgvSatwa.Columns["HabitatId"].Visible = false;
            }

            // ✅ Set column headers yang lebih friendly
            if (dgvSatwa.Columns["NamaSatwa"] != null)
            {
                dgvSatwa.Columns["NamaSatwa"].HeaderText = "Nama Satwa";
                dgvSatwa.Columns["NamaSatwa"].Width = 200;
            }

            if (dgvSatwa.Columns["NamaJenis"] != null)
            {
                dgvSatwa.Columns["NamaJenis"].HeaderText = "Jenis Satwa";
                dgvSatwa.Columns["NamaJenis"].Width = 150;
            }

            if (dgvSatwa.Columns["NamaHabitat"] != null)
            {
                dgvSatwa.Columns["NamaHabitat"].HeaderText = "Habitat";
                dgvSatwa.Columns["NamaHabitat"].Width = 150;
            }

            if (dgvSatwa.Columns["Kelamin"] != null)
            {
                dgvSatwa.Columns["Kelamin"].HeaderText = "Kelamin";
                dgvSatwa.Columns["Kelamin"].Width = 100;
            }
        }

        // ✅ Method untuk hide/show button berdasarkan role
        public void SetAdminMode(bool isAdmin)
        {
            btnTambah.Visible = isAdmin;
            btnEdit.Visible = isAdmin;
            btnHapus.Visible = isAdmin;
            btnKelolaJenis.Visible = isAdmin;
            btnKelolaHabitat.Visible = isAdmin;
        }

        // ✅ Method untuk get selected satwa
        public Satwa GetSelectedSatwa()
        {
            if (dgvSatwa.CurrentRow == null || dgvSatwa.CurrentRow.Index < 0)
                return null;

            try
            {
                return new Satwa
                {
                    SatwaId = Convert.ToInt32(dgvSatwa.CurrentRow.Cells["SatwaId"].Value),
                    NamaSatwa = dgvSatwa.CurrentRow.Cells["NamaSatwa"].Value?.ToString() ?? "",
                    JenisSatwaId = Convert.ToInt32(dgvSatwa.CurrentRow.Cells["JenisId"].Value),
                    HabitatId = Convert.ToInt32(dgvSatwa.CurrentRow.Cells["HabitatId"].Value),
                    Kelamin = dgvSatwa.CurrentRow.Cells["Kelamin"].Value?.ToString() ?? "",
                    NamaJenisSatwa = dgvSatwa.CurrentRow.Cells["NamaJenis"].Value?.ToString() ?? "",
                    NamaHabitat = dgvSatwa.CurrentRow.Cells["NamaHabitat"].Value?.ToString() ?? ""
                };
            }
            catch
            {
                return null;
            }
        }

        // ✅ Method helper lainnya
        public string GetSearchText() => txtCari.Text.Trim();

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool Confirm(string message)
        {
            return MessageBox.Show(message, "Konfirmasi",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void ClearSearch()
        {
            txtCari.Clear();
        }

        private void btnKelolaHabitat_Click(object sender, EventArgs e)
        {
            var form = new FormKelolaHabitat();
            var controller = new HabitatController(form);
            form.ShowDialog();
        }

        private void btnKelolaJenis_Click(object sender, EventArgs e)
        {
            var form = new FormKelolaJenis();
            var controller = new JenisSatwaController(form);
            form.ShowDialog();
        }
    }
}
