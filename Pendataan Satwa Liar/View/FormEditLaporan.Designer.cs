namespace Pendataan_Satwa_Liar.View
{
    partial class FormEditLaporan
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtSatwa = new System.Windows.Forms.TextBox();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panelHeader.TabIndex = 25;
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
            this.NameApp.Text = "Edit Laporan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 31);
            this.label3.TabIndex = 32;
            this.label3.Text = "Satwa:";
            // 
            // txtSatwa
            // 
            this.txtSatwa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSatwa.Location = new System.Drawing.Point(131, 73);
            this.txtSatwa.Name = "txtSatwa";
            this.txtSatwa.Size = new System.Drawing.Size(354, 22);
            this.txtSatwa.TabIndex = 31;
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeskripsi.Location = new System.Drawing.Point(131, 116);
            this.txtDeskripsi.Multiline = true;
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(354, 145);
            this.txtDeskripsi.TabIndex = 30;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(391, 309);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 36);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // txtLokasi
            // 
            this.txtLokasi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLokasi.Location = new System.Drawing.Point(131, 270);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(354, 22);
            this.txtLokasi.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 31);
            this.label2.TabIndex = 27;
            this.label2.Text = "Lokasi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 31);
            this.label1.TabIndex = 26;
            this.label1.Text = "Deskripsi:";
            // 
            // FormEditLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 375);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSatwa);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtLokasi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormEditLaporan";
            this.Text = "FormEditLaporan";
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelHeader;
        private System.Windows.Forms.Label NameApp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSatwa;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}