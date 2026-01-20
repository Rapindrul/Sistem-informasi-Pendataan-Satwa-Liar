using System;
using System.Collections.Generic;
using Pendataan_Satwa_Liar.Model.Entities;
using Pendataan_Satwa_Liar.Model.Repository;

namespace Pendataan_Satwa_Liar.Controller
{
    internal class SatwaController
    {
        private SatwaRepo satwaRepo;
        private string currentUserRole = "";

        public SatwaController()
        {
            satwaRepo = new SatwaRepo();
        }

        public string CurrentUserRole
        {
            get { return currentUserRole; }
            set { currentUserRole = value; }
        }

        private bool IsAdmin()
        {
            return currentUserRole?.ToLower() == "admin";
        }

        // CREATE: Tambah data satwa baru (Hanya Admin)
        public bool TambahSatwa(Satwa satwa)
        {
            if (!IsAdmin())
            {
                throw new UnauthorizedAccessException("Hanya admin yang dapat menambah data satwa!");
            }

            // Validasi data sebelum menyimpan
            if (string.IsNullOrWhiteSpace(satwa.NamaSatwa))
                throw new ArgumentException("Nama satwa tidak boleh kosong!");
            
            if (satwa.Populasi < 0)
                throw new ArgumentException("Populasi tidak boleh negatif!");

            return satwaRepo.Create(satwa);
        }

        // READ: Ambil semua data satwa (Semua role bisa akses)
        public List<Satwa> GetAllSatwa()
        {
            return satwaRepo.GetAll();
        }

        // READ: Ambil data satwa berdasarkan ID (Semua role bisa akses)
        public Satwa GetSatwaById(int id)
        {
            return satwaRepo.GetById(id);
        }

        // UPDATE: Update data satwa (Hanya Admin)
        public bool UpdateSatwa(Satwa satwa)
        {
            if (!IsAdmin())
            {
                throw new UnauthorizedAccessException("Hanya admin yang dapat mengupdate data satwa!");
            }

            // Validasi data
            if (string.IsNullOrWhiteSpace(satwa.NamaSatwa))
                throw new ArgumentException("Nama satwa tidak boleh kosong!");
            
            if (satwa.Populasi < 0)
                throw new ArgumentException("Populasi tidak boleh negatif!");

            return satwaRepo.Update(satwa);
        }

        // DELETE: Hapus data satwa berdasarkan ID (Hanya Admin)
        public bool HapusSatwa(int id)
        {
            if (!IsAdmin())
            {
                throw new UnauthorizedAccessException("Hanya admin yang dapat menghapus data satwa!");
            }

            // Validasi: Cek apakah satwa ada sebelum menghapus
            var satwa = satwaRepo.GetById(id);
            if (satwa == null)
                throw new ArgumentException("Data satwa tidak ditemukan!");

            return satwaRepo.Delete(id);
        }

        // SEARCH: Cari satwa berdasarkan kriteria (Semua role bisa akses)
        public List<Satwa> CariSatwa(string keyword, string kriteria)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return satwaRepo.GetAll(); // Jika keyword kosong, tampilkan semua

            return satwaRepo.Search(keyword, kriteria);
        }

        // Method tambahan untuk pagination (opsional)
        public List<Satwa> GetSatwaWithPagination(int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            return satwaRepo.GetWithPagination(page, pageSize);
        }

        // Method untuk mendapatkan total jumlah data
        public int GetTotalSatwaCount()
        {
            return satwaRepo.GetTotalCount();
        }
    }
}