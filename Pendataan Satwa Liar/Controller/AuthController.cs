using Pendataan_Satwa_Liar.Model;
using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;
using Pendataan_Satwa_Liar.View;
using System;

namespace Pendataan_Satwa_Liar.Controller
{
    public class AuthController
    {
        private readonly LoginForm _loginView;
        private readonly Register _registerView;
        private readonly AppDbContext _context;
        private readonly UserRepo _userRepo;

        public AuthController(LoginForm loginView, Register registerView)
        {
            _loginView = loginView;
            _registerView = registerView;

            _context = new AppDbContext();
            _userRepo = new UserRepo(_context);

            // dari LoginForm
            _loginView.BtnLoginClick += BtnLogin_Click;
            _loginView.btnToRegisterClick += BtnGoRegister_Click;

            // dari Register
            _registerView.BtnRegisterClick += BtnRegister_Click;
            _registerView.BackToLoginClick += BtnBackLogin_Click;
        }


        // ====== Navigasi antara Login dan Register ======

        private void BtnGoRegister_Click(object sender, EventArgs e)
        {
            _loginView.Hide();
            _registerView.ClearInput();
            _registerView.Show();
        }


        private void BtnBackLogin_Click(object sender, EventArgs e)
        {
            _registerView.Hide();
            _loginView.ClearInput();
            _loginView.Show();
        }

        // ====== Register ======

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var username = _registerView.GetUsername();
            var pass = _registerView.GetPassword();
            var repass = _registerView.GetRePassword();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(pass) ||
                string.IsNullOrWhiteSpace(repass))
            {
                _registerView.ShowMessage("Semua field harus diisi.");
                return;
            }

            if (pass != repass)
            {
                _registerView.ShowMessage("Password tidak sama.");
                return;
            }

            if (_userRepo.GetByUsername(username) != null)
            {
                _registerView.ShowMessage("Username sudah dipakai.");
                return;
            }

            var u = new User
            {
                Username = username,
                Password = pass,   // untuk tugas boleh plain text
                Role = "user"      // default user biasa
            };

            _userRepo.Add(u);

            _registerView.ShowMessage("Register berhasil, silakan login.");
            _registerView.Hide();
            _loginView.ClearInput();
            _loginView.Show();
        }

        // ====== Login ======

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var username = _loginView.GetUsername();
            var pass = _loginView.GetPassword();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(pass))
            {
                _loginView.ShowMessage("Username dan password wajib diisi.");
                return;
            }

            var user = _userRepo.Login(username, pass);
            if (user == null)
            {
                _loginView.ShowMessage("Login gagal. Cek username/password.");
                return;
            }

            // buka FormUser dengan user yang login
            var view = new FormUser(user);
            var controller = new UserController(view, user); // kalau kamu pakai
            view.Show();
            _loginView.Hide();
        }
    }
}
