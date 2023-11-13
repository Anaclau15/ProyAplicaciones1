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
    public partial class SeccionMan03 : Form
    {
        SeccionBL objSeccionBL = new SeccionBL();
        SeccionBE objSeccionBE = new SeccionBE();
        GradoBL objGradoBL = new GradoBL();
        ProfesorBL objProfesorBL = new ProfesorBL();
        AulaBL objAulaBL = new AulaBL();
        public SeccionMan03()
        {
            InitializeComponent();
        }
        public String Codigo { get; set; }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAforo.Text.Trim() == String.Empty)
                {
                    throw new Exception("El aforo es obligatorio");
                }
                Int16 aforo = Convert.ToInt16(txtAforo.Text.Trim());
                if (aforo > 30)
                {
                    throw new Exception("El aforo no debe ser mayor a 30");
                }
                if (txtTurno.Text.Trim() == String.Empty)
                {
                    throw new Exception("El turno es obligatorio");
                }
                
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
                if (cboGrado.SelectedIndex == 0)
                {
                    throw new Exception("Debe seleccionar un Grado");
                }
                if (cboAula.SelectedIndex == 0)
                {
                    throw new Exception("Debe seleccionar un Aula");
                }
                if (cboProfesor.SelectedIndex == 0)
                {
                    throw new Exception("Debe seleccionar un Pais");
                }
                String result = Convert.ToString(txtTurno.Text.Trim());
                if (result == "T" || result == "M")
                {
                    objSeccionBE.codSeccion = lblCodigo.Text;
                    objSeccionBE.aforo = txtAforo.Text;
                    objSeccionBE.turno = txtTurno.Text;
                    objSeccionBE.codGrado = Convert.ToString(cboGrado.SelectedValue);
                    objSeccionBE.codigoAula = Convert.ToString(cboAula.SelectedValue);
                    objSeccionBE.codProfesor = Convert.ToString(cboProfesor.SelectedValue);
                    objSeccionBE.estado = Convert.ToInt16(txtEstado.Text);


                    objSeccionBE.usuUltMod = clsCredenciales.Usuario;

                    if (objSeccionBL.ActualizarSeccion(objSeccionBE) == true)
                    {

                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Error en el proceso, contacte con TI");
                    }
                }
                else
                {
                    throw new Exception("Los turnos solo pueden ser Mañana[M] o Tarde[T]");
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

        private void SeccionMan03_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = objGradoBL.ListarGrado();
                DataRow dr;
                dr = dt.NewRow();
                dr["codGrado"] = 0;
                dr["nomGrado"] = "--Seleccione--";
                dt.Rows.InsertAt(dr, 0);

                cboGrado.DataSource = dt;
                cboGrado.ValueMember = "codGrado";
                cboGrado.DisplayMember = "nomGrado";

                dt = objAulaBL.ListarAula();
                dr = dt.NewRow();
                dr["codigoAula"] = 0;
                dr["nombreAula"] = "-Seleccione--";
                dt.Rows.InsertAt(dr, 0);
                cboAula.DataSource = dt;
                cboAula.ValueMember = "codigoAula";
                cboAula.DisplayMember = "nombreAula";


                dt = objProfesorBL.ListarProfesor();
                dr = dt.NewRow();
                dr["codProfesor"] = 0;
                dr["nomProfesor"] = "-Seleccione--";
                dt.Rows.InsertAt(dr, 0);
                cboProfesor.DataSource = dt;
                cboProfesor.ValueMember = "codProfesor";
                cboProfesor.DisplayMember = "nomProfesor";




                objSeccionBE = objSeccionBL.ConsultarSeccion(this.Codigo);



                lblCodigo.Text = objSeccionBE.codSeccion;

                txtAforo.Text = objSeccionBE.aforo.ToString();
                txtTurno.Text = objSeccionBE.turno.ToString();


                txtEstado.Text = objSeccionBE.estado.ToString();
                cboGrado.SelectedValue = objSeccionBE.codGrado;
                cboAula.SelectedValue = objSeccionBE.codigoAula;
                cboProfesor.SelectedValue = objSeccionBE.codProfesor;

               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
