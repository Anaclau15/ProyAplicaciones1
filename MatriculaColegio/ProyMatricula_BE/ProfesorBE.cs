using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyMatricula_BE
{
    public class ProfesorBE { 


    public String codProfesor { get; set; }
    public String idUbigeo { get; set; }
    public String nomProfesor { get; set; }
    public String apePaterProfesor { get; set; }
    public String apeMaterProfesor { get; set; }
    public String dniProfesor { get; set; }
    public String telefonoProfesor { get; set; }
    public String correoProfesor { get; set; }
    public String direccionProfesor { get; set; }
    public DateTime fechaNacimientoProfesor { get; set; }
    public String codigoEspecialidad { get; set; }
    public byte[] fotoProfesor { get; set; }
   

    public DateTime fecRegistro { get; set; }
    public String usuRegistro { get; set; }
    public DateTime fecUltMod { get; set; }
    public String usuUltMod { get; set; }


    public Int16 estado { get; set; }

    }
}
