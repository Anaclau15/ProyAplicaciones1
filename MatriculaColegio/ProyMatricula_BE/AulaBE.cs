using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyMatricula_BE
{
    public class AulaBE
    {
        public String codigoAula { get; set; }
        public String nombreAula { get; set; }
        public DateTime fecRegistro { get; set; }
        public String usuRegistro { get; set; }
        public DateTime fecUltMod { get; set; }
        public String usuUltMod { get; set; }

        public Int16 estado { get; set; }

    }
}
