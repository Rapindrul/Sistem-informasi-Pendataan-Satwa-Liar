using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Pendataan_Satwa_Liar.Model.Entities
{
    public class LaporanSatwa
    {
        public int LaporanId { get; set; }
        public int SatwaId { get; set; }
        public int UserId { get; set; }
        public DateTime TanggalLaporan { get; set; }
        public string Lokasi { get; set; }
        public int JumlahTerlihat { get; set; }
        public string Catatan { get; set; }
        public string Status { get; set; } // "Pending", "Verified", "Rejected"

        // Untuk tampilan
        public string NamaSatwa { get; set; }
        public string Username { get; set; }
    }
}

