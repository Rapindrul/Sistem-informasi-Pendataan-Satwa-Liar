namespace Pendataan_Satwa_Liar.View
{
    partial class FormEditSatwa
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
            this.rbBetina = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbJantan = new System.Windows.Forms.RadioButton();
            this.cmbJenis = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbHabitat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtNamaSatwa = new System.Windows.Forms.TextBox();
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
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(477, 61);
            this.panelHeader.TabIndex = 28;
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
            this.NameApp.Text = "Edit satwa";
            // 
            // rbBetina
            // 
            this.rbBetina.AutoSize = true;
            this.rbBetina.Location = new System.Drawing.Point(218, 152);
            this.rbBetina.Name = "rbBetina";
            this.rbBetina.Size = new System.Drawing.Size(66, 20);
            this.rbBetina.TabIndex = 38;
            this.rbBetina.TabStop = true;
            this.rbBetina.Text = "Betina";
            this.rbBetina.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 25);
            this.label4.TabIndex = 37;
            this.label4.Text = "Kelamin:";
            // 
            // rbJantan
            // 
            this.rbJantan.AutoSize = true;
            this.rbJantan.Location = new System.Drawing.Point(110, 152);
            this.rbJantan.Name = "rbJantan";
            this.rbJantan.Size = new System.Drawing.Size(68, 20);
            this.rbJantan.TabIndex = 36;
            this.rbJantan.TabStop = true;
            this.rbJantan.Text = "Jantan";
            this.rbJantan.UseVisualStyleBackColor = true;
            // 
            // cmbJenis
            // 
            this.cmbJenis.FormattingEnabled = true;
            this.cmbJenis.Items.AddRange(new object[] {
            "Nama",
            "Habitat",
            "Jenis"});
            this.cmbJenis.Location = new System.Drawing.Point(320, 117);
            this.cmbJenis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbJenis.Name = "cmbJenis";
            this.cmbJenis.Size = new System.Drawing.Size(144, 24);
            this.cmbJenis.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "Jenis:";
            // 
            // cmbHabitat
            // 
            this.cmbHabitat.FormattingEnabled = true;
            this.cmbHabitat.Items.AddRange(new object[] {
            "Nama",
            "Habitat",
            "Jenis"});
            this.cmbHabitat.Location = new System.Drawing.Point(91, 114);
            this.cmbHabitat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbHabitat.Name = "cmbHabitat";
            this.cmbHabitat.Size = new System.Drawing.Size(126, 24);
            this.cmbHabitat.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 32;
            this.label2.Text = "Habitat: ";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(370, 160);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 36);
            this.btnEdit.TabIndex = 31;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // txtNamaSatwa
            // 
            this.txtNamaSatwa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNamaSatwa.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtNamaSatwa.Location = new System.Drawing.Point(159, 75);
            this.txtNamaSatwa.Name = "txtNamaSatwa";
            this.txtNamaSatwa.Size = new System.Drawing.Size(306, 22);
            this.txtNamaSatwa.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 31);
            this.label1.TabIndex = 29;
            this.label1.Text = "Nama satwa: ";
            // 
            // FormEditSatwa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 217);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.rbBetina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbJantan);
            this.Controls.Add(this.cmbJenis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbHabitat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtNamaSatwa);
            this.Controls.Add(this.label1);
            this.Name = "FormEditSatwa";
            this.Text = "FormEditSatwa";
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelHeader;
        private System.Windows.Forms.Label NameApp;
        private System.Windows.Forms.RadioButton rbBetina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbJantan;
        private System.Windows.Forms.ComboBox cmbJenis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbHabitat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtNamaSatwa;
        private System.Windows.Forms.Label label1;
    }
}