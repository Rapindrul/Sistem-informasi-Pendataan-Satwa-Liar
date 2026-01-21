using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;
using Pendataan_Satwa_Liar.View;
using System;

namespace Pendataan_Satwa_Liar.Controller
{
    internal class TambahSatwaController
    {
        private readonly FormTambahSatwa _view;
        private readonly User _user;
        private readonly SatwaRepo _satwaRepo;
        private readonly JenisSatwaRepo _jenisRepo;
        private readonly HabitatRepo _habitatRepo;

        public TambahSatwaController(
            FormTambahSatwa view,
            User user,
            SatwaRepo satwaRepo,
            JenisSatwaRepo jenisRepo,
            HabitatRepo habitatRepo)
        {
            _view = view;
            _user = user;
            _satwaRepo = satwaRepo;
            _jenisRepo = jenisRepo;
            _habitatRepo = habitatRepo;

            LoadLookup();

            _view.BtnTambahClick += (s, e) => Simpan();
        }

        private void LoadLookup()
        {
            _view.SetJenisList(_jenisRepo.GetAll());
            _view.SetHabitatList(_habitatRepo.GetAll());
        }

        private void Simpan()
        {
            try
            {
                if (!string.Equals(_user?.Role, "admin", StringComparison.OrdinalIgnoreCase))
                    throw new UnauthorizedAccessException("Hanya admin yang dapat menambah data satwa.");

                Satwa s = _view.GetInputSatwa();

                if (string.IsNullOrWhiteSpace(s.NamaSatwa))
                    throw new ArgumentException("Nama satwa tidak boleh kosong.");

                if (string.IsNullOrWhiteSpace(s.Kelamin))
                    throw new ArgumentException("Kelamin harus dipilih.");

                bool ok = _satwaRepo.Create(s);
                if (!ok) throw new Exception("Gagal menambah satwa.");

                _view.CloseSuccess(); // set DialogResult.OK lalu close [web:71]
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }
    }
}
