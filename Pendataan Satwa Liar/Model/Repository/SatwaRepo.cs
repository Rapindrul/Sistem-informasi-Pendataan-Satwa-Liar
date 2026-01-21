using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Pendataan_Satwa_Liar.Model.Context;
using Pendataan_Satwa_Liar.Model.Entities;

namespace Pendataan_Satwa_Liar.Model.Repository
{
    internal class SatwaRepo
    {
        public List<Satwa> GetAll()
        {
            var list = new List<Satwa>();

            using (var db = new DbContext())
            {
                var sql = @"
                    SELECT s.satwa_id, s.nama_satwa, s.jenis_id, s.habitat_id, s.kelamin,
                           j.nama_jenis AS NamaJenisSatwa,
                           h.nama_habitat AS NamaHabitat
                    FROM SatwaLiar s
                    LEFT JOIN JenisSatwa j ON s.jenis_id = j.jenis_id
                    LEFT JOIN Habitat h ON s.habitat_id = h.habitat_id;";

                using (var cmd = new SQLiteCommand(sql, db.Conn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Satwa
                        {
                            SatwaId = Convert.ToInt32(rd["satwa_id"]),
                            NamaSatwa = rd["nama_satwa"]?.ToString(),
                            JenisSatwaId = Convert.ToInt32(rd["jenis_id"]),
                            HabitatId = Convert.ToInt32(rd["habitat_id"]),
                            Kelamin = rd["kelamin"]?.ToString(),
                            NamaJenisSatwa = rd["NamaJenisSatwa"]?.ToString(),
                            NamaHabitat = rd["NamaHabitat"]?.ToString(),
                        });
                    }
                }
            }

            return list;
        }

        public bool Create(Satwa satwa)
        {
            using (var db = new DbContext())
            {
                var sql = @"
                    INSERT INTO SatwaLiar (nama_satwa, jenis_id, habitat_id, kelamin)
                    VALUES (@nama, @jenisId, @habitatId, @kelamin);";

                using (var cmd = new SQLiteCommand(sql, db.Conn))
                {
                    cmd.Parameters.AddWithValue("@nama", satwa.NamaSatwa);
                    cmd.Parameters.AddWithValue("@jenisId", satwa.JenisSatwaId);
                    cmd.Parameters.AddWithValue("@habitatId", satwa.HabitatId);
                    cmd.Parameters.AddWithValue("@kelamin", satwa.Kelamin);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(Satwa satwa)
        {
            using (var db = new DbContext())
            {
                var sql = @"
                    UPDATE SatwaLiar
                    SET nama_satwa = @nama,
                        jenis_id = @jenisId,
                        habitat_id = @habitatId,
                        kelamin = @kelamin
                    WHERE satwa_id = @id;";

                using (var cmd = new SQLiteCommand(sql, db.Conn))
                {
                    cmd.Parameters.AddWithValue("@nama", satwa.NamaSatwa);
                    cmd.Parameters.AddWithValue("@jenisId", satwa.JenisSatwaId);
                    cmd.Parameters.AddWithValue("@habitatId", satwa.HabitatId);
                    cmd.Parameters.AddWithValue("@kelamin", satwa.Kelamin);
                    cmd.Parameters.AddWithValue("@id", satwa.SatwaId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new DbContext())
            {
                var sql = "DELETE FROM SatwaLiar WHERE satwa_id = @id;";
                using (var cmd = new SQLiteCommand(sql, db.Conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Satwa> Search(string keyword, string kriteria)
        {
            var list = new List<Satwa>();
            using (var db = new DbContext())
            {
                var col = GetSearchColumn(kriteria);
                var sql = $@"
                    SELECT s.satwa_id, s.nama_satwa, s.jenis_id, s.habitat_id, s.kelamin,
                           j.nama_jenis AS NamaJenisSatwa,
                           h.nama_habitat AS NamaHabitat
                    FROM SatwaLiar s
                    LEFT JOIN JenisSatwa j ON s.jenis_id = j.jenis_id
                    LEFT JOIN Habitat h ON s.habitat_id = h.habitat_id
                    WHERE {col} LIKE @kw;";

                using (var cmd = new SQLiteCommand(sql, db.Conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + (keyword ?? "") + "%");
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new Satwa
                            {
                                SatwaId = Convert.ToInt32(rd["satwa_id"]),
                                NamaSatwa = rd["nama_satwa"]?.ToString(),
                                JenisSatwaId = Convert.ToInt32(rd["jenis_id"]),
                                HabitatId = Convert.ToInt32(rd["habitat_id"]),
                                Kelamin = rd["kelamin"]?.ToString(),
                                NamaJenisSatwa = rd["NamaJenisSatwa"]?.ToString(),
                                NamaHabitat = rd["NamaHabitat"]?.ToString(),
                            });
                        }
                    }
                }
            }
            return list;
        }

        private string GetSearchColumn(string kriteria)
        {
            switch ((kriteria ?? "").ToLower())
            {
                case "nama": return "s.nama_satwa";
                case "jenis": return "j.nama_jenis";
                case "habitat": return "h.nama_habitat";
                default: return "s.nama_satwa";
            }
        }
    }
}
