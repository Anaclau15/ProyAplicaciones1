using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace ProyMatricula_ADO
{
    internal class ConexionADO
    {
        public string GetCnx()
        {
            string strCnx = ConfigurationManager.ConnectionStrings["BaseDeDatosMatricula"].ConnectionString;
            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
        }
    }
}
