using Pendataan_Satwa_Liar.Model.Entities;
using System;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.View
{
    public partial class FormEditSatwa : Form
    {
        private Satwa _satwaAwal;

        public event EventHandler BtnSimpanClick;

        public FormEditSatwa()
        {
            InitializeComponent();
            btnEdit.Click += (s, e) => BtnSimpanClick?.Invoke(s, e);
        }

        public void SetJenisList(object dataSource)
        {
            cmbJenis.DataSource = dataSource;
            cmbJenis.DisplayMember = "NamaJenis";
            cmbJenis.ValueMember = "JenisSatwaId"; // sesuaikan entity kamu
        }

        public void SetHabitatList(object dataSource)
        {
            cmbHabitat.DataSource = dataSource;
            cmbHabitat.DisplayMember = "NamaHabitat";
            cmbHabitat.ValueMember = "HabitatId";
        }

        public void LoadSatwa(Satwa s)
        {
            _satwaAwal = s;

            txtNamaSatwa.Text = s.NamaSatwa;

            // set SelectedValue setelah DataSource terpasang [web:227]
            cmbJenis.SelectedValue = s.JenisSatwaId;
            cmbHabitat.SelectedValue = s.HabitatId;

            rbJantan.Checked = s.Kelamin == "Jantan";
            rbBetina.Checked = s.Kelamin == "Betina";
        }

        public Satwa GetInputSatwa()
        {
            var kelamin = rbJantan.Checked ? "Jantan" : (rbBetina.Checked ? "Betina" : "");

            return new Satwa
            {
                SatwaId = _satwaAwal.SatwaId, // penting
                NamaSatwa = txtNamaSatwa.Text.Trim(),
                JenisSatwaId = Convert.ToInt32(cmbJenis.SelectedValue),
                HabitatId = Convert.ToInt32(cmbHabitat.SelectedValue),
                Kelamin = kelamin
            };
        }

        public void CloseSuccess()
        {
            this.DialogResult = DialogResult.OK; // supaya ShowDialog return OK [web:71]
            this.Close();
        }

        public void ShowError(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
