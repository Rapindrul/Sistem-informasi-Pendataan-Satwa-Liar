using System.Collections.Generic;
using System.Linq;
using Pendataan_Satwa_Liar.Model.Entities;
using System.Data.Entity;

namespace Pendataan_Satwa_Liar.Model.Repository
{
    public class UserRepo
    {
        private readonly AppDbContext _context;

        // Context di-inject biar bisa dipakai bareng repo lain kalau perlu
        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            // Find = cari pakai Primary Key, return null kalau tidak ketemu
            return _context.Users.Find(id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            // Cocok untuk scenario WinForms: entity dari UI biasanya "detached"
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var u = _context.Users.Find(id);
            if (u == null) return;

            _context.Users.Remove(u);
            _context.SaveChanges();
        }

        public User Login(string username, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
