using System;
using Pendataan_Satwa_Liar.Model.Context;
using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;
using Pendataan_Satwa_Liar.View;

namespace Pendataan_Satwa_Liar.Controller
{
    public class UserController
    {
        private readonly FormUser _view;
        private readonly UserRepo _repo;  // ✅ UserRepo sudah benar
        private readonly User _currentUser;
        private readonly DbContext _context;  // ✅ DbContext (bukan AppDbContext)

        public UserController(FormUser view, User currentUser)
        {
            _view = view;
            _currentUser = currentUser;

            _context = new DbContext();  // ✅ new DbContext() (bukan AppDbContext)
            _repo = new UserRepo(_context);  // ✅ UserRepo sudah benar

            _view.Load += View_Load;
            _view.BtnEditClick += BtnEdit_Click;
            _view.BtnHapusClick += BtnHapus_Click;

            // penting: tutup context saat form ditutup
            _view.FormClosed += (s, e) => _context.Dispose();
        }

        private void View_Load(object sender, EventArgs e)
        {
            _view.SetUsername(_currentUser.Username);

            if (_currentUser.Role == "admin")
            {
                _view.SetAdminMode(true);
                _view.SetUserGridData(_repo.GetAll());
            }
            else
            {
                _view.SetAdminMode(false);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var selected = _view.GetSelectedUser();
            if (selected == null) return;

            var result = _repo.Update(selected);
            if (result > 0)
            {
                _view.SetUserGridData(_repo.GetAll());
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            var selected = _view.GetSelectedUser();
            if (selected == null) return;

            if (_view.Confirm("Hapus user ini?"))
            {
                var result = _repo.Delete(selected.UserId);
                if (result > 0)
                {
                    _view.SetUserGridData(_repo.GetAll());
                }
            }
        }
    }
}
