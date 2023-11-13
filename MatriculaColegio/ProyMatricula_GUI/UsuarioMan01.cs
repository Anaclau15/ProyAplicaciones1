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
namespace ProyMatricula_GUI
{
    public partial class UsuarioMan01 : Form
    {
        UsuarioBL objUsuarioBL = new UsuarioBL();
        DataView dtv;
        public UsuarioMan01()
        {
            InitializeComponent();
        }

        private void UsuarioMan01_Load(object sender, EventArgs e)
        {
            CargarDatos("");
        }
        private void CargarDatos(String strFiltro)
        {
            dtv = new DataView(objUsuarioBL.ListarUsuario());
            dtv.RowFilter = "loginUsuario like '%" + strFiltro + "%'";
            dtgDatos.DataSource = dtv;
            //lbl.Text = dtgDatos.Rows.Count.ToString();
        }
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDatos(txtFiltro.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);

            }
        }

    }
}