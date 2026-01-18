using Pendataan_Satwa_Liar.Model.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.View
{
    public partial class FormKelolaHabitat : Form
    {
        // Events untuk Controller
        public event EventHandler BtnTambahClick;
        public event EventHandler BtnEditClick;
        public event EventHandler BtnHapusClick;
        public event EventHandler BtnRefreshClick;

        public FormKelolaHabitat()
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
            dgvHabitat.SelectionChanged += (s, e) => LoadSelectedToForm();

            // Enable/disable buttons based on selection
            dgvHabitat.SelectionChanged += (s, e) => UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvHabitat.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnHapus.Enabled = hasSelection;
        }

        // ========== PUBLIC METHODS FOR CONTROLLER ==========

        // Method untuk set data grid dengan list habitat
        public void SetDataGrid(System.Collections.IList list)
        {
            dgvHabitat.DataSource = list;
            StyleDataGridView();
            UpdateButtonStates();
        }

        // Method untuk mendapatkan input dari form
        public Habitat GetInputHabitat()
        {
            return new Habitat
            {
                NamaHabitat = txtNama.Text.Trim()
                // Tidak ada Lokasi dan Deskripsi karena tidak ada di database
            };
        }

        // Method untuk mendapatkan habitat yang dipilih di grid
        public Habitat GetSelectedHabitat()
        {
            if (dgvHabitat.CurrentRow == null || dgvHabitat.CurrentRow.Index < 0)
                return null;

            try
            {
                return new Habitat
                {
                    HabitatId = Convert.ToInt32(dgvHabitat.CurrentRow.Cells["HabitatId"].Value),
                    NamaHabitat = dgvHabitat.CurrentRow.Cells["NamaHabitat"].Value?.ToString() ?? ""
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting selected habitat: {ex.Message}");
                return null;
            }
        }

        // Method untuk memuat data terpilih ke form input
        private void LoadSelectedToForm()
        {
            var selected = GetSelectedHabitat();
            if (selected != null)
            {
                txtNama.Text = selected.NamaHabitat;
            }
        }

        // Method untuk clear input fields
        public void ClearInput()
        {
            txtNama.Clear();
            dgvHabitat.ClearSelection();
            UpdateButtonStates();
        }

        // Method untuk styling DataGridView
        private void StyleDataGridView()
        {
            if (dgvHabitat.Columns.Count == 0) return;

            // Header style
            dgvHabitat.EnableHeadersVisualStyles = false;
            dgvHabitat.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvHabitat.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHabitat.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvHabitat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHabitat.ColumnHeadersHeight = 40;

            // Row style
            dgvHabitat.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvHabitat.DefaultCellStyle.BackColor = Color.White;
            dgvHabitat.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgvHabitat.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvHabitat.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvHabitat.RowTemplate.Height = 35;

            // Alternating row color
            dgvHabitat.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Grid settings
            dgvHabitat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHabitat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHabitat.MultiSelect = false;
            dgvHabitat.ReadOnly = true;
            dgvHabitat.AllowUserToAddRows = false;
            dgvHabitat.AllowUserToDeleteRows = false;
            dgvHabitat.BackgroundColor = Color.White;
            dgvHabitat.BorderStyle = BorderStyle.None;

            // Hide ID column if exists
            if (dgvHabitat.Columns["HabitatId"] != null)
            {
                dgvHabitat.Columns["HabitatId"].Visible = false;
            }

            // Set friendly column headers
            if (dgvHabitat.Columns["NamaHabitat"] != null)
            {
                dgvHabitat.Columns["NamaHabitat"].HeaderText = "Nama Habitat";
                dgvHabitat.Columns["NamaHabitat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void FormKelolaHabitat_Load(object sender, EventArgs e)
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