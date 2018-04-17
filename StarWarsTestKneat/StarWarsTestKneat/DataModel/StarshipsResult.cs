using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsTestKneat.DataModel
{
    public class StarshipsResult
    {
        public int count { get; set; }
        public string  next { get; set; }
        public string previous { get; set; }
        public Starship[] results { get; set; }
    }
}
