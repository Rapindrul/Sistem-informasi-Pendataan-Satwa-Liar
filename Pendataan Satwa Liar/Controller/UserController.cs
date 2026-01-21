using Pendataan_Satwa_Liar.Model.Context;
using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;
using Pendataan_Satwa_Liar.View;
using System;
using System.Windows.Forms;

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
            _view.BtnLogoutClick += BtnLogout_Click;
            _view.BtnResetPasswordClick += BtnResetPassword_Click;
            _view.BtnLaporClick += BtnLapor_Click;
            _view.BtnDataSatwaClick += BtnDataSatwa_Click;


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
            if (selected == null)
            {
                MessageBox.Show("Pilih user yang ingin diedit!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ UNTUK SEKARANG - Edit langsung dengan InputBox
            var newUsername = Prompt.ShowDialog($"Edit Username (sekarang: {selected.Username})", "Edit User");
            if (string.IsNullOrWhiteSpace(newUsername)) return;

            var newRole = MessageBox.Show("Role: Admin?", "Pilih Role",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? "admin" : "user";

            selected.Username = newUsername;
            selected.Role = newRole;

            var result = _repo.Update(selected);
            if (result > 0)
            {
                MessageBox.Show("User berhasil diupdate!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _view.SetUserGridData(_repo.GetAll());
            }
            else
            {
                MessageBox.Show("Gagal update user!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnHapus_Click(object sender, EventArgs e)
        {
            var selected = _view.GetSelectedUser();
            if (selected == null)
            {
                MessageBox.Show("Pilih user yang ingin dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Jangan bisa hapus diri sendiri
            if (selected.UserId == _currentUser.UserId)
            {
                MessageBox.Show("Anda tidak bisa menghapus akun sendiri!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_view.Confirm($"Hapus user '{selected.Username}'?"))
            {
                var result = _repo.Delete(selected.UserId);
                if (result > 0)
                {
                    MessageBox.Show("User berhasil dihapus!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _view.SetUserGridData(_repo.GetAll());
                }
                else
                {
                    MessageBox.Show("Gagal menghapus user!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // ✅ Navigation ke Laporan (Role-based) - POPUP WINDOW
        private void BtnLapor_Click(object sender, EventArgs e)
        {
            Form laporanForm;

            if (_currentUser.Role == "admin")
            {
                laporanForm = new FormLaporanAdmin(_currentUser);
            }
            else
            {
                laporanForm = new FormLaporanUser(_currentUser);
            }

            laporanForm.ShowDialog();  // Popup modal
        }

        private void BtnDataSatwa_Click(object sender, EventArgs e)
        {
            var dataSatwaForm = new FormDataSatwa(_currentUser);

            // WAJIB: bikin controllernya supaya event tombol di-handle
            var satwaController = new SatwaController(dataSatwaForm, _currentUser);

            dataSatwaForm.ShowDialog();
        }


        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Yakin ingin logout?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
               

                _view.Hide();

                // Buka LoginForm lagi
                var loginView = new LoginForm();
                var registerView = new Register();
                var authController = new AuthController(loginView, registerView);
                loginView.Show();

                _view.Close();  // ← Close akan trigger FormClosed yang dispose context
            }
        }



        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            var selected = _view.GetSelectedUser();
            if (selected == null)
            {
                MessageBox.Show("Pilih user yang ingin direset password!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newPassword = Prompt.ShowDialog($"Masukkan password baru untuk '{selected.Username}':", "Reset Password");

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Password tidak boleh kosong!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm password
            var confirmPassword = Prompt.ShowDialog("Konfirmasi password baru:", "Konfirmasi");

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Password tidak sama!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update password
            selected.Password = newPassword;
            var result = _repo.Update(selected);

            if (result > 0)
            {
                MessageBox.Show($"Password untuk '{selected.Username}' berhasil direset!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _view.SetUserGridData(_repo.GetAll());
            }
            else
            {
                MessageBox.Show("Gagal reset password!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Tambahkan di file terpisah atau di UserController.cs (di luar class)
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Width = 350, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 350 };
            Button confirmation = new Button() { Text = "OK", Left = 250, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }

}
