using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyMatricula_GUI
{
    public partial class MDIPrincipal : Form
    {
        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnoMan01 alumnoMan01 = new AlumnoMan01();
            alumnoMan01.MdiParent = this;
            alumnoMan01.Show();
        }

        private void mdiFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mdiFormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult vrpta;
            vrpta = MessageBox.Show("Seguro de salir del aplicativo?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (vrpta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            this.lblSesion.Text = clsCredenciales.Usuario;
            this.Text = this.Text + " - Bienvenido: " + this.lblSesion.Text;
            if (clsCredenciales.Nivel == 1)
             {
                mantenimientoToolStripMenuItem.Visible = true;
                consultasToolStripMenuItem.Visible = true;
                salirDelSistemaToolStripMenuItem.Visible = true;
                consultasToolStripMenuItem.Visible = true;
             }
             else if (clsCredenciales.Nivel == 2)
             {
                mantenimientoToolStripMenuItem.Visible = false;
                consultasToolStripMenuItem.Visible = true;
                consultasToolStripMenuItem.Visible = true;

            }

             
        }

        private void gestionAulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AulaMan01 aulaMan01 = new AulaMan01();
            aulaMan01.MdiParent = this;
            aulaMan01.Show();
        }

        private void gestionCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CursoMan01 cursoMan01 = new CursoMan01();
            cursoMan01.MdiParent = this;
            cursoMan01.Show();
        }

        private void gestionSeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeccionMan01 seccionMan01 = new SeccionMan01();
            seccionMan01.MdiParent = this;
            seccionMan01.Show();
        }

        private void gestionProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfesorMan01 profesorMan01 = new ProfesorMan01();
            profesorMan01.MdiParent = this;
            profesorMan01.Show();
        }

        private void gestionMatriculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatriculaMan01 matriculaMan01 = new MatriculaMan01();
            matriculaMan01.MdiParent = this;
            matriculaMan01.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioMan01 usuarioMan01 = new UsuarioMan01();
            usuarioMan01.MdiParent = this;
            usuarioMan01.Show();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MDIPrincipal_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
