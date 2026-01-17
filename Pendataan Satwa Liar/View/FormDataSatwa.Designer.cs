namespace Pendataan_Satwa_Liar.View
{
    partial class FormDataSatwa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.dgvSatwa = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.NameApp = new System.Windows.Forms.Label();
            this.btnCari = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ddFilter = new System.Windows.Forms.ComboBox();
            this.btnKelolaJenis = new System.Windows.Forms.Button();
            this.btnKelolaHabitat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatwa)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari Satwa:";
            // 
            // txtCari
            // 
            this.txtCari.BackColor = System.Drawing.Color.White;
            this.txtCari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCari.Location = new System.Drawing.Point(135, 66);
            this.txtCari.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(576, 31);
            this.txtCari.TabIndex = 1;
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambah.ForeColor = System.Drawing.Color.White;
            this.btnTambah.Location = new System.Drawing.Point(14, 223);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(94, 36);
            this.btnTambah.TabIndex = 6;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Coral;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(115, 223);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 36);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Crimson;
            this.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.Location = new System.Drawing.Point(216, 223);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(94, 36);
            this.btnHapus.TabIndex = 8;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            // 
            // dgvSatwa
            // 
            this.dgvSatwa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSatwa.Location = new System.Drawing.Point(14, 269);
            this.dgvSatwa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSatwa.Name = "dgvSatwa";
            this.dgvSatwa.RowHeadersWidth = 51;
            this.dgvSatwa.RowTemplate.Height = 24;
            this.dgvSatwa.Size = new System.Drawing.Size(800, 415);
            this.dgvSatwa.TabIndex = 10;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.NameApp);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(839, 56);
            this.panelHeader.TabIndex = 11;
            // 
            // NameApp
            // 
            this.NameApp.BackColor = System.Drawing.Color.Transparent;
            this.NameApp.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameApp.ForeColor = System.Drawing.Color.White;
            this.NameApp.Location = new System.Drawing.Point(4, 0);
            this.NameApp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameApp.Name = "NameApp";
            this.NameApp.Size = new System.Drawing.Size(384, 89);
            this.NameApp.TabIndex = 7;
            this.NameApp.Text = "Data Satwa";
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.ForeColor = System.Drawing.Color.White;
            this.btnCari.Location = new System.Drawing.Point(720, 65);
            this.btnCari.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(94, 36);
            this.btnCari.TabIndex = 12;
            this.btnCari.Text = "cari";
            this.btnCari.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cari berdasarkan:";
            // 
            // ddFilter
            // 
            this.ddFilter.FormattingEnabled = true;
            this.ddFilter.Items.AddRange(new object[] {
            "Nama",
            "Habitat",
            "Jenis"});
            this.ddFilter.Location = new System.Drawing.Point(185, 102);
            this.ddFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddFilter.Name = "ddFilter";
            this.ddFilter.Size = new System.Drawing.Size(203, 33);
            this.ddFilter.TabIndex = 3;
            // 
            // btnKelolaJenis
            // 
            this.btnKelolaJenis.Location = new System.Drawing.Point(464, 223);
            this.btnKelolaJenis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKelolaJenis.Name = "btnKelolaJenis";
            this.btnKelolaJenis.Size = new System.Drawing.Size(171, 36);
            this.btnKelolaJenis.TabIndex = 13;
            this.btnKelolaJenis.Text = "Kelola jenis satwa";
            this.btnKelolaJenis.UseVisualStyleBackColor = true;
            // 
            // btnKelolaHabitat
            // 
            this.btnKelolaHabitat.Location = new System.Drawing.Point(643, 223);
            this.btnKelolaHabitat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKelolaHabitat.Name = "btnKelolaHabitat";
            this.btnKelolaHabitat.Size = new System.Drawing.Size(171, 36);
            this.btnKelolaHabitat.TabIndex = 14;
            this.btnKelolaHabitat.Text = "Kelola Habitat";
            this.btnKelolaHabitat.UseVisualStyleBackColor = true;
            // 
            // FormDataSatwa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(839, 703);
            this.Controls.Add(this.btnKelolaHabitat);
            this.Controls.Add(this.btnKelolaJenis);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.dgvSatwa);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.ddFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormDataSatwa";
            this.Text = "Form Data Satwa";
            this.Load += new System.EventHandler(this.FormDataSatwa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatwa)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dgvSatwa;
        private System.Windows.Forms.FlowLayoutPanel panelHeader;
        private System.Windows.Forms.Label NameApp;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddFilter;
        private System.Windows.Forms.Button btnKelolaJenis;
        private System.Windows.Forms.Button btnKelolaHabitat;
    }
}

