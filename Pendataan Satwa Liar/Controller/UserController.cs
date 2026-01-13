using System;
using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;
using Pendataan_Satwa_Liar.Model;      // <- AppDbContext
using Pendataan_Satwa_Liar.View;

namespace Pendataan_Satwa_Liar.Controller
{
    public class UserController
    {
        private readonly FormUser _view;
        private readonly UserRepo _repo;
        private readonly User _currentUser;
        private readonly AppDbContext _context;

        public UserController(FormUser view, User currentUser)
        {
            _view = view;
            _currentUser = currentUser;

            _context = new AppDbContext();
            _repo = new UserRepo(_context);

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

            _repo.Update(selected);
            _view.SetUserGridData(_repo.GetAll());
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            var selected = _view.GetSelectedUser();
            if (selected == null) return;

            if (_view.Confirm("Hapus user ini?"))
            {
                _repo.Delete(selected.UserId);
                _view.SetUserGridData(_repo.GetAll());
            }
        }
    }
}
