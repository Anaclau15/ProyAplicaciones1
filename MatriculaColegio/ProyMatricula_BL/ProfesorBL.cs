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
    public class ProfesorBL
    {
        ProfesorADO objProfesorADO = new ProfesorADO();
        public DataTable ListarProfesor()
        {
            return objProfesorADO.ListarProfesor();
        }
        public ProfesorBE ConsultarProfesor(String strCodigo)
        {
            return objProfesorADO.ConsultarProfesor(strCodigo);
        }

        public Boolean InsertarProfesor(ProfesorBE objProfesorBE)
        {
            return objProfesorADO.InsertarProfesor(objProfesorBE);
        }
        public Boolean ActualizarProfesor(ProfesorBE objProfesorBE)
        {
            return objProfesorADO.ActualizarProfesor(objProfesorBE);
        }
    }
}
