using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyMatricula_BE;
namespace ProyMatricula_ADO
{
    public class AulaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        SqlDataAdapter ada;
        public DataTable ListarAula()
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarAula";
                cmd.Parameters.Clear();


                DataSet dts = new DataSet();
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Aulas");
                return dts.Tables["Aulas"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AulaBE ConsultarAula(String strCodigo)
        {

            try
            {

                AulaBE objAulaBE = new AulaBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarAula";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@acodigo", strCodigo);


                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objAulaBE.codigoAula = dtr["codigoAula"].ToString();
                    objAulaBE.nombreAula = dtr["nombreAula"].ToString();
                    objAulaBE.estado = Convert.ToInt16(dtr["estado"]);
                }
                dtr.Close();
                return objAulaBE;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }



        }
        public Boolean InsertarAula(AulaBE objAulaBE)
        {

            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarAula";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@anom", objAulaBE.nombreAula);
                cmd.Parameters.AddWithValue("@ausuRegistro", objAulaBE.usuRegistro);
                cmd.Parameters.AddWithValue("@aestado", objAulaBE.estado);


                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }
        }

        public Boolean ActualizarAula(AulaBE objAulaBE)
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarAula";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@acodigo", objAulaBE.codigoAula);
                cmd.Parameters.AddWithValue("@anom", objAulaBE.nombreAula);
               
                cmd.Parameters.AddWithValue("@ausuUltMod", objAulaBE.usuUltMod);
                cmd.Parameters.AddWithValue("@aestado", objAulaBE.estado);



                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }


        }
    }
}
