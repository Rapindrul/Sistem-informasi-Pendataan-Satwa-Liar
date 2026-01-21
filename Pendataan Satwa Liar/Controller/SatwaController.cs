using Pendataan_Satwa_Liar.Model.Context;
using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;
using Pendataan_Satwa_Liar.View;
using System;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.Controller
{
    public class SatwaController
    {
        private readonly FormDataSatwa _view;
        private readonly User _currentUser;

        private readonly DbContext _context;
        private readonly SatwaRepo _satwaRepo;
        private readonly JenisSatwaRepo _jenisRepo;
        private readonly HabitatRepo _habitatRepo;

        public SatwaController(FormDataSatwa view, User currentUser)
        {
            _view = view;
            _currentUser = currentUser;

            _context = new DbContext();

            // Repo yang butuh context -> wajib lewat sini
            _jenisRepo = new JenisSatwaRepo(_context);
            _habitatRepo = new HabitatRepo(_context);

            // SatwaRepo kamu:
            // - Kalau SatwaRepo kamu masih model lama (buat koneksi sendiri), biarkan new SatwaRepo()
            // - Kalau SatwaRepo kamu sudah diubah jadi SatwaRepo(DbContext), ganti jadi new SatwaRepo(_context)
            _satwaRepo = new SatwaRepo();

            _view.Load += View_Load;

            _view.BtnTambahClick += BtnTambah_Click;
            _view.BtnKelolaJenisClick += BtnKelolaJenis_Click;
            _view.BtnKelolaHabitatClick += BtnKelolaHabitat_Click;
            _view.BtnCariClick += BtnCari_Click;
            _view.BtnEditClick += BtnEdit_Click;
            _view.BtnHapusClick += BtnHapus_Click;


            // penting: tutup koneksi saat form ditutup
            _view.FormClosed += (s, e) => _context.Dispose(); // [web:107]
        }

        private void View_Load(object sender, EventArgs e)
        {
            // mode admin/non-admin
            _view.SetAdminMode(string.Equals(_currentUser.Role, "admin", StringComparison.OrdinalIgnoreCase));

            // load grid awal
            _view.SetDataGridSatwa(_satwaRepo.GetAll());
        }

        private void BtnCari_Click(object sender, EventArgs e)
        {
            var keyword = _view.GetSearchText();
            var kriteria = _view.GetSearchCriteria(); // pastikan method ini ada

            if (string.IsNullOrWhiteSpace(keyword))
                _view.SetDataGridSatwa(_satwaRepo.GetAll());
            else
                _view.SetDataGridSatwa(_satwaRepo.Search(keyword, kriteria));
        }

        private void BtnKelolaJenis_Click(object sender, EventArgs e)
        {
            using (var form = new FormKelolaJenis())
            {
                var controller = new JenisSatwaController(form);
                form.ShowDialog();
            }

            // refresh grid satwa (biar NamaJenisSatwa ikut update)
            _view.SetDataGridSatwa(_satwaRepo.GetAll());
        }

        private void BtnKelolaHabitat_Click(object sender, EventArgs e)
        {
            using (var form = new FormKelolaHabitat())
            {
                var controller = new HabitatController(form);
                form.ShowDialog();
            }

            _view.SetDataGridSatwa(_satwaRepo.GetAll());
        }

        private void BtnTambah_Click(object sender, EventArgs e)
        {
            using (var form = new FormTambahSatwa(_currentUser))
            {
                form.SetJenisList(_jenisRepo.GetAll());
                form.SetHabitatList(_habitatRepo.GetAll());

                // WAJIB: controller untuk handle BtnTambahClick di FormTambahSatwa
                var tambahController = new TambahSatwaController(
                    form,
                    _currentUser,
                    _satwaRepo,
                    _jenisRepo,
                    _habitatRepo
                    );


                var result = form.ShowDialog();
                if (result == DialogResult.OK) // DialogResult dipakai untuk status dialog [web:170]
                    _view.SetDataGridSatwa(_satwaRepo.GetAll());
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var selected = _view.GetSelectedSatwa();
            if (selected == null)
            {
                MessageBox.Show("Pilih data satwa yang ingin diedit!");
                return;
            }

            using (var form = new FormEditSatwa())
            {
                form.SetJenisList(_jenisRepo.GetAll());
                form.SetHabitatList(_habitatRepo.GetAll());

                form.LoadSatwa(selected);

                var editController = new EditSatwaController(form, _currentUser, _satwaRepo);

                var result = form.ShowDialog();
                if (result == DialogResult.OK) // OK dari DialogResult form edit [web:71]
                    _view.SetDataGridSatwa(_satwaRepo.GetAll());
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            var selected = _view.GetSelectedSatwa();
            if (selected == null)
            {
                MessageBox.Show("Pilih data satwa yang ingin dihapus!");
                return;
            }

            if (!_view.Confirm($"Hapus satwa '{selected.NamaSatwa}'?")) return;

            bool ok = _satwaRepo.Delete(selected.SatwaId);
            if (ok) _view.SetDataGridSatwa(_satwaRepo.GetAll());
            else MessageBox.Show("Gagal menghapus satwa.");
        }


    }
}
