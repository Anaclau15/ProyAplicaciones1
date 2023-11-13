using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using ProyMatricula_BL;
using ProyMatricula_BE;
namespace ProyMatricula_GUI
{
    public partial class AlumnoMan02 : Form
    {
        AlumnoBL objAlumnoBL=new AlumnoBL();
        AlumnoBE objAlumnoBE=new AlumnoBE();
        UbigeoBL objUbigeoBL=new UbigeoBL();
        public AlumnoMan02()
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

        private void AlumnoMan02_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnGrabar_click(object sender, EventArgs e)
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

                if (pcbFoto.Image == null)
                {
                    Byte[] array = new byte[0];
                    objAlumnoBE.fotoAlumno = array;
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pcbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    objAlumnoBE.fotoAlumno = ms.GetBuffer();
                }
                
               




                objAlumnoBE.nomAlumno = txtNombre.Text.Trim();
                objAlumnoBE.apePaterAlumno = txtApePaterno.Text.Trim();
                objAlumnoBE.apeMaterAlumno = txtApeMaterno.Text.Trim();
                objAlumnoBE.dniAlumno = txtDni.Text.Trim();
                objAlumnoBE.direccionAlumno = txtDireccion.Text.Trim();
                objAlumnoBE.correoAlumno = txtCorreo.Text.Trim();
                objAlumnoBE.fechaNacimientoAlumno = dtpFechaReg.Value.Date;
              
                objAlumnoBE.idUbigeo = Convert.ToString(cboUbigeo.SelectedValue);
                objAlumnoBE.estado = Convert.ToInt16(txtEstado.Text);

                objAlumnoBE.usuRegistro = clsCredenciales.Usuario;

                if (objAlumnoBL.InsertarAlumno(objAlumnoBE) == true)
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

        private void txtEstado_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar)
                   || e.KeyChar == (char)Keys.Back);

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLetra_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar)
                 || e.KeyChar == (char)Keys.Back);
        }

        
    }
}
