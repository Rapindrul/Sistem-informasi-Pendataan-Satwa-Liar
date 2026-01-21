using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;
using Pendataan_Satwa_Liar.View;
using System;

namespace Pendataan_Satwa_Liar.Controller
{
    internal class EditSatwaController
    {
        private readonly FormEditSatwa _view;
        private readonly User _user;
        private readonly SatwaRepo _satwaRepo;

        public EditSatwaController(FormEditSatwa view, User user, SatwaRepo satwaRepo)
        {
            _view = view;
            _user = user;
            _satwaRepo = satwaRepo;

            _view.BtnSimpanClick += (s, e) => Simpan();
        }

        private void Simpan()
        {
            try
            {
                if (!string.Equals(_user?.Role, "admin", StringComparison.OrdinalIgnoreCase))
                    throw new UnauthorizedAccessException("Hanya admin yang dapat mengedit data satwa.");

                Satwa s = _view.GetInputSatwa();

                if (string.IsNullOrWhiteSpace(s.NamaSatwa))
                    throw new ArgumentException("Nama satwa tidak boleh kosong.");

                if (string.IsNullOrWhiteSpace(s.Kelamin))
                    throw new ArgumentException("Kelamin harus dipilih.");

                bool ok = _satwaRepo.Update(s);
                if (!ok) throw new Exception("Gagal mengupdate satwa.");

                _view.CloseSuccess();
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }
    }
}
