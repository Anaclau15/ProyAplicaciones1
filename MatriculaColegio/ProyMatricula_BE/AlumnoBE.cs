using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyMatricula_BE
{
    public class AlumnoBE
    {
        public String codAlumno { get; set; }
        public String nomAlumno { get; set; }
        public String apePaterAlumno { get; set; }
        public String apeMaterAlumno { get; set; }
        public String dniAlumno { get; set; }
        public String direccionAlumno { get; set; }
        public String correoAlumno { get; set; }
        public DateTime fechaNacimientoAlumno { get; set; }
        public byte[] fotoAlumno { get; set; }
        public String idUbigeo { get; set; }

        public DateTime fecRegistro { get; set; }
        public String usuRegistro { get; set; }
        public DateTime fecUltMod { get; set; }
        public String usuUltMod { get; set; }


        public Int16 estado { get; set; }
        


    }
}
