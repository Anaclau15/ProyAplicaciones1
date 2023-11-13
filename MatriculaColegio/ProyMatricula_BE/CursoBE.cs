using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyMatricula_BE
{
    public class CursoBE
    {
        public String codCurso { get; set; }
        public String nomCurso { get; set; }
        public String codGrado { get; set; }

        public DateTime fecRegistro { get; set; }
        public String usuRegistro { get; set; }
        public DateTime fecUltMod { get; set; }
        public String usuUltMod { get; set; }

        public Int16 estado { get; set; }
    }
}
