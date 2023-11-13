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
    public partial class AulaMan03 : Form
    {
        AulaBL objAulaBL = new AulaBL();
        AulaBE objAulaBE = new AulaBE();
        public AulaMan03()
        {
            InitializeComponent();
        }
        public String Codigo { get; set; }
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
                if (estado > 2 )
                {
                    throw new Exception("El estado debe ser 1 [Disponible]   2[No disponible]");
                }



                objAulaBE.codigoAula = lblCodigo.Text;
                objAulaBE.nombreAula = txtNombre.Text.Trim();

                objAulaBE.estado = Convert.ToInt16(txtEstado.Text);


                objAulaBE.usuUltMod = clsCredenciales.Usuario;

                if (objAulaBL.ActualizarAula(objAulaBE) == true)
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

        private void AulaMan03_Load(object sender, EventArgs e)
        {
            try
            {



                objAulaBE = objAulaBL.ConsultarAula(this.Codigo);



                lblCodigo.Text = objAulaBE.codigoAula;
                txtNombre.Text = objAulaBE.nombreAula;

                txtEstado.Text = objAulaBE.estado.ToString();
               


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

        }
    }
}
