namespace Pendataan_Satwa_Liar.View
{
    partial class FormTambahSatwa
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
            this.btnTambah = new System.Windows.Forms.Button();
            this.txtNamaSatwa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHabitat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbJenis = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbJantan = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbBetina = new System.Windows.Forms.RadioButton();
            this.panelHeader.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(477, 61);
            this.panelHeader.TabIndex = 13;
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
            this.NameApp.Text = "Tambah satwa";
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambah.ForeColor = System.Drawing.Color.White;
            this.btnTambah.Location = new System.Drawing.Point(370, 156);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(94, 36);
            this.btnTambah.TabIndex = 20;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            // 
            // txtNamaSatwa
            // 
            this.txtNamaSatwa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNamaSatwa.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtNamaSatwa.Location = new System.Drawing.Point(159, 71);
            this.txtNamaSatwa.Name = "txtNamaSatwa";
            this.txtNamaSatwa.Size = new System.Drawing.Size(306, 31);
            this.txtNamaSatwa.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 31);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nama satwa: ";
            // 
            // cmbHabitat
            // 
            this.cmbHabitat.FormattingEnabled = true;
            this.cmbHabitat.Items.AddRange(new object[] {
            "Nama",
            "Habitat",
            "Jenis"});
            this.cmbHabitat.Location = new System.Drawing.Point(91, 110);
            this.cmbHabitat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbHabitat.Name = "cmbHabitat";
            this.cmbHabitat.Size = new System.Drawing.Size(126, 33);
            this.cmbHabitat.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Habitat: ";
            // 
            // cmbJenis
            // 
            this.cmbJenis.FormattingEnabled = true;
            this.cmbJenis.Items.AddRange(new object[] {
            "Nama",
            "Habitat",
            "Jenis"});
            this.cmbJenis.Location = new System.Drawing.Point(320, 113);
            this.cmbJenis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbJenis.Name = "cmbJenis";
            this.cmbJenis.Size = new System.Drawing.Size(144, 33);
            this.cmbJenis.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Jenis:";
            // 
            // rbJantan
            // 
            this.rbJantan.AutoSize = true;
            this.rbJantan.Location = new System.Drawing.Point(110, 148);
            this.rbJantan.Name = "rbJantan";
            this.rbJantan.Size = new System.Drawing.Size(83, 29);
            this.rbJantan.TabIndex = 25;
            this.rbJantan.TabStop = true;
            this.rbJantan.Text = "Jantan";
            this.rbJantan.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Kelamin:";
            // 
            // rbBetina
            // 
            this.rbBetina.AutoSize = true;
            this.rbBetina.Location = new System.Drawing.Point(218, 148);
            this.rbBetina.Name = "rbBetina";
            this.rbBetina.Size = new System.Drawing.Size(81, 29);
            this.rbBetina.TabIndex = 27;
            this.rbBetina.TabStop = true;
            this.rbBetina.Text = "Betina";
            this.rbBetina.UseVisualStyleBackColor = true;
            // 
            // FormTambahSatwa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(477, 217);
            this.Controls.Add(this.rbBetina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbJantan);
            this.Controls.Add(this.cmbJenis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbHabitat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.txtNamaSatwa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelHeader);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormTambahSatwa";
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelHeader;
        private System.Windows.Forms.Label NameApp;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.TextBox txtNamaSatwa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHabitat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbJenis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbJantan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbBetina;
    }
}