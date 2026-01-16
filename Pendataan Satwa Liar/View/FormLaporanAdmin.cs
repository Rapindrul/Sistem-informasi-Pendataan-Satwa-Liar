using System;
using System.Windows.Forms;
using Pendataan_Satwa_Liar.Model.Entities;

namespace Pendataan_Satwa_Liar.View
{
    public partial class FormLaporanAdmin : Form
    {
        private readonly User _currentUser;

        public FormLaporanAdmin(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            this.BackColor = System.Drawing.Color.White;

            Label lblTitle = new Label
            {
                Text = "VERIFIKASI LAPORAN - ADMIN",
                Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            Label lblInfo = new Label
            {
                Text = "Form untuk admin memverifikasi laporan satwa.\n(Coming soon...)",
                Location = new System.Drawing.Point(20, 70),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblInfo);
        }
    }
}
