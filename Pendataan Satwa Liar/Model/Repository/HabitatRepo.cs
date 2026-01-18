using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Pendataan_Satwa_Liar.Model.Context;
using Pendataan_Satwa_Liar.Model.Entities;

namespace Pendataan_Satwa_Liar.Model.Repository
{
    public class HabitatRepo
    {
        private SQLiteConnection _conn;

        public HabitatRepo(DbContext context)
        {
            _conn = context.Conn;
        }

        // CREATE - Tambah habitat baru
        public int Add(Habitat habitat)
        {
            int result = 0;

            // Hanya nama_habitat, karena hanya itu yang ada di database
            string sql = @"INSERT INTO Habitat (nama_habitat)
                          VALUES (@nama)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", habitat.NamaHabitat);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Add Habitat error: {0}", ex.Message);
                    throw new Exception($"Gagal menambahkan habitat: {ex.Message}");
                }
            }

            return result;
        }

        // UPDATE - Update habitat
        public int Update(Habitat habitat)
        {
            int result = 0;

            // Hanya update nama_habitat
            string sql = @"UPDATE Habitat 
                          SET nama_habitat = @nama
                          WHERE habitat_id = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", habitat.NamaHabitat);
                cmd.Parameters.AddWithValue("@id", habitat.HabitatId);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update Habitat error: {0}", ex.Message);
                    throw new Exception($"Gagal mengupdate habitat: {ex.Message}");
                }
            }

            return result;
        }

        // DELETE - Hapus habitat
        public int Delete(int habitatId)
        {
            int result = 0;

            string sql = @"DELETE FROM Habitat WHERE habitat_id = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", habitatId);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete Habitat error: {0}", ex.Message);
                    throw new Exception($"Gagal menghapus habitat: {ex.Message}");
                }
            }

            return result;
        }

        // READ ALL - Get semua habitat
        public List<Habitat> GetAll()
        {
            List<Habitat> list = new List<Habitat>();

            try
            {
                // Hanya ambil kolom yang ada di database
                string sql = @"SELECT habitat_id, nama_habitat 
                              FROM Habitat 
                              ORDER BY nama_habitat";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Habitat habitat = new Habitat
                            {
                                HabitatId = Convert.ToInt32(dtr["habitat_id"]),
                                NamaHabitat = dtr["nama_habitat"].ToString()
                            };

                            list.Add(habitat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetAll Habitat error: {0}", ex.Message);
                throw new Exception($"Gagal mengambil data habitat: {ex.Message}");
            }

            return list;
        }

        // READ BY ID - Get habitat berdasarkan ID
        public Habitat GetById(int habitatId)
        {
            Habitat habitat = null;

            try
            {
                string sql = @"SELECT habitat_id, nama_habitat 
                              FROM Habitat 
                              WHERE habitat_id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", habitatId);

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        if (dtr.Read())
                        {
                            habitat = new Habitat
                            {
                                HabitatId = Convert.ToInt32(dtr["habitat_id"]),
                                NamaHabitat = dtr["nama_habitat"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetById Habitat error: {0}", ex.Message);
                throw new Exception($"Gagal mengambil habitat dengan ID {habitatId}: {ex.Message}");
            }

            return habitat;
        }

        // READ BY NAMA - Get habitat berdasarkan nama (untuk cek duplikat)
        public Habitat GetByNama(string nama)
        {
            Habitat habitat = null;

            try
            {
                string sql = @"SELECT habitat_id, nama_habitat 
                              FROM Habitat 
                              WHERE nama_habitat = @nama";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        if (dtr.Read())
                        {
                            habitat = new Habitat
                            {
                                HabitatId = Convert.ToInt32(dtr["habitat_id"]),
                                NamaHabitat = dtr["nama_habitat"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetByNama Habitat error: {0}", ex.Message);
                throw new Exception($"Gagal mengambil habitat dengan nama '{nama}': {ex.Message}");
            }

            return habitat;
        }

        // SEARCH - Cari habitat berdasarkan nama
        public List<Habitat> Search(string keyword)
        {
            List<Habitat> list = new List<Habitat>();

            try
            {
                string sql = @"SELECT habitat_id, nama_habitat 
                              FROM Habitat 
                              WHERE nama_habitat LIKE @keyword
                              ORDER BY nama_habitat";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Habitat habitat = new Habitat
                            {
                                HabitatId = Convert.ToInt32(dtr["habitat_id"]),
                                NamaHabitat = dtr["nama_habitat"].ToString()
                            };

                            list.Add(habitat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Search Habitat error: {0}", ex.Message);
                throw new Exception($"Gagal mencari habitat: {ex.Message}");
            }

            return list;
        }

        // COUNT - Hitung total habitat
        public int GetCount()
        {
            int count = 0;

            try
            {
                string sql = @"SELECT COUNT(*) FROM Habitat";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        count = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetCount Habitat error: {0}", ex.Message);
            }

            return count;
        }

        // Cek apakah habitat digunakan oleh satwa
        public bool IsUsedBySatwa(int habitatId)
        {
            bool isUsed = false;

            try
            {
                string sql = @"SELECT COUNT(*) FROM Satwa WHERE habitat_id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", habitatId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        isUsed = Convert.ToInt32(result) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("IsUsedBySatwa error: {0}", ex.Message);
            }

            return isUsed;
        }
    }
}