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
    public partial class MatriculaMan01 : Form
    {
        MatriculaBL objMatriculaBL = new MatriculaBL();
        DataView dtv;
        public MatriculaMan01()
        {
            InitializeComponent();
        }

        private void MatriculaMan01_Load(object sender, EventArgs e)
        {
            CargarDatos("");
        }
        private void CargarDatos(String strFiltro)
        {
            dtv = new DataView(objMatriculaBL.ListarMatricula());
            dtv.RowFilter = "codMatricula like '%" + strFiltro + "%'";
            dtgDatos.DataSource = dtv;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                MatriculaMan02 objMan02 = new MatriculaMan02();
                objMan02.ShowDialog();

                CargarDatos(txtFiltro.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                MatriculaMan03 objMan03 = new MatriculaMan03();
                objMan03.Codigo = dtgDatos.CurrentRow.Cells[0].Value.ToString();
                objMan03.ShowDialog();

                CargarDatos(txtFiltro.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
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
