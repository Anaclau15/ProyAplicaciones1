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
    public class MatriculaBL
    {
        MatriculaADO objMatriculaADO = new MatriculaADO();
        public DataTable ListarMatricula()
        {
            return objMatriculaADO.ListarMatricula();
        }
        public MatriculaBE ConsultarMatricula(String strCodigo)
        {
            return objMatriculaADO.ConsultarMatricula(strCodigo);
        }

        public Boolean InsertarMatricula(MatriculaBE objMatriculaBE)
        {
            return objMatriculaADO.InsertarMatricula(objMatriculaBE);
        }
        public Boolean ActualizarMatricula(MatriculaBE objMatriculaBE)
        {
            return objMatriculaADO.ActualizarMatricula(objMatriculaBE);
        }
    }
}
