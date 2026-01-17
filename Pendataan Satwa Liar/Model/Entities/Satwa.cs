using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendataan_Satwa_Liar.Model.Entities
{
    public class Satwa
    {
        public int SatwaId { get; set; }
        public string NamaSatwa { get; set; }
        public int JenisSatwaId { get; set; }
        public int HabitatId { get; set; }
        public string StatusKonservasi { get; set; }
        public int Populasi { get; set; }

        public string Kelamin {  get; set; }

        // Untuk tampilan (join)
        public string NamaJenisSatwa { get; set; }
        public string NamaHabitat { get; set; }
    }
}

