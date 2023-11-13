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
    public partial class AlumnoMan03 : Form
    {
        AlumnoBL objAlumnoBL = new AlumnoBL();
        AlumnoBE objAlumnoBE = new AlumnoBE();
        UbigeoBL objUbigeoBL = new UbigeoBL();
        public AlumnoMan03()
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

                if (pcbFoto.Image!= null)
                {
                    Byte[] array = new byte[0];
                    if (objAlumnoBE.fotoAlumno.SequenceEqual(array))
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        pcbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        objAlumnoBE.fotoAlumno = ms.GetBuffer();
                    }
                    else
                    {
                        Bitmap imageActual = ByteToImage(objAlumnoBE.fotoAlumno);
                        Bitmap pictureBoxIma = (Bitmap)pcbFoto.Image;

                        bool a = Equalst(imageActual, pictureBoxIma);
                        if (a == false)
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            pcbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            objAlumnoBE.fotoAlumno = ms.GetBuffer();
                        }
                    }

                  
                }
                



                objAlumnoBE.codAlumno = lblCodigo.Text;
                objAlumnoBE.nomAlumno=txtNombre.Text.Trim();
                objAlumnoBE.apePaterAlumno = txtApePaterno.Text.Trim();
                objAlumnoBE.apeMaterAlumno = txtApeMaterno.Text.Trim(); 
                objAlumnoBE.dniAlumno= txtDni.Text.Trim();
                objAlumnoBE.direccionAlumno=txtDireccion.Text.Trim();
                objAlumnoBE.correoAlumno=txtCorreo.Text.Trim();
                objAlumnoBE.fechaNacimientoAlumno = dtpFechaReg.Value.Date;
               

                objAlumnoBE.idUbigeo = Convert.ToString(cboUbigeo.SelectedValue);
                objAlumnoBE.estado = Convert.ToInt16(txtEstado.Text);


                objAlumnoBE.usuUltMod = clsCredenciales.Usuario;

                if (objAlumnoBL.ActualizarAlumno(objAlumnoBE) == true)
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
       

     
        private static bool Equalst(Bitmap bmp1, Bitmap bmp2)
        {
            if (!bmp1.Size.Equals(bmp2.Size))
            {
                return false;
            }
            for (int x = 0; x < bmp1.Width; ++x)
            {
                for (int y = 0; y < bmp1.Height; ++y)
                {
                    if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlumnoMan03_Load(object sender, EventArgs e)
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



               
                objAlumnoBE = objAlumnoBL.ConsultarAlumno(this.Codigo);

             

                lblCodigo.Text = objAlumnoBE.codAlumno;
                txtNombre.Text = objAlumnoBE.nomAlumno;
                txtApePaterno.Text = objAlumnoBE.apePaterAlumno;
                txtApeMaterno.Text = objAlumnoBE.apeMaterAlumno;
                txtDni.Text = objAlumnoBE.dniAlumno.ToString();
                txtDireccion.Text = objAlumnoBE.direccionAlumno;
                txtCorreo.Text = objAlumnoBE.correoAlumno;
                dtpFechaReg.Text = objAlumnoBE.fechaNacimientoAlumno.ToShortDateString();

               


                txtEstado.Text = objAlumnoBE.estado.ToString();
                cboUbigeo.SelectedValue = objAlumnoBE.idUbigeo;


                if (objAlumnoBE.fotoAlumno.Length==0)
                {
                    pcbFoto.Image = null;
                }
                else
                {
                    pcbFoto.Image = ByteToImage(objAlumnoBE.fotoAlumno);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
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
