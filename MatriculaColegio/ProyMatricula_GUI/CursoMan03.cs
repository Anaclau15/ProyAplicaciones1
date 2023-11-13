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
    public partial class CursoMan03 : Form
    {
        CursoBL objCursoBL = new CursoBL();
        CursoBE objCursoBE = new CursoBE();
        GradoBL objGradoBL = new GradoBL();
        public CursoMan03()
        {
            InitializeComponent();
        }
        public String Codigo { get; set; }
        private void CursoMan03_Load(object sender, EventArgs e)
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


                objCursoBE = objCursoBL.ConsultarCurso(this.Codigo);


                lblCodigo.Text = objCursoBE.codCurso;
                txtNombre.Text = objCursoBE.nomCurso;
                txtEstado.Text = objCursoBE.estado.ToString();
                cboGrado.SelectedValue = objCursoBE.codGrado;



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
                if (txtNombre.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre es obligatorio");
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
                    throw new Exception("Debe seleccionar Grado");
                }

              

                objCursoBE.codCurso = lblCodigo.Text;
                objCursoBE.nomCurso = txtNombre.Text.Trim();



                objCursoBE.codGrado = Convert.ToString(cboGrado.SelectedValue);
                objCursoBE.estado = Convert.ToInt16(txtEstado.Text);


                objCursoBE.usuUltMod = clsCredenciales.Usuario;

                if (objCursoBL.ActualizarCurso(objCursoBE) == true)
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

        }
    }
}
