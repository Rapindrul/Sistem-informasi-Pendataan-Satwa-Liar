using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Pendataan_Satwa_Liar.Model.Context
{
    public class DbContext : IDisposable
    {
        private SQLiteConnection _conn;

        public SQLiteConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }

        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null;

            try
            {
                // ✅ Cara 1: Relative path dari executable (di bin/Debug atau bin/Release)
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string dbPath = Path.Combine(baseDir, "Database", "Satwa.db");

                // ✅ Alternatif 2: Kalau mau cari di folder project saat development
                // string projectDir = Directory.GetParent(baseDir).Parent.Parent.FullName;
                // string dbPath = Path.Combine(projectDir, "Database", "Satwa.db");

                // Debug print
                System.Diagnostics.Debug.Print("Database path: {0}", dbPath);

                // Pastikan folder Database ada
                string folderPath = Path.GetDirectoryName(dbPath);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Cek file exist
                if (!File.Exists(dbPath))
                {
                    throw new FileNotFoundException($"Database tidak ditemukan di: {dbPath}");
                }

                // Connection string
                string connectionString = $"Data Source={dbPath};Version=3;";

                conn = new SQLiteConnection(connectionString);
                conn.Open();

                // Enable Foreign Key
                using (var cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", conn))
                {
                    cmd.ExecuteNonQuery();
                }

                System.Diagnostics.Debug.Print("Database connected successfully!");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}", ex.Message);
                System.Windows.Forms.MessageBox.Show(
                    $"Database Connection Error:\n{ex.Message}\n\nPastikan file Satwa.db ada di folder Database/",
                    "Error",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error
                );
            }

            return conn;
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
