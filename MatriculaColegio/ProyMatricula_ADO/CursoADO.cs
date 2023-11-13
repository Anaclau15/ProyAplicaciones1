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
    public class CursoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        SqlDataAdapter ada;

        public DataTable ListarCurso()
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarCurso";
                cmd.Parameters.Clear();


                DataSet dts = new DataSet();
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Cursos");
                return dts.Tables["Cursos"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CursoBE ConsultarCurso(String strCodigo)
        {

            try
            {

                CursoBE objCursoBE = new CursoBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarCurso";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ccodigo", strCodigo);


                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objCursoBE.codCurso = dtr["codCurso"].ToString();
                    objCursoBE.nomCurso = dtr["nomCurso"].ToString();
                    objCursoBE.codGrado = dtr["codGrado"].ToString();
                    objCursoBE.estado = Convert.ToInt16(dtr["estado"]);
                }
                dtr.Close();
                return objCursoBE;
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

        public Boolean InsertarCurso(CursoBE objCursoBE)
        {

            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarCurso";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cnom", objCursoBE.nomCurso);
                cmd.Parameters.AddWithValue("@cgrado", objCursoBE.codGrado);
               
                cmd.Parameters.AddWithValue("@ausuRegistro", objCursoBE.usuRegistro);
                cmd.Parameters.AddWithValue("@aestado", objCursoBE.estado);


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
        public Boolean ActualizarCurso(CursoBE objCursoBE)
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarCurso";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ccodigo", objCursoBE.codCurso);
                cmd.Parameters.AddWithValue("@cnom", objCursoBE.nomCurso);
                cmd.Parameters.AddWithValue("@cgrado", objCursoBE.codGrado);
                cmd.Parameters.AddWithValue("@ausuUltMod", objCursoBE.usuUltMod);
                cmd.Parameters.AddWithValue("@aestado", objCursoBE.estado);



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
