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
    public class SeccionBL
    {
        SeccionADO objSeccionADO = new SeccionADO();
        public DataTable ListarSeccion()
        {
            return objSeccionADO.ListarSeccion();
        }
        public SeccionBE ConsultarSeccion(String strCodigo)
        {
            return objSeccionADO.ConsultarSeccion(strCodigo);
        }

        public Boolean InsertarSeccion(SeccionBE objSeccionBE)
        {
            return objSeccionADO.InsertarSeccion(objSeccionBE);
        }
        public Boolean ActualizarSeccion(SeccionBE objSeccionBE)
        {
            return objSeccionADO.ActualizarSeccion(objSeccionBE);
        }
    }
}
