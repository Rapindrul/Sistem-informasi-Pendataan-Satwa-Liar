using Pendataan_Satwa_Liar.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendataan_Satwa_Liar.Model.Repository
{
    public class UserRepo
    {
        private readonly string _connString;

        public UserRepo()
        {
            string dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                "Satwa.db");

            _connString = $"Data Source={dbPath};Version=3;";
        }

        private SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connString);
        }

        public List<User> GetAll()
        {
            var list = new List<User>();

            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(
                "SELECT user_id, username, password, role FROM User", conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new User
                        {
                            UserId = rd.GetInt32(0),
                            Username = rd.GetString(1),
                            Password = rd.GetString(2),
                            Role = rd.GetString(3)
                        });
                    }
                }
            }

            return list;
        }

        public User GetById(int id)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(
                "SELECT user_id, username, password, role " +
                "FROM User WHERE user_id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();

                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new User
                        {
                            UserId = rd.GetInt32(0),
                            Username = rd.GetString(1),
                            Password = rd.GetString(2),
                            Role = rd.GetString(3)
                        };
                    }
                }
            }

            return null;
        }

        public User GetByUsername(string username)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(
                "SELECT user_id, username, password, role " +
                "FROM User WHERE username = @u", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                conn.Open();

                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new User
                        {
                            UserId = rd.GetInt32(0),
                            Username = rd.GetString(1),
                            Password = rd.GetString(2),
                            Role = rd.GetString(3)
                        };
                    }
                }
            }

            return null;
        }

        public void Add(User user)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(
                "INSERT INTO User(username, password, role) " +
                "VALUES(@u, @p, @r)", conn))
            {
                cmd.Parameters.AddWithValue("@u", user.Username);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@r", user.Role);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(User user)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(
                "UPDATE User SET username = @u, password = @p, role = @r " +
                "WHERE user_id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@u", user.Username);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@r", user.Role);
                cmd.Parameters.AddWithValue("@id", user.UserId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(
                "DELETE FROM User WHERE user_id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public User Login(string username, string password)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(
                "SELECT user_id, username, password, role " +
                "FROM User WHERE username = @u AND password = @p", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                conn.Open();

                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new User
                        {
                            UserId = rd.GetInt32(0),
                            Username = rd.GetString(1),
                            Password = rd.GetString(2),
                            Role = rd.GetString(3)
                        };
                    }
                }
            }

            return null; // login gagal
        }
    }
}
