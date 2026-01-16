namespace Pendataan_Satwa_Liar
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
            this.tbSatwa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbJenisSatwa = new System.Windows.Forms.ComboBox();
            this.cbHabitat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.dataGridViewSatwa = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.NameApp = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSatwa)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari Satwa:";
            // 
            // tbSatwa
            // 
            this.tbSatwa.Location = new System.Drawing.Point(132, 61);
            this.tbSatwa.Name = "tbSatwa";
            this.tbSatwa.Size = new System.Drawing.Size(438, 22);
            this.tbSatwa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(940, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jenis Satwa :";
            // 
            // cbJenisSatwa
            // 
            this.cbJenisSatwa.FormattingEnabled = true;
            this.cbJenisSatwa.Items.AddRange(new object[] {
            "primata"});
            this.cbJenisSatwa.Location = new System.Drawing.Point(1081, 349);
            this.cbJenisSatwa.Name = "cbJenisSatwa";
            this.cbJenisSatwa.Size = new System.Drawing.Size(108, 24);
            this.cbJenisSatwa.TabIndex = 3;
            // 
            // cbHabitat
            // 
            this.cbHabitat.FormattingEnabled = true;
            this.cbHabitat.Items.AddRange(new object[] {
            "darat"});
            this.cbHabitat.Location = new System.Drawing.Point(1081, 386);
            this.cbHabitat.Name = "cbHabitat";
            this.cbHabitat.Size = new System.Drawing.Size(108, 24);
            this.cbHabitat.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(940, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Habitat :";
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(12, 95);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 6;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(93, 95);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(174, 95);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 8;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSatwa
            // 
            this.dataGridViewSatwa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSatwa.Location = new System.Drawing.Point(12, 124);
            this.dataGridViewSatwa.Name = "dataGridViewSatwa";
            this.dataGridViewSatwa.RowHeadersWidth = 51;
            this.dataGridViewSatwa.RowTemplate.Height = 24;
            this.dataGridViewSatwa.Size = new System.Drawing.Size(639, 314);
            this.dataGridViewSatwa.TabIndex = 10;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.NameApp);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1304, 52);
            this.panelHeader.TabIndex = 11;
            // 
            // NameApp
            // 
            this.NameApp.BackColor = System.Drawing.Color.Transparent;
            this.NameApp.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameApp.ForeColor = System.Drawing.Color.White;
            this.NameApp.Location = new System.Drawing.Point(3, 0);
            this.NameApp.Name = "NameApp";
            this.NameApp.Size = new System.Drawing.Size(307, 57);
            this.NameApp.TabIndex = 7;
            this.NameApp.Text = "Data Satwa";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(576, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "cari";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormDataSatwa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.dataGridViewSatwa);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.cbHabitat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbJenisSatwa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSatwa);
            this.Controls.Add(this.label1);
            this.Name = "FormDataSatwa";
            this.Text = "Form Data Satwa";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSatwa)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSatwa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbJenisSatwa;
        private System.Windows.Forms.ComboBox cbHabitat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dataGridViewSatwa;
        private System.Windows.Forms.FlowLayoutPanel panelHeader;
        private System.Windows.Forms.Label NameApp;
        private System.Windows.Forms.Button button1;
    }
}

