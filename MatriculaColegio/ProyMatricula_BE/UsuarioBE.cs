using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyMatricula_BE
{
    public class UsuarioBE
    {
        public String loginUsuario { get; set; }
        public String nombreUsuario { get; set; }
        public String apellidoUsuario { get; set; }
        public String dniUsuario { get; set; }
        public DateTime fechaNacimientoUsuario { get; set; }
        public String correoUsuario { get; set; }
        public Int16 nivel { get; set; }
        public String passwordUsuario { get; set; }

    }
}
