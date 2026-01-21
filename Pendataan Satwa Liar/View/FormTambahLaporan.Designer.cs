namespace Pendataan_Satwa_Liar.View
{
    partial class FormTambahLaporan
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
            this.panelHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.NameApp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.txtSatwa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.NameApp);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(5, 11, 5, 11);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(512, 58);
            this.panelHeader.TabIndex = 14;
            // 
            // NameApp
            // 
            this.NameApp.BackColor = System.Drawing.Color.Transparent;
            this.NameApp.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameApp.ForeColor = System.Drawing.Color.White;
            this.NameApp.Location = new System.Drawing.Point(5, 0);
            this.NameApp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.NameApp.Name = "NameApp";
            this.NameApp.Size = new System.Drawing.Size(540, 58);
            this.NameApp.TabIndex = 7;
            this.NameApp.Text = "Buat Laporan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Deskripsi:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 31);
            this.label2.TabIndex = 17;
            this.label2.Text = "Lokasi:";
            // 
            // txtLokasi
            // 
            this.txtLokasi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLokasi.Location = new System.Drawing.Point(130, 289);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(354, 31);
            this.txtLokasi.TabIndex = 18;
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambah.ForeColor = System.Drawing.Color.White;
            this.btnTambah.Location = new System.Drawing.Point(390, 328);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(94, 36);
            this.btnTambah.TabIndex = 21;
            this.btnTambah.Text = "Buat!";
            this.btnTambah.UseVisualStyleBackColor = false;
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeskripsi.Location = new System.Drawing.Point(130, 135);
            this.txtDeskripsi.Multiline = true;
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(354, 145);
            this.txtDeskripsi.TabIndex = 22;
            // 
            // txtSatwa
            // 
            this.txtSatwa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSatwa.Location = new System.Drawing.Point(130, 92);
            this.txtSatwa.Name = "txtSatwa";
            this.txtSatwa.Size = new System.Drawing.Size(354, 31);
            this.txtSatwa.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 31);
            this.label3.TabIndex = 24;
            this.label3.Text = "Satwa:";
            // 
            // FormTambahLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(512, 375);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSatwa);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.txtLokasi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormTambahLaporan";
            this.Text = "FormLaporanUser";
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelHeader;
        private System.Windows.Forms.Label NameApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.TextBox txtSatwa;
        private System.Windows.Forms.Label label3;
    }
}