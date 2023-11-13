using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyMatricula_BL;
using ProyMatricula_BE;
namespace ProyMatricula_GUI
{
    public partial class MatriculaMan03 : Form
    {
        MatriculaBL objMatriculaBL = new MatriculaBL();
        MatriculaBE objMatriculaBE = new MatriculaBE();
        SeccionBL objSeccionBL = new SeccionBL();
        AlumnoBL objAlumnoBL = new AlumnoBL();
        public MatriculaMan03()
        {
            InitializeComponent();
        }
        public String Codigo { get; set; }

        private void MatriculaMan03_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = objSeccionBL.ListarSeccion();
                DataRow dr;
                dr = dt.NewRow();
                dr["codSeccion"] = 0;
                dr["codSeccion"] = "--Seleccione--";
                dt.Rows.InsertAt(dr, 0);

                cboSeccion.DataSource = dt;
                cboSeccion.ValueMember = "codSeccion";
                cboSeccion.DisplayMember = "codSeccion";


                dt = objAlumnoBL.ListarAlumno();
                dr = dt.NewRow();
                dr["codAlumno"] = 0;
                dr["nomAlumno"] = "--Seleccione--";
                dt.Rows.InsertAt(dr, 0);

                cboAlumno.DataSource = dt;
                cboAlumno.ValueMember = "codAlumno";
                cboAlumno.DisplayMember = "nomAlumno";




                objMatriculaBE = objMatriculaBL.ConsultarMatricula(this.Codigo);



                lblCodigo.Text = objMatriculaBE.codMatricula;
              



                txtEstado.Text = objMatriculaBE.estado.ToString();
                cboSeccion.SelectedValue = objMatriculaBE.codSeccion;
                cboAlumno.SelectedValue = objMatriculaBE.codAlumno;

               


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEstado.Text.Trim() == String.Empty)
                {
                    throw new Exception("El estado es obligatorio");
                }

                Int16 estado = Convert.ToInt16(txtEstado.Text);
                if (estado > 2)
                {
                    throw new Exception("El estado debe ser 1 [Disponible]   2[No disponible]");
                }
                //Tras validar
                if (cboSeccion.SelectedIndex == 0)
                {
                    throw new Exception("Debe seleccionar una Seccion");
                }
                if (cboAlumno.SelectedIndex == 0)
                {
                    throw new Exception("Debe seleccionar a un Alumno");
                }

               



                objMatriculaBE.codMatricula = lblCodigo.Text;



                objMatriculaBE.codSeccion = Convert.ToString(cboSeccion.SelectedValue);
                objMatriculaBE.codAlumno = Convert.ToString(cboAlumno.SelectedValue);
                objMatriculaBE.estado = Convert.ToInt16(txtEstado.Text);


                objMatriculaBE.usuUltMod = clsCredenciales.Usuario;

                if (objMatriculaBL.ActualizarMatricula(objMatriculaBE) == true)
                {

                    this.Close();
                }
                else
                {
                    throw new Exception("Error en el proceso, contacte con TI");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtEstado_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar)
                   || e.KeyChar == (char)Keys.Back);


        }
        private void txtLetra_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar)
                 || e.KeyChar == (char)Keys.Back);
        }
    }
}
