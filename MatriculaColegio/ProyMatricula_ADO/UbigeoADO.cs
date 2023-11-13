using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyMatricula_ADO
{
    public class UbigeoADO
    {
        ConexionADO MiConexion=new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;

        public DataTable ListarUbigeo()
        {
            try
            {
                DataSet dts=new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Listarubigeo";

                cmd.Parameters.Clear();
                SqlDataAdapter ada=new SqlDataAdapter(cmd);
                ada.Fill(dts,"Ubigeo");
                return dts.Tables["Ubigeo"];
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
