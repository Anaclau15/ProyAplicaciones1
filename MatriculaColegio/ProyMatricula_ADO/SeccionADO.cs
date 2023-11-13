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
    public class SeccionADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        SqlDataAdapter ada;

        public DataTable ListarSeccion()
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarSeccion";
                cmd.Parameters.Clear();


                DataSet dts = new DataSet();
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Seccion");
                return dts.Tables["Seccion"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SeccionBE ConsultarSeccion(String strCodigo)
        {

            try
            {

                SeccionBE objSeccionBE = new SeccionBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarSeccion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@scodigo", strCodigo);


                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objSeccionBE.codSeccion = dtr["codSeccion"].ToString();
                    objSeccionBE.codGrado = dtr["codGrado"].ToString();
                    objSeccionBE.codigoAula = dtr["codigoAula"].ToString();
                    objSeccionBE.codGrado = dtr["codGrado"].ToString();
                    objSeccionBE.codProfesor = dtr["codProfesor"].ToString();
                    objSeccionBE.aforo = dtr["aforo"].ToString();
                    objSeccionBE.turno = dtr["turno"].ToString();
                    objSeccionBE.estado = Convert.ToInt16(dtr["estado"]);
                }
                dtr.Close();
                return objSeccionBE;
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
        public Boolean InsertarSeccion(SeccionBE objSeccionBE)
        {

            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarSeccion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@scodgrado", objSeccionBE.codGrado);
                cmd.Parameters.AddWithValue("@scodaula", objSeccionBE.codigoAula);
                cmd.Parameters.AddWithValue("@scodpro", objSeccionBE.codProfesor);
                cmd.Parameters.AddWithValue("@aforo", objSeccionBE.aforo);
                cmd.Parameters.AddWithValue("@turno", objSeccionBE.turno);
                cmd.Parameters.AddWithValue("@ausuRegistro", objSeccionBE.usuRegistro);
                cmd.Parameters.AddWithValue("@aestado", objSeccionBE.estado);


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

        public Boolean ActualizarSeccion(SeccionBE objSeccionBE)
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarSeccion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@scodigo", objSeccionBE.codSeccion);
                cmd.Parameters.AddWithValue("@scodgrado", objSeccionBE.codGrado);
                cmd.Parameters.AddWithValue("@scodaula", objSeccionBE.codigoAula);
                cmd.Parameters.AddWithValue("@scodpro", objSeccionBE.codProfesor);
                cmd.Parameters.AddWithValue("@aforo", objSeccionBE.aforo);
                cmd.Parameters.AddWithValue("@turno", objSeccionBE.turno);
                cmd.Parameters.AddWithValue("@ausuUltMod", objSeccionBE.usuUltMod);
                cmd.Parameters.AddWithValue("@aestado", objSeccionBE.estado);



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
