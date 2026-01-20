using Pendataan_Satwa_Liar.Model.Context;
using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;
using Pendataan_Satwa_Liar.View;
using System;
using System.Windows.Forms;

namespace Pendataan_Satwa_Liar.Controller
{
    public class HabitatController
    {
        private readonly FormKelolaHabitat _view;
        private readonly HabitatRepo _repo;
        private readonly DbContext _context;

        public HabitatController(FormKelolaHabitat view)
        {
            _view = view;
            _context = new DbContext();
            _repo = new HabitatRepo(_context);

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
            LoadAllHabitat();
        }

        private void LoadAllHabitat()
        {
            try
            {
                var list = _repo.GetAll();
                _view.SetDataGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading habitat: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                var habitat = _view.GetInputHabitat();

                // Validasi input
                if (string.IsNullOrWhiteSpace(habitat.NamaHabitat))
                {
                    MessageBox.Show("Nama habitat wajib diisi!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cek duplikat nama habitat
                if (_repo.GetByNama(habitat.NamaHabitat) != null)
                {
                    MessageBox.Show($"Habitat '{habitat.NamaHabitat}' sudah ada!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Simpan ke database
                var result = _repo.Add(habitat);

                if (result > 0)
                {
                    MessageBox.Show("Habitat berhasil ditambahkan!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _view.ClearInput();
                    LoadAllHabitat();
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan habitat!", "Error",
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
                var selected = _view.GetSelectedHabitat();
                if (selected == null)
                {
                    MessageBox.Show("Pilih habitat yang akan diedit!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ UNTUK SEKARANG - Edit langsung dengan InputBox
                var newNamaHabitat = Prompt.ShowDialog($"Edit Nama Habitat (sekarang: {selected.NamaHabitat})", "Edit Habitat");

                if (string.IsNullOrWhiteSpace(newNamaHabitat))
                    return; // User membatalkan

                newNamaHabitat = newNamaHabitat.Trim();

                // Validasi
                if (string.IsNullOrWhiteSpace(newNamaHabitat))
                {
                    MessageBox.Show("Nama habitat wajib diisi!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cek duplikat nama (kecuali untuk diri sendiri)
                var existing = _repo.GetByNama(newNamaHabitat);
                if (existing != null && existing.HabitatId != selected.HabitatId)
                {
                    MessageBox.Show($"Habitat '{newNamaHabitat}' sudah ada!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Konfirmasi edit
                var confirm = MessageBox.Show($"Edit habitat '{selected.NamaHabitat}' menjadi '{newNamaHabitat}'?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Buat objek habitat yang diperbarui
                    var updatedHabitat = new Habitat
                    {
                        HabitatId = selected.HabitatId,
                        NamaHabitat = newNamaHabitat
                    };

                    var result = _repo.Update(updatedHabitat);

                    if (result > 0)
                    {
                        MessageBox.Show("Habitat berhasil diedit!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _view.ClearInput();
                        LoadAllHabitat();
                    }
                    else
                    {
                        MessageBox.Show("Gagal mengedit habitat!", "Error",
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
                var selected = _view.GetSelectedHabitat();
                if (selected == null)
                {
                    MessageBox.Show("Pilih habitat yang akan dihapus!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cek apakah habitat digunakan oleh satwa
                if (_repo.IsUsedBySatwa(selected.HabitatId))
                {
                    MessageBox.Show($"Habitat '{selected.NamaHabitat}' tidak bisa dihapus karena digunakan oleh satwa!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Konfirmasi hapus
                var confirm = MessageBox.Show($"Hapus habitat '{selected.NamaHabitat}'?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    var result = _repo.Delete(selected.HabitatId);

                    if (result > 0)
                    {
                        MessageBox.Show("Habitat berhasil dihapus!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _view.ClearInput();
                        LoadAllHabitat();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus habitat!", "Error",
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
            LoadAllHabitat();
            _view.ClearInput();
        }
    }
}