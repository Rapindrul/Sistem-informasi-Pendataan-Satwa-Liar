using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendataan_Satwa_Liar.Model.Entities
{
    public class User
    {
        public int UserId { get; set; }      // mapping ke user_id
        public string Username { get; set; } // username
        public string Password { get; set; } // password (sementara plain text)
        public string Role { get; set; }     // "admin" / "user"
    }
}
