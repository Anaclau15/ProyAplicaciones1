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
    public partial class AlumnoMan01 : Form
    {
        AlumnoBL objAlumnoBL=new AlumnoBL();
        DataView dtv;
        public AlumnoMan01()
        {
            InitializeComponent();
        }

        private void AlumnoMan01_Load(object sender, EventArgs e)
        {
            CargarDatos("");
        }

        private void CargarDatos(String strFiltro)
        {
            dtv = new DataView(objAlumnoBL.ListarAlumno());
            dtv.RowFilter = "nomAlumno like '%" + strFiltro + "%'";
            dtgDatos.DataSource = dtv;
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

        private void btnAgregar_click(object sender, EventArgs e)
        {
            try
            {
              AlumnoMan02 objMan02 = new AlumnoMan02();
                objMan02.ShowDialog();

                CargarDatos(txtFiltro.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AlumnoMan03 objMan03 = new AlumnoMan03();
                objMan03.Codigo = dtgDatos.CurrentRow.Cells[0].Value.ToString();
                objMan03.ShowDialog();

                CargarDatos(txtFiltro.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
