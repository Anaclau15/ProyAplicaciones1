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
    public  class MatriculaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        SqlDataAdapter ada;
        public DataTable ListarMatricula()
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarMatricula";
                cmd.Parameters.Clear();


                DataSet dts = new DataSet();
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Matricula");
                return dts.Tables["Matricula"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public MatriculaBE ConsultarMatricula(String strCodigo)
        {

            try
            {

                MatriculaBE objMatriculaBE = new MatriculaBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarMatricula";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mcodigo", strCodigo);


                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objMatriculaBE.codMatricula = dtr["codMatricula"].ToString();
                    objMatriculaBE.codSeccion = dtr["codSeccion"].ToString();
                    objMatriculaBE.codAlumno = dtr["codAlumno"].ToString();
                    objMatriculaBE.estado = Convert.ToInt16(dtr["estado"]);

                    objMatriculaBE.fecRegistro = Convert.ToDateTime(dtr["fecRegistro"].ToString());
                   
                }
                dtr.Close();
                return objMatriculaBE;
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
        public Boolean InsertarMatricula(MatriculaBE objMatriculaBE)
        {

            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarMatricula";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mcodseccio", objMatriculaBE.codSeccion);
                cmd.Parameters.AddWithValue("@mcodalum", objMatriculaBE.codAlumno);

                cmd.Parameters.AddWithValue("@mestado", objMatriculaBE.estado);
                cmd.Parameters.AddWithValue("@ausuRegistro", objMatriculaBE.usuRegistro);


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

        public Boolean ActualizarMatricula(MatriculaBE objMatriculaBE)
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarMatricula";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mcodigo", objMatriculaBE.codMatricula);
                cmd.Parameters.AddWithValue("@mcodseccio", objMatriculaBE.codSeccion);
                cmd.Parameters.AddWithValue("@mcodalum", objMatriculaBE.codAlumno);
                cmd.Parameters.AddWithValue("@mestado", objMatriculaBE.estado);
                cmd.Parameters.AddWithValue("@ausuUltMod", objMatriculaBE.usuUltMod);



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
