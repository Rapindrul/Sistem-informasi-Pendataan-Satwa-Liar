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
            this.btnBersihkan = new System.Windows.Forms.Button();
            this.dataGridViewSatwa = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSatwa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama Satwa :";
            // 
            // tbSatwa
            // 
            this.tbSatwa.Location = new System.Drawing.Point(162, 53);
            this.tbSatwa.Name = "tbSatwa";
            this.tbSatwa.Size = new System.Drawing.Size(108, 22);
            this.tbSatwa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 90);
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
            this.cbJenisSatwa.Location = new System.Drawing.Point(162, 91);
            this.cbJenisSatwa.Name = "cbJenisSatwa";
            this.cbJenisSatwa.Size = new System.Drawing.Size(108, 24);
            this.cbJenisSatwa.TabIndex = 3;
            // 
            // cbHabitat
            // 
            this.cbHabitat.FormattingEnabled = true;
            this.cbHabitat.Items.AddRange(new object[] {
            "darat"});
            this.cbHabitat.Location = new System.Drawing.Point(162, 128);
            this.cbHabitat.Name = "cbHabitat";
            this.cbHabitat.Size = new System.Drawing.Size(108, 24);
            this.cbHabitat.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Habitat :";
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(81, 188);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 6;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(162, 188);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;

            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(243, 188);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 8;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            // 
            // btnBersihkan
            // 
            this.btnBersihkan.Location = new System.Drawing.Point(324, 188);
            this.btnBersihkan.Name = "btnBersihkan";
            this.btnBersihkan.Size = new System.Drawing.Size(75, 23);
            this.btnBersihkan.TabIndex = 9;
            this.btnBersihkan.Text = "Bersihkan";
            this.btnBersihkan.UseVisualStyleBackColor = true;
      
            // 
            // dataGridViewSatwa
            // 
            this.dataGridViewSatwa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSatwa.Location = new System.Drawing.Point(81, 234);
            this.dataGridViewSatwa.Name = "dataGridViewSatwa";
            this.dataGridViewSatwa.RowHeadersWidth = 51;
            this.dataGridViewSatwa.RowTemplate.Height = 24;
            this.dataGridViewSatwa.Size = new System.Drawing.Size(354, 150);
            this.dataGridViewSatwa.TabIndex = 10;
    
            // 
            // FormDataSatwa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewSatwa);
            this.Controls.Add(this.btnBersihkan);
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
        private System.Windows.Forms.Button btnBersihkan;
        private System.Windows.Forms.DataGridView dataGridViewSatwa;
    }
}

