using Pendataan_Satwa_Liar.Model.Entities;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar
{
    public partial class FormDataSatwa : Form
    {
        private readonly User _currentUser;

        public FormDataSatwa(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            this.BackColor = System.Drawing.Color.White;

            Label lblTitle = new Label
            {
                Text = "DATA SATWA LIAR",
                Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            Label lblInfo = new Label
            {
                Text = "Form untuk mengelola data satwa liar.\n(Coming soon...)",
                Location = new System.Drawing.Point(20, 70),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblInfo);
        }
    }
}
