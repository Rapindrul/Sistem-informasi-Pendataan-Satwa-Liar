using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Pendataan_Satwa_Liar.Model.Context
{
    public class DbContext : IDisposable
    {
        private readonly SQLiteConnection _conn;

        public SQLiteConnection Conn => _conn;

        public DbContext()
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "Satwa.db");

            // kalau DB wajib ada, biarkan throw (lebih rapi daripada MessageBox di layer context)
            if (!File.Exists(dbPath))
                throw new FileNotFoundException($"Database tidak ditemukan: {dbPath}");

            _conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            _conn.Open();

            // SQLite: foreign key harus di-enable per connection
            // enable foreign keys
            using (var cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", _conn))
            {
                cmd.ExecuteNonQuery();
            }

        }

        public void Dispose()
        {
            _conn?.Dispose(); // Dispose otomatis melakukan close juga
        }
    }
}
