using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Pendataan_Satwa_Liar.Model.Context;
using Pendataan_Satwa_Liar.Model.Entities;

namespace Pendataan_Satwa_Liar.Model.Repository
{
    public class JenisSatwaRepo
    {
        private SQLiteConnection _conn;

        public JenisSatwaRepo(DbContext context)
        {
            _conn = context.Conn;
        }

        // CREATE - Tambah jenis satwa baru
        public int Add(JenisSatwa jenisSatwa)
        {
            int result = 0;

            string sql = @"INSERT INTO JenisSatwa (nama_jenis)
                          VALUES (@nama)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", jenisSatwa.NamaJenis);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Add JenisSatwa error: {0}", ex.Message);
                    throw new Exception($"Gagal menambahkan jenis satwa: {ex.Message}");
                }
            }

            return result;
        }

        // UPDATE - Update jenis satwa
        public int Update(JenisSatwa jenisSatwa)
        {
            int result = 0;

            string sql = @"UPDATE JenisSatwa 
                          SET nama_jenis = @nama
                          WHERE jenis_id = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", jenisSatwa.NamaJenis);
                cmd.Parameters.AddWithValue("@id", jenisSatwa.JenisSatwaId);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update JenisSatwa error: {0}", ex.Message);
                    throw new Exception($"Gagal mengupdate jenis satwa: {ex.Message}");
                }
            }

            return result;
        }

        // DELETE - Hapus jenis satwa
        public int Delete(int jenisSatwaId)
        {
            int result = 0;

            string sql = @"DELETE FROM JenisSatwa WHERE jenis_id = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", jenisSatwaId);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete JenisSatwa error: {0}", ex.Message);
                    throw new Exception($"Gagal menghapus jenis satwa: {ex.Message}");
                }
            }

            return result;
        }

        // READ ALL - Get semua jenis satwa
        public List<JenisSatwa> GetAll()
        {
            List<JenisSatwa> list = new List<JenisSatwa>();

            try
            {
                string sql = @"SELECT jenis_id, nama_jenis 
                              FROM JenisSatwa 
                              ORDER BY nama_jenis";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            JenisSatwa jenisSatwa = new JenisSatwa
                            {
                                JenisSatwaId = Convert.ToInt32(dtr["jenis_id"]),
                                NamaJenis = dtr["nama_jenis"].ToString()
                            };

                            list.Add(jenisSatwa);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetAll JenisSatwa error: {0}", ex.Message);
                throw new Exception($"Gagal mengambil data jenis satwa: {ex.Message}");
            }

            return list;
        }

        // READ BY ID - Get jenis satwa berdasarkan ID
        public JenisSatwa GetById(int jenisSatwaId)
        {
            JenisSatwa jenisSatwa = null;

            try
            {
                string sql = @"SELECT jenis_id, nama_jenis 
                              FROM JenisSatwa 
                              WHERE jenis_id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", jenisSatwaId);

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        if (dtr.Read())
                        {
                            jenisSatwa = new JenisSatwa
                            {
                                JenisSatwaId = Convert.ToInt32(dtr["jenis_id"]),
                                NamaJenis = dtr["nama_jenis"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetById JenisSatwa error: {0}", ex.Message);
                throw new Exception($"Gagal mengambil jenis satwa dengan ID {jenisSatwaId}: {ex.Message}");
            }

            return jenisSatwa;
        }

        // READ BY NAMA - Get jenis satwa berdasarkan nama
        public JenisSatwa GetByNama(string nama)
        {
            JenisSatwa jenisSatwa = null;

            try
            {
                string sql = @"SELECT jenis_id, nama_jenis 
                              FROM JenisSatwa 
                              WHERE nama_jenis = @nama";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        if (dtr.Read())
                        {
                            jenisSatwa = new JenisSatwa
                            {
                                JenisSatwaId = Convert.ToInt32(dtr["jenis_id"]),
                                NamaJenis = dtr["nama_jenis"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetByNama JenisSatwa error: {0}", ex.Message);
                throw new Exception($"Gagal mengambil jenis satwa dengan nama '{nama}': {ex.Message}");
            }

            return jenisSatwa;
        }

        // SEARCH - Cari jenis satwa berdasarkan nama
        public List<JenisSatwa> Search(string keyword)
        {
            List<JenisSatwa> list = new List<JenisSatwa>();

            try
            {
                string sql = @"SELECT jenis_id, nama_jenis 
                              FROM JenisSatwa 
                              WHERE nama_jenis LIKE @keyword
                              ORDER BY nama_jenis";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            JenisSatwa jenisSatwa = new JenisSatwa
                            {
                                JenisSatwaId = Convert.ToInt32(dtr["jenis_id"]),
                                NamaJenis = dtr["nama_jenis"].ToString()
                            };

                            list.Add(jenisSatwa);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Search JenisSatwa error: {0}", ex.Message);
                throw new Exception($"Gagal mencari jenis satwa: {ex.Message}");
            }

            return list;
        }

        // COUNT - Hitung total jenis satwa
        public int GetCount()
        {
            int count = 0;

            try
            {
                string sql = @"SELECT COUNT(*) FROM JenisSatwa";

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
                System.Diagnostics.Debug.Print("GetCount JenisSatwa error: {0}", ex.Message);
            }

            return count;
        }

        // Cek apakah jenis satwa digunakan oleh satwa
        public bool IsUsedBySatwa(int jenisSatwaId)
        {
            bool isUsed = false;

            try
            {
                string sql = @"SELECT COUNT(*) FROM Satwa WHERE jenis_satwa_id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id", jenisSatwaId);
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