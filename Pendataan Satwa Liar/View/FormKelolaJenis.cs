using Pendataan_Satwa_Liar.Model.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.View
{
    public partial class FormKelolaJenis : Form
    {
        // Events untuk Controller
        public event EventHandler BtnTambahClick;
        public event EventHandler BtnEditClick;
        public event EventHandler BtnHapusClick;
        public event EventHandler BtnRefreshClick;

        public FormKelolaJenis()
        {
            InitializeComponent();
            InitializeEvents();
            StyleDataGridView();
        }

        private void InitializeEvents()
        {
            // Wire button events
            btnTambah.Click += (s, e) => BtnTambahClick?.Invoke(s, e);
            btnEdit.Click += (s, e) => BtnEditClick?.Invoke(s, e);
            btnHapus.Click += (s, e) => BtnHapusClick?.Invoke(s, e);
            btnRefresh.Click += (s, e) => BtnRefreshClick?.Invoke(s, e);

            // Load selected row data to form when clicked
            dgvJenisSatwa.SelectionChanged += (s, e) => LoadSelectedToForm();

            // Enable/disable buttons based on selection
            dgvJenisSatwa.SelectionChanged += (s, e) => UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvJenisSatwa.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnHapus.Enabled = hasSelection;
        }

        // ========== PUBLIC METHODS FOR CONTROLLER ==========

        // Method untuk set data grid dengan list jenis satwa
        public void SetDataGrid(System.Collections.IList list)
        {
            dgvJenisSatwa.DataSource = list;
            StyleDataGridView();
            UpdateButtonStates();
        }

        // Method untuk mendapatkan input dari form
        public JenisSatwa GetInputJenisSatwa()
        {
            return new JenisSatwa
            {
                NamaJenis = txtNama.Text.Trim()
            };
        }

        // Method untuk mendapatkan jenis satwa yang dipilih di grid
        public JenisSatwa GetSelectedJenisSatwa()
        {
            if (dgvJenisSatwa.CurrentRow == null || dgvJenisSatwa.CurrentRow.Index < 0)
                return null;

            try
            {
                return new JenisSatwa
                {
                    JenisSatwaId = Convert.ToInt32(dgvJenisSatwa.CurrentRow.Cells["JenisSatwaId"].Value),
                    NamaJenis = dgvJenisSatwa.CurrentRow.Cells["NamaJenis"].Value?.ToString() ?? ""
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting selected jenis satwa: {ex.Message}");
                return null;
            }
        }

        // Method untuk memuat data terpilih ke form input
        private void LoadSelectedToForm()
        {
            var selected = GetSelectedJenisSatwa();
            if (selected != null)
            {
                txtNama.Text = selected.NamaJenis;
            }
        }

        // Method untuk clear input fields
        public void ClearInput()
        {
            txtNama.Clear();
            dgvJenisSatwa.ClearSelection();
            UpdateButtonStates();
        }

        // Method untuk styling DataGridView
        private void StyleDataGridView()
        {
            if (dgvJenisSatwa.Columns.Count == 0) return;

            // Header style
            dgvJenisSatwa.EnableHeadersVisualStyles = false;
            dgvJenisSatwa.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvJenisSatwa.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvJenisSatwa.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvJenisSatwa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvJenisSatwa.ColumnHeadersHeight = 40;

            // Row style
            dgvJenisSatwa.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvJenisSatwa.DefaultCellStyle.BackColor = Color.White;
            dgvJenisSatwa.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvJenisSatwa.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvJenisSatwa.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvJenisSatwa.RowTemplate.Height = 35;

            // Alternating row color
            dgvJenisSatwa.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Grid settings
            dgvJenisSatwa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvJenisSatwa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJenisSatwa.MultiSelect = false;
            dgvJenisSatwa.ReadOnly = true;
            dgvJenisSatwa.AllowUserToAddRows = false;
            dgvJenisSatwa.AllowUserToDeleteRows = false;
            dgvJenisSatwa.BackgroundColor = Color.White;
            dgvJenisSatwa.BorderStyle = BorderStyle.None;

            // Hide ID column if exists
            if (dgvJenisSatwa.Columns["JenisSatwaId"] != null)
            {
                dgvJenisSatwa.Columns["JenisSatwaId"].Visible = false;
            }

            // Set friendly column headers
            if (dgvJenisSatwa.Columns["NamaJenis"] != null)
            {
                dgvJenisSatwa.Columns["NamaJenis"].HeaderText = "Nama Jenis Satwa";
                dgvJenisSatwa.Columns["NamaJenis"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void FormKelolaJenisSatwa_Load(object sender, EventArgs e)
        {
            // Set initial button states
            UpdateButtonStates();

            // Focus ke input pertama
            txtNama.Focus();
        }

        // Event untuk Enter key pada textbox
        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && btnTambah.Enabled)
            {
                e.Handled = true;
                BtnTambahClick?.Invoke(sender, e);
            }
        }
    }
}