using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyMatricula_ADO;
namespace ProyMatricula_BL
{
    public class GradoBL
    {
        GradoADO objGradoADO = new GradoADO();
        public DataTable ListarGrado()
        {
            return objGradoADO.ListarGrado();
        }
    }
}
