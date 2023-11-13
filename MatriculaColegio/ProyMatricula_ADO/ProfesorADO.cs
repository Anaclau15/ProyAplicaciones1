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
    public class ProfesorADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        SqlDataAdapter ada;

        public DataTable ListarProfesor()
        {
            try
            {
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Listarprofesor";

                cmd.Parameters.Clear();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Profesores");
                return dts.Tables["Profesores"];
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ProfesorBE ConsultarProfesor(String strCodigo)
        {

            try
            {

                ProfesorBE objProfesorBE = new ProfesorBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarProfesor";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@pcodigo", strCodigo);


                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objProfesorBE.codProfesor = dtr["codProfesor"].ToString();
                    objProfesorBE.idUbigeo = dtr["idUbigeo"].ToString();
                    objProfesorBE.nomProfesor = dtr["nomProfesor"].ToString();
                    objProfesorBE.apePaterProfesor = dtr["apePaterProfesor"].ToString();
                    objProfesorBE.apeMaterProfesor = dtr["apeMaterProfesor"].ToString();
                    objProfesorBE.dniProfesor = dtr["dniProfesor"].ToString();
                    objProfesorBE.telefonoProfesor = dtr["telefonoProfesor"].ToString();
                    objProfesorBE.direccionProfesor = dtr["direccionProfesor"].ToString();
                    objProfesorBE.correoProfesor = dtr["correoProfesor"].ToString();
                    objProfesorBE.fechaNacimientoProfesor = Convert.ToDateTime(dtr["fechaNacimientoProfesor"]);
                    objProfesorBE.codigoEspecialidad = dtr["codigoEspecialidad"].ToString();
                    objProfesorBE.fotoProfesor = (byte[])dtr["fotoProfesor"];
                    objProfesorBE.estado = Convert.ToInt16(dtr["estado"]);
                }
                dtr.Close();
                return objProfesorBE;
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
        public Boolean InsertarProfesor(ProfesorBE objProfesorBE)
        {

            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarProfesor";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@pIdUbigeo", objProfesorBE.idUbigeo);
                cmd.Parameters.AddWithValue("@pnom", objProfesorBE.nomProfesor);
                cmd.Parameters.AddWithValue("@ppater", objProfesorBE.apePaterProfesor);
                cmd.Parameters.AddWithValue("@pmater", objProfesorBE.apeMaterProfesor);
                cmd.Parameters.AddWithValue("@pdni", objProfesorBE.dniProfesor);
                cmd.Parameters.AddWithValue("@ptele", objProfesorBE.direccionProfesor);
                cmd.Parameters.AddWithValue("@pcorreo", objProfesorBE.correoProfesor);
                cmd.Parameters.AddWithValue("@pdire", objProfesorBE.direccionProfesor);
                cmd.Parameters.AddWithValue("@pfecha", objProfesorBE.fechaNacimientoProfesor);
                cmd.Parameters.AddWithValue("@pcodigoEspecialidad", objProfesorBE.codigoEspecialidad);
                cmd.Parameters.AddWithValue("@pfoto", objProfesorBE.fotoProfesor);
               
                cmd.Parameters.AddWithValue("@ausuRegistro", objProfesorBE.usuRegistro);
                cmd.Parameters.AddWithValue("@pestado", objProfesorBE.estado);


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

        public Boolean ActualizarProfesor(ProfesorBE objProfesorBE)
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarProfesor";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@pcodigo", objProfesorBE.codProfesor);
                cmd.Parameters.AddWithValue("@pIdUbigeo", objProfesorBE.idUbigeo);
                cmd.Parameters.AddWithValue("@pnom", objProfesorBE.nomProfesor);
                cmd.Parameters.AddWithValue("@ppater", objProfesorBE.apePaterProfesor);
                cmd.Parameters.AddWithValue("@pmater", objProfesorBE.apeMaterProfesor);
                cmd.Parameters.AddWithValue("@pdni", objProfesorBE.dniProfesor);
                cmd.Parameters.AddWithValue("@ptele", objProfesorBE.telefonoProfesor);
                cmd.Parameters.AddWithValue("@pcorreo", objProfesorBE.correoProfesor);
                cmd.Parameters.AddWithValue("@pdire", objProfesorBE.direccionProfesor);
                cmd.Parameters.AddWithValue("@pfecha", objProfesorBE.fechaNacimientoProfesor);
                cmd.Parameters.AddWithValue("@pcodigoEspecialidad", objProfesorBE.codigoEspecialidad);
                cmd.Parameters.AddWithValue("@pfoto", objProfesorBE.fotoProfesor);
               
                cmd.Parameters.AddWithValue("@ausuUltMod", objProfesorBE.usuUltMod);
                cmd.Parameters.AddWithValue("@pestado", objProfesorBE.estado);



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
