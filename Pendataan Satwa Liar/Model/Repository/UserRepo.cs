using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Pendataan_Satwa_Liar.Model.Context;
using Pendataan_Satwa_Liar.Model.Entities;

namespace Pendataan_Satwa_Liar.Model.Repository
{
    public class UserRepo
    {
        // deklarasi objek connection
        private SQLiteConnection _conn;

        // constructor
        public UserRepo(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        // CREATE - Tambah user baru (untuk Register)
        public int Add(User user)
        {
            int result = 0;

            // deklarasi perintah SQL - SESUAI DATABASE
            string sql = @"INSERT INTO User (username, password, role)
                          VALUES (@username, @password, @role)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Add User error: {0}", ex.Message);
                }
            }

            return result;
        }

        // UPDATE - Update user
        public int Update(User user)
        {
            int result = 0;

            // deklarasi perintah SQL - SESUAI DATABASE
            string sql = @"UPDATE User 
                          SET username = @username, 
                              password = @password, 
                              role = @role
                          WHERE user_id = @user_id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@user_id", user.UserId);

                try
                {
                    // jalankan perintah UPDATE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update User error: {0}", ex.Message);
                }
            }

            return result;
        }

        // DELETE - Hapus user
        public int Delete(int userId)
        {
            int result = 0;

            // deklarasi perintah SQL - SESUAI DATABASE
            string sql = @"DELETE FROM User WHERE user_id = @user_id";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@user_id", userId);

                try
                {
                    // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete User error: {0}", ex.Message);
                }
            }

            return result;
        }

        // READ ALL - Get semua user
        public List<User> GetAll()
        {
            // membuat objek collection untuk menampung objek user
            List<User> list = new List<User>();

            try
            {
                // deklarasi perintah SQL - SESUAI DATABASE
                string sql = @"SELECT user_id, username, password, role 
                              FROM User 
                              ORDER BY username";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // membuat objek dtr (data reader) untuk menampung result set
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            User user = new User();
                            user.UserId = Convert.ToInt32(dtr["user_id"]);
                            user.Username = dtr["username"].ToString();
                            user.Password = dtr["password"].ToString();
                            user.Role = dtr["role"].ToString();

                            // tambahkan objek user ke dalam collection
                            list.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetAll error: {0}", ex.Message);
            }

            return list;
        }

        // READ BY ID - Get user berdasarkan UserId
        public User GetById(int userId)
        {
            User user = null;

            try
            {
                // deklarasi perintah SQL - SESUAI DATABASE
                string sql = @"SELECT user_id, username, password, role 
                              FROM User 
                              WHERE user_id = @user_id";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    // membuat objek dtr (data reader) untuk menampung result set
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        if (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            user = new User();
                            user.UserId = Convert.ToInt32(dtr["user_id"]);
                            user.Username = dtr["username"].ToString();
                            user.Password = dtr["password"].ToString();
                            user.Role = dtr["role"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetById error: {0}", ex.Message);
            }

            return user;
        }

        // READ BY USERNAME - Get user berdasarkan username (untuk cek username exist)
        public User GetByUsername(string username)
        {
            User user = null;

            try
            {
                // deklarasi perintah SQL - SESUAI DATABASE
                string sql = @"SELECT user_id, username, password, role 
                              FROM User 
                              WHERE username = @username";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@username", username);

                    // membuat objek dtr (data reader) untuk menampung result set
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        if (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            user = new User();
                            user.UserId = Convert.ToInt32(dtr["user_id"]);
                            user.Username = dtr["username"].ToString();
                            user.Password = dtr["password"].ToString();
                            user.Role = dtr["role"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("GetByUsername error: {0}", ex.Message);
            }

            return user;
        }

        // LOGIN - Cek username dan password
        public User Login(string username, string password)
        {
            User user = null;

            try
            {
                string sql = @"SELECT user_id, username, password, role 
                      FROM User 
                      WHERE username = @username AND password = @password";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        if (dtr.Read())
                        {
                            user = new User();
                            user.UserId = Convert.ToInt32(dtr["user_id"]);
                            user.Username = dtr["username"].ToString();
                            user.Password = dtr["password"].ToString();
                            user.Role = dtr["role"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Login error: {0}", ex.Message);
                // ✅ Debug print aja, tidak pakai MessageBox
            }

            return user;
        }

    }
}
