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
    public partial class ProfesorMan02 : Form
    {
        ProfesorBL objProfesorBL = new ProfesorBL();
        ProfesorBE objProfesorBE = new ProfesorBE();
        UbigeoBL objUbigeoBL = new UbigeoBL();
        EspecialidadBL objEspecialidadBL = new EspecialidadBL();
        public ProfesorMan02()
        {
            InitializeComponent();
        }

        private void btnAgregarFoto_Click(object sender, EventArgs e)
        {
            try
            {

                openFileDialog1.Multiselect = false;
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Fotos (Solo jpg)) | *.jpg";
                openFileDialog1.ShowDialog();
                pcbFoto.Image = Image.FromFile(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ProfesorMan02_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = objUbigeoBL.ListarUbigeo();
                DataRow dr;
                dr = dt.NewRow();
                dr["idUbigeo"] = 0;
                dr["nomDistrito"] = "--Seleccione--";
                dt.Rows.InsertAt(dr, 0);

                cboUbigeo.DataSource = dt;
                cboUbigeo.ValueMember = "idUbigeo";
                cboUbigeo.DisplayMember = "nomDistrito";

                dt = objEspecialidadBL.ListarEspecialidad();
                dr = dt.NewRow();
                dr["codigoEspecialidad"] = 0;
                dr["nomEspecialidad"] = "--Seleccione--";
                dt.Rows.InsertAt(dr, 0);

                cboEspecialidad.DataSource = dt;
                cboEspecialidad.ValueMember = "codigoEspecialidad";
                cboEspecialidad.DisplayMember = "nomEspecialidad";
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
                if (txtDni.Text.Trim() == String.Empty)
                {
                    throw new Exception("El dni es obligatorio");
                }
                if (txtApePaterno.Text.Trim() == String.Empty)
                {
                    throw new Exception("El apellido es obligatorio");
                }
                if (txtApeMaterno.Text.Trim() == String.Empty)
                {
                    throw new Exception("El apellido es obligatorio");
                }
                if (txtDireccion.Text.Trim() == String.Empty)
                {
                    throw new Exception("La direccion es obligatoria");
                }
                if (txtCorreo.Text.Trim() == String.Empty)
                {
                    throw new Exception("El correo es obligatorio");
                }
                if (txtEstado.Text.Trim() == String.Empty)
                {
                    throw new Exception("El estado es obligatorio");
                }
                if (txtTelefono.Text.Trim() == String.Empty)
                {
                    throw new Exception("El telefono es obligatorio");
                }

                Int16 estado = Convert.ToInt16(txtEstado.Text);
                if (estado > 2)
                {
                    throw new Exception("El estado debe ser 1 [Disponible]   2[No disponible]");
                }
                //Tras validar
                if (cboUbigeo.SelectedIndex == 0)
                {
                    throw new Exception("Debe seleccionar ubigeo");
                }
                if (cboEspecialidad.SelectedIndex == 0)
                {
                    throw new Exception("Debe seleccionar una especialidad");
                }

                if (pcbFoto.Image == null)
                {
                    Byte[] array = new byte[0];
                    objProfesorBE.fotoProfesor = array;
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pcbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    objProfesorBE.fotoProfesor = ms.GetBuffer();
                }

                objProfesorBE.idUbigeo = Convert.ToString(cboUbigeo.SelectedValue);
                objProfesorBE.nomProfesor = txtNombre.Text.Trim();
                objProfesorBE.apePaterProfesor = txtApePaterno.Text.Trim();
                objProfesorBE.apeMaterProfesor = txtApeMaterno.Text.Trim();
                objProfesorBE.dniProfesor = txtDni.Text.Trim();
                objProfesorBE.telefonoProfesor = txtTelefono.Text.Trim();
                objProfesorBE.direccionProfesor = txtDireccion.Text.Trim();
                objProfesorBE.correoProfesor = txtCorreo.Text.Trim();
                objProfesorBE.fechaNacimientoProfesor = dtpFechaReg.Value.Date;
                objProfesorBE.codigoEspecialidad = Convert.ToString(cboEspecialidad.SelectedValue);

                objProfesorBE.estado = Convert.ToInt16(txtEstado.Text);

                objProfesorBE.usuRegistro = clsCredenciales.Usuario;

                if (objProfesorBL.InsertarProfesor(objProfesorBE) == true)
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

        private void txtLetra_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar)
                 || e.KeyChar == (char)Keys.Back);
        }

        private void txtEstado_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar)
                   || e.KeyChar == (char)Keys.Back);
        }
    }
}
