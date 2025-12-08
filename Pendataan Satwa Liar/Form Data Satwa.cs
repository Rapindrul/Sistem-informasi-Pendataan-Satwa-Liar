using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Pendataan_Satwa_Liar
{
    public partial class FormDataSatwa : Form
    {
        private int selectedId = -1;

        public FormDataSatwa()
        {
            InitializeComponent();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            string nama = tbSatwa.Text.Trim();

            if (nama == "")
            {
                MessageBox.Show("Nama satwa tidak boleh kosong!");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(Koneksi.ConnString))
            {
                conn.Open();
                string query = "INSERT INTO satwa (nama_satwa) VALUES (@nama)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Data berhasil ditambahkan!");
            tbSatwa.Clear();
            LoadData();
        }
        //tessss
        private void LoadData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Koneksi.ConnString))
            {
                conn.Open();
                string query = "SELECT satwa_id, nama_satwa FROM SatwaLiar";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewSatwa.DataSource = dt;
            }
        }

        

        private void dataGridViewSatwa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSatwa.Rows[e.RowIndex];

                selectedId = Convert.ToInt32(row.Cells["satwa_id"].Value);
                tbSatwa.Text = row.Cells["nama_satwa"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }

            string nama = tbSatwa.Text.Trim();

            if (nama == "")
            {
                MessageBox.Show("Nama satwa tidak boleh kosong!");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(Koneksi.ConnString))
            {
                conn.Open();
                string query = "UPDATE SatwaLiar SET nama_satwa=@nama WHERE satwa_id=@id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@id", selectedId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Data berhasil diperbarui!");

            selectedId = -1;
            tbSatwa.Clear();
            LoadData();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }

            string nama = tbSatwa.Text.Trim();

            if (nama == "")
            {
                MessageBox.Show("Nama satwa tidak boleh kosong!");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(Koneksi.ConnString))
            {
                conn.Open();
                string query = "UPDATE satwa SET nama_satwa=@nama WHERE satwa_id=@id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@id", selectedId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Data berhasil diperbarui!");

            selectedId = -1;
            tbSatwa.Clear();
            LoadData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Pilih data yang akan dihapus.");
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SQLiteConnection conn = new SQLiteConnection(Koneksi.ConnString))
            {
                conn.Open();
                string query = "DELETE FROM satwa WHERE satwa_id=@id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Data berhasil dihapus!");

            selectedId = -1;
            tbSatwa.Clear();
            LoadData();
        }

        private void btnBersihkan_Click(object sender, EventArgs e)
        {
            selectedId = -1;
            tbSatwa.Clear();
        }

        private void FormDataSatwa_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
