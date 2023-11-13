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
    public partial class AulaMan01 : Form
    {
        AulaBL objAulaBL = new AulaBL();
        DataView dtv;
        public AulaMan01()
        {
            InitializeComponent();
        }

        private void AulaMan01_Load(object sender, EventArgs e)
        {
            CargarDatos("");
        }
        private void CargarDatos(String strFiltro)
        {
            dtv = new DataView(objAulaBL.ListarAula());
            dtv.RowFilter = "nombreAula like '%" + strFiltro + "%'";
            dtgDatos.DataSource = dtv;
            //lbl.Text = dtgDatos.Rows.Count.ToString();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                AulaMan02 objMan02 = new AulaMan02();
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
                AulaMan03 objMan03 = new AulaMan03();
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
