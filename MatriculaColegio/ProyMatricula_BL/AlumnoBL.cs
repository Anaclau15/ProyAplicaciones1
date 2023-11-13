using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyMatricula_ADO;
using ProyMatricula_BE;
namespace ProyMatricula_BL
{
    public class AlumnoBL
    {
        AlumnoADO objAlumnoADO=new AlumnoADO();
        public DataTable ListarAlumno()
        {
            return objAlumnoADO.ListarAlumno();
        }
        public AlumnoBE ConsultarAlumno(String strCodigo)
        {
            return objAlumnoADO.ConsultarAlumno(strCodigo);
        }

        public Boolean InsertarAlumno(AlumnoBE objAlumnoBE)
        {
            return objAlumnoADO.InsertarAlumno(objAlumnoBE);
        }
        public Boolean ActualizarAlumno(AlumnoBE objAlumnoBE)
        {
            return objAlumnoADO.ActualizarAlumno(objAlumnoBE);
        }
    }
}
