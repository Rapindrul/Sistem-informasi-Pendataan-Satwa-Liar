
using Pendataan_Satwa_Liar.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;
using Pendataan_Satwa_Liar.Model.Entities;

namespace Pendataan_Satwa_Liar.Model
{
    public class AppDbContext : DbContext
    {
        // "AppDbContext" harus sama dengan name di <connectionStrings>
        public AppDbContext() : base("name=AppDbContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Satwa> Satwas { get; set; }
        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<JenisSatwa> JenisSatwas { get; set; }
        public DbSet<LaporanSatwa> LaporanSatwas { get; set; }
    }
}
