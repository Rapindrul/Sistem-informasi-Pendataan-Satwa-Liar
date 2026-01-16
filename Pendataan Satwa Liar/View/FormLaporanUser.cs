using System;
using System.Windows.Forms;
using Pendataan_Satwa_Liar.Model.Entities;

namespace Pendataan_Satwa_Liar.View
{
    public partial class FormLaporanUser : Form
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
    }
}
