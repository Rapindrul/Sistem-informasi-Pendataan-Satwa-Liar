using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Pendataan_Satwa_Liar.Model.Entities;

namespace Pendataan_Satwa_Liar.Model.Repository
{
    internal class SatwaRepo
    {
        private string connectionString = @"Data Source=Database\Satwa.db;Version=3;";

        // CREATE: Tambah data satwa baru
        public bool Create(Satwa satwa)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO SatwaLiar 
                    (nama_satwa, jenis_satwa_id, habitat_id, status_konservasi, populasi, kelamin)
                    VALUES (@nama, @jenisId, @habitatId, @status, @populasi, @kelamin)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", satwa.NamaSatwa);
                    cmd.Parameters.AddWithValue("@jenisId", satwa.JenisSatwaId);
                    cmd.Parameters.AddWithValue("@habitatId", satwa.HabitatId);
                    cmd.Parameters.AddWithValue("@status", satwa.StatusKonservasi);
                    cmd.Parameters.AddWithValue("@populasi", satwa.Populasi);
                    cmd.Parameters.AddWithValue("@kelamin", satwa.Kelamin);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        // READ: Ambil semua data satwa dengan join ke tabel jenis dan habitat
        public List<Satwa> GetAll()
        {
            List<Satwa> listSatwa = new List<Satwa>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT s.*, j.nama_jenis AS NamaJenisSatwa, h.nama_habitat AS NamaHabitat
                    FROM SatwaLiar s
                    LEFT JOIN JenisSatwa j ON s.jenis_satwa_id = j.jenis_id
                    LEFT JOIN Habitat h ON s.habitat_id = h.habitat_id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listSatwa.Add(MapToSatwa(reader));
                    }
                }
            }

            return listSatwa;
        }

        // READ: Ambil data satwa berdasarkan ID
        public Satwa GetById(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT s.*, j.nama_jenis AS NamaJenisSatwa, h.nama_habitat AS NamaHabitat
                    FROM SatwaLiar s
                    LEFT JOIN JenisSatwa j ON s.jenis_satwa_id = j.jenis_id
                    LEFT JOIN Habitat h ON s.habitat_id = h.habitat_id
                    WHERE s.satwa_id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToSatwa(reader);
                        }
                    }
                }
            }

            return null;
        }

        // UPDATE: Update data satwa
        public bool Update(Satwa satwa)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    UPDATE SatwaLiar 
                    SET nama_satwa = @nama,
                        jenis_satwa_id = @jenisId,
                        habitat_id = @habitatId,
                        status_konservasi = @status,
                        populasi = @populasi,
                        kelamin = @kelamin
                    WHERE satwa_id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", satwa.NamaSatwa);
                    cmd.Parameters.AddWithValue("@jenisId", satwa.JenisSatwaId);
                    cmd.Parameters.AddWithValue("@habitatId", satwa.HabitatId);
                    cmd.Parameters.AddWithValue("@status", satwa.StatusKonservasi);
                    cmd.Parameters.AddWithValue("@populasi", satwa.Populasi);
                    cmd.Parameters.AddWithValue("@kelamin", satwa.Kelamin);
                    cmd.Parameters.AddWithValue("@id", satwa.SatwaId);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        // DELETE: Hapus data satwa berdasarkan ID
        public bool Delete(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM SatwaLiar WHERE satwa_id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        // SEARCH: Cari satwa berdasarkan kriteria
        public List<Satwa> Search(string keyword, string kriteria)
        {
            List<Satwa> hasil = new List<Satwa>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT s.*, j.nama_jenis AS NamaJenisSatwa, h.nama_habitat AS NamaHabitat
                    FROM SatwaLiar s
                    LEFT JOIN JenisSatwa j ON s.jenis_satwa_id = j.jenis_id
                    LEFT JOIN Habitat h ON s.habitat_id = h.habitat_id
                    WHERE " + GetSearchCondition(kriteria) + " LIKE @keyword";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hasil.Add(MapToSatwa(reader));
                        }
                    }
                }
            }

            return hasil;
        }

        // READ: Ambil data satwa dengan pagination (opsional, untuk performa)
        public List<Satwa> GetWithPagination(int page, int pageSize)
        {
            List<Satwa> listSatwa = new List<Satwa>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT s.*, j.nama_jenis AS NamaJenisSatwa, h.nama_habitat AS NamaHabitat
                    FROM SatwaLiar s
                    LEFT JOIN JenisSatwa j ON s.jenis_satwa_id = j.jenis_id
                    LEFT JOIN Habitat h ON s.habitat_id = h.habitat_id
                    LIMIT @pageSize OFFSET @offset";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    int offset = (page - 1) * pageSize;
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listSatwa.Add(MapToSatwa(reader));
                        }
                    }
                }
            }

            return listSatwa;
        }

        // READ: Hitung total jumlah data satwa
        public int GetTotalCount()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM SatwaLiar";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Helper method untuk mapping data dari reader ke object Satwa
        private Satwa MapToSatwa(SQLiteDataReader reader)
        {
            return new Satwa
            {
                SatwaId = Convert.ToInt32(reader["satwa_id"]),
                NamaSatwa = reader["nama_satwa"].ToString(),
                JenisSatwaId = Convert.ToInt32(reader["jenis_satwa_id"]),
                HabitatId = Convert.ToInt32(reader["habitat_id"]),
                StatusKonservasi = reader["status_konservasi"].ToString(),
                Populasi = Convert.ToInt32(reader["populasi"]),
                Kelamin = reader["kelamin"].ToString(),
                NamaJenisSatwa = reader["NamaJenisSatwa"].ToString(),
                NamaHabitat = reader["NamaHabitat"].ToString()
            };
        }

        // Helper method untuk menentukan kondisi pencarian
        private string GetSearchCondition(string kriteria)
        {
            switch (kriteria.ToLower())
            {
                case "nama":
                    return "s.nama_satwa";
                case "jenis":
                    return "j.nama_jenis";
                case "habitat":
                    return "h.nama_habitat";
                case "status":
                    return "s.status_konservasi";
                default:
                    return "s.nama_satwa";
            }
        }
    }
}