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
    public class AulaBL
    {
        AulaADO objAulaADO = new AulaADO();
        public DataTable ListarAula()
        {
            return objAulaADO.ListarAula();
        }
        public AulaBE ConsultarAula(String strCodigo)
        {
            return objAulaADO.ConsultarAula(strCodigo);
        }

        public Boolean InsertarAula(AulaBE objAulaBE)
        {
            return objAulaADO.InsertarAula(objAulaBE);
        }
        public Boolean ActualizarAula(AulaBE objAulaBE)
        {
            return objAulaADO.ActualizarAula(objAulaBE);
        }
    }
}
