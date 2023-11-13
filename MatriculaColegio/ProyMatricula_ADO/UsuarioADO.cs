using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using ProyMatricula_BE;
namespace ProyMatricula_ADO
{
    public class UsuarioADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        SqlDataAdapter ada;

        public DataTable ListarUsuario()
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarUsuario";
                cmd.Parameters.Clear();


                DataSet dts = new DataSet();
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Usuarios");
                return dts.Tables["Usuarios"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public UsuarioBE ConsultarUsuario(String strLogin)
        {
            UsuarioBE objUsuarioBE = new UsuarioBE();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ConsultarUsuario";
            // Agregamos el parametro...
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ulog", strLogin);
            try
            {
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objUsuarioBE.loginUsuario = dtr["loginUsuario"].ToString();
                    objUsuarioBE.nombreUsuario = dtr["nombreUsuario"].ToString();
                    objUsuarioBE.apellidoUsuario = dtr["apellidoUsuario"].ToString();
                    objUsuarioBE.dniUsuario = dtr["dniUsuario"].ToString();
                    objUsuarioBE.fechaNacimientoUsuario = Convert.ToDateTime(dtr["fechaNacimientoUsuario"]);
                    objUsuarioBE.correoUsuario = dtr["correoUsuario"].ToString();
                    objUsuarioBE.nivel = Convert.ToInt16(dtr["nivel"]);
                    objUsuarioBE.passwordUsuario = dtr["passwordUsuario"].ToString();
                }
                dtr.Close();
                return objUsuarioBE;
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
    }
}
