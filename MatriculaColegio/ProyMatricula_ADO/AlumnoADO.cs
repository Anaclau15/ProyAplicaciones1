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
    public class AlumnoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
        SqlDataAdapter ada;
        public DataTable ListarAlumno()
        {
            try
            {

                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarAlumno";
                cmd.Parameters.Clear();


                DataSet dts = new DataSet();
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Alumnos");
                return dts.Tables["Alumnos"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AlumnoBE ConsultarAlumno(String strCodigo)
        {

            try
            {
               
                AlumnoBE objAlumnoBE = new AlumnoBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarAlumno";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@acodigo", strCodigo);

              
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objAlumnoBE.codAlumno = dtr["codAlumno"].ToString();
                    objAlumnoBE.nomAlumno = dtr["nomAlumno"].ToString();
                    objAlumnoBE.apePaterAlumno = dtr["apePaterAlumno"].ToString();
                    objAlumnoBE.apeMaterAlumno = dtr["apeMaterAlumno"].ToString();
                    objAlumnoBE.dniAlumno = dtr["dniAlumno"].ToString();
                    objAlumnoBE.direccionAlumno = dtr["direccionAlumno"].ToString();
                    objAlumnoBE.correoAlumno = dtr["correoAlumno"].ToString();
                    objAlumnoBE.fechaNacimientoAlumno = Convert.ToDateTime(dtr["fechaNacimientoAlumno"]);
                    objAlumnoBE.fotoAlumno = (byte[])dtr["fotoAlumno"];
                    objAlumnoBE.idUbigeo = dtr["idUbigeo"].ToString();
                    objAlumnoBE.estado = Convert.ToInt16(dtr["estado"]);
                }
                dtr.Close();
                return objAlumnoBE;
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
        public Boolean InsertarAlumno(AlumnoBE objAlumnoBE)
        {

            try
            {
                
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarAlumno";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@anom", objAlumnoBE.nomAlumno);
                cmd.Parameters.AddWithValue("@apater", objAlumnoBE.apePaterAlumno);
                cmd.Parameters.AddWithValue("@amater", objAlumnoBE.apeMaterAlumno);
                cmd.Parameters.AddWithValue("@adni", objAlumnoBE.dniAlumno);
                cmd.Parameters.AddWithValue("@adire", objAlumnoBE.direccionAlumno);
                cmd.Parameters.AddWithValue("@acorreo", objAlumnoBE.correoAlumno);
                cmd.Parameters.AddWithValue("@afecha", objAlumnoBE.fechaNacimientoAlumno);
                cmd.Parameters.AddWithValue("@afoto", objAlumnoBE.fotoAlumno);
                cmd.Parameters.AddWithValue("@aIdUbigeo", objAlumnoBE.idUbigeo);
                cmd.Parameters.AddWithValue("@ausuRegistro", objAlumnoBE.usuRegistro);
                cmd.Parameters.AddWithValue("@aestado", objAlumnoBE.estado);


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

        public Boolean ActualizarAlumno(AlumnoBE objAlumnoBE)
        {
            try
            {
              
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarAlumno";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@acodigo", objAlumnoBE.codAlumno);
                cmd.Parameters.AddWithValue("@anom", objAlumnoBE.nomAlumno);
                cmd.Parameters.AddWithValue("@apater", objAlumnoBE.apePaterAlumno);
                cmd.Parameters.AddWithValue("@amater", objAlumnoBE.apeMaterAlumno);
                cmd.Parameters.AddWithValue("@adni", objAlumnoBE.dniAlumno);
                cmd.Parameters.AddWithValue("@adire", objAlumnoBE.direccionAlumno);
                cmd.Parameters.AddWithValue("@acorreo", objAlumnoBE.correoAlumno);
                cmd.Parameters.AddWithValue("@afecha", objAlumnoBE.fechaNacimientoAlumno);
                cmd.Parameters.AddWithValue("@afoto", objAlumnoBE.fotoAlumno);
                cmd.Parameters.AddWithValue("@aIdUbigeo", objAlumnoBE.idUbigeo);
                cmd.Parameters.AddWithValue("@ausuUltMod", objAlumnoBE.usuUltMod);
                cmd.Parameters.AddWithValue("@aestado", objAlumnoBE.estado);



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
