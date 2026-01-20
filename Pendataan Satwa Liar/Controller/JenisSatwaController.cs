using Pendataan_Satwa_Liar.Model.Context;
using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;
using Pendataan_Satwa_Liar.View;
using System;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.Controller
{
    public class JenisSatwaController
    {
        private readonly FormKelolaJenis _view;
        private readonly JenisSatwaRepo _repo;
        private readonly DbContext _context;

        public JenisSatwaController(FormKelolaJenis view)
        {
            _view = view;
            _context = new DbContext();
            _repo = new JenisSatwaRepo(_context);

            // Wire events
            _view.BtnTambahClick += BtnTambah_Click;
            _view.BtnEditClick += BtnEdit_Click;
            _view.BtnHapusClick += BtnHapus_Click;
            _view.BtnRefreshClick += BtnRefresh_Click;
            _view.Load += View_Load;

            // Tutup context saat form ditutup
            _view.FormClosed += (s, e) => _context.Dispose();
        }

        private void View_Load(object sender, EventArgs e)
        {
            LoadAllJenisSatwa();
        }

        private void LoadAllJenisSatwa()
        {
            try
            {
                var list = _repo.GetAll();
                _view.SetDataGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading jenis satwa: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                var jenisSatwa = _view.GetInputJenisSatwa();

                // Validasi input
                if (string.IsNullOrWhiteSpace(jenisSatwa.NamaJenis))
                {
                    MessageBox.Show("Nama jenis satwa wajib diisi!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cek duplikat nama jenis satwa
                if (_repo.GetByNama(jenisSatwa.NamaJenis) != null)
                {
                    MessageBox.Show($"Jenis satwa '{jenisSatwa.NamaJenis}' sudah ada!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Simpan ke database
                var result = _repo.Add(jenisSatwa);

                if (result > 0)
                {
                    MessageBox.Show("Jenis satwa berhasil ditambahkan!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _view.ClearInput();
                    LoadAllJenisSatwa();
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan jenis satwa!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = _view.GetSelectedJenisSatwa();
                if (selected == null)
                {
                    MessageBox.Show("Pilih jenis satwa yang akan diedit!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ UNTUK SEKARANG - Edit langsung dengan InputBox
                var newNamaJenis = Prompt.ShowDialog($"Edit Nama Jenis Satwa (sekarang: {selected.NamaJenis})", "Edit Jenis Satwa");

                if (string.IsNullOrWhiteSpace(newNamaJenis))
                    return; // User membatalkan

                newNamaJenis = newNamaJenis.Trim();

                // Validasi
                if (string.IsNullOrWhiteSpace(newNamaJenis))
                {
                    MessageBox.Show("Nama jenis satwa wajib diisi!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cek duplikat nama (kecuali untuk diri sendiri)
                var existing = _repo.GetByNama(newNamaJenis);
                if (existing != null && existing.JenisSatwaId != selected.JenisSatwaId)
                {
                    MessageBox.Show($"Jenis satwa '{newNamaJenis}' sudah ada!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Konfirmasi edit
                var confirm = MessageBox.Show($"Edit jenis satwa '{selected.NamaJenis}' menjadi '{newNamaJenis}'?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Buat objek jenis satwa yang diperbarui
                    var updatedJenisSatwa = new JenisSatwa
                    {
                        JenisSatwaId = selected.JenisSatwaId,
                        NamaJenis = newNamaJenis
                    };

                    var result = _repo.Update(updatedJenisSatwa);

                    if (result > 0)
                    {
                        MessageBox.Show("Jenis satwa berhasil diedit!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _view.ClearInput();
                        LoadAllJenisSatwa();
                    }
                    else
                    {
                        MessageBox.Show("Gagal mengedit jenis satwa!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = _view.GetSelectedJenisSatwa();
                if (selected == null)
                {
                    MessageBox.Show("Pilih jenis satwa yang akan dihapus!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cek apakah jenis satwa digunakan oleh satwa
                if (_repo.IsUsedBySatwa(selected.JenisSatwaId))
                {
                    MessageBox.Show($"Jenis satwa '{selected.NamaJenis}' tidak bisa dihapus karena digunakan oleh satwa!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Konfirmasi hapus
                var confirm = MessageBox.Show($"Hapus jenis satwa '{selected.NamaJenis}'?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    var result = _repo.Delete(selected.JenisSatwaId);

                    if (result > 0)
                    {
                        MessageBox.Show("Jenis satwa berhasil dihapus!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _view.ClearInput();
                        LoadAllJenisSatwa();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus jenis satwa!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllJenisSatwa();
            _view.ClearInput();
        }
    }
}