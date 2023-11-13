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
    public partial class ProfesorMan01 : Form
    {
        ProfesorBL objProfesorBL = new ProfesorBL();
        DataView dtv;

        public ProfesorMan01()
        {
            InitializeComponent();
        }

        private void ProfesorMan01_Load(object sender, EventArgs e)
        {
            CargarDatos("");
        }
        private void CargarDatos(String strFiltro)
        {
            dtv = new DataView(objProfesorBL.ListarProfesor());
            dtv.RowFilter = "nomProfesor like '%" + strFiltro + "%'";
            dtgDatos.DataSource = dtv;
            //lbl.Text = dtgDatos.Rows.Count.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ProfesorMan02 objMan02 = new ProfesorMan02();
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
                ProfesorMan03 objMan03 = new ProfesorMan03();
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
