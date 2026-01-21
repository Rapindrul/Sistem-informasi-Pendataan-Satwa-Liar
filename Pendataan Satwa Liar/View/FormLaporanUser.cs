using System;
using System.Windows.Forms;
using Pendataan_Satwa_Liar.Model.Entities;

namespace Pendataan_Satwa_Liar.View
{
    public partial class FormLaporanUser: Form
    {
        private readonly User _currentUser;

        public FormLaporanUser(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            // Setup UI
            this.BackColor = System.Drawing.Color.White;

            Label lblTitle = new Label
            {
                Text = "LAPORAN SATWA - USER",
                Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            Label lblInfo = new Label
            {
                Text = "Form untuk user melaporkan satwa yang ditemukan.\n(Coming soon...)",
                Location = new System.Drawing.Point(20, 70),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblInfo);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.NameApp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.NameApp);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(682, 61);
            this.panelHeader.TabIndex = 14;
            // 
            // NameApp
            // 
            this.NameApp.BackColor = System.Drawing.Color.Transparent;
            this.NameApp.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameApp.ForeColor = System.Drawing.Color.White;
            this.NameApp.Location = new System.Drawing.Point(4, 0);
            this.NameApp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameApp.Name = "NameApp";
            this.NameApp.Size = new System.Drawing.Size(432, 57);
            this.NameApp.TabIndex = 7;
            this.NameApp.Text = "Kelola Laporan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Laporan anda";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(657, 359);
            this.dataGridView1.TabIndex = 16;
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambah.ForeColor = System.Drawing.Color.White;
            this.btnTambah.Location = new System.Drawing.Point(309, 83);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(158, 36);
            this.btnTambah.TabIndex = 21;
            this.btnTambah.Text = "Buat Laporan";
            this.btnTambah.UseVisualStyleBackColor = false;
            // 
            // btnBatal
            // 
            this.btnBatal.BackColor = System.Drawing.Color.Crimson;
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Location = new System.Drawing.Point(576, 83);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(94, 36);
            this.btnBatal.TabIndex = 23;
            this.btnBatal.Text = "Batalkan";
            this.btnBatal.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Coral;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(475, 83);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 36);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // FormLaporanUser
            // 
            this.ClientSize = new System.Drawing.Size(682, 498);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.Name = "FormLaporanUser";
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
