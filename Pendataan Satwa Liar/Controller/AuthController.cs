using Microsoft.Win32;
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
        private readonly AppDbContext _context;
        private readonly UserRepo _userRepo;
        private readonly Register _registerView;


        public AuthController(LoginForm loginView, Register registerView)
        {
            _loginView = loginView;
            _registerView = registerView;

            _context = new AppDbContext();
            _userRepo = new UserRepo(_context);

            _loginView.FormClosed += (s, e) => _context.Dispose();

            _loginView.BtnLoginClick += BtnLogin_Click;
            _registerView.BtnRegisterClick += BtnRegister_Click;
        }


        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var username = _registerView.GetUsername();
            var pass = _registerView.GetPassword();
            var repass = _registerView.GetRePassword();

            if (pass != repass)
            {
                _registerView.ShowMessage("Password tidak sama");
                return;
            }

            // cek username sudah ada
            if (_userRepo.GetByUsername(username) != null)
            {
                _registerView.ShowMessage("Username sudah dipakai");
                return;
            }

            // paksa role default = user
            var u = new User { Username = username, Password = pass, Role = "user" };
            _userRepo.Add(u);

            _registerView.ShowMessage("Register berhasil, silakan login");
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var username = _loginView.GetUsername();
            var pass = _loginView.GetPassword();

            var user = _userRepo.Login(username, pass);
            if (user == null)
            {
                _loginView.ShowMessage("Login gagal");
                return;
            }

            // contoh buka form utama
            var main = new FormMain(user);
            main.Show();

            _loginView.Hide();
        }
    }
}
