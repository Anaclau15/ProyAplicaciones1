using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyMatricula_BE;
using ProyMatricula_BL;

namespace ProyMatricula_GUI
{
    public partial class Login : Form
    {

        Int16 intentos = 0;
        Int16 tiempo = 20;
    
        UsuarioBE objUsuarioBE = new UsuarioBE();
        UsuarioBL objUsuarioBL = new UsuarioBL();
        public Login()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() != "" & txtPassword.Text.Trim() != "")
            {
               
                objUsuarioBE = objUsuarioBL.ConsultarUsuario(txtLogin.Text.Trim());
                if (objUsuarioBE.loginUsuario == null)
                {
                    intentos += 1;
                    ValidaAccesos();
                    MessageBox.Show("Usuario no existe",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intentos += 1;
                    
                }
                else if (txtLogin.Text.Trim() == objUsuarioBE.loginUsuario && txtPassword.Text.Trim() == objUsuarioBE.passwordUsuario)
                {
                    this.Hide();
                    timer1.Enabled = false;
                    clsCredenciales.Usuario = objUsuarioBE.loginUsuario;
                    clsCredenciales.Password = objUsuarioBE.passwordUsuario;
                    clsCredenciales.Nivel = objUsuarioBE.nivel;
                    MDIPrincipal mdi = new MDIPrincipal();
                    mdi.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrectos",
                     "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                    intentos += 1;
                    ValidaAccesos();
                }
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña obligatorios",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                intentos += 1;
                ValidaAccesos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Application.Exit();
        }
        private void ValidaAccesos()
        {
            if (intentos == 3)
            {
                MessageBox.Show("Lo sentimos,  sobrepaso el numero de intentos",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void frmLogin_closed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            Application.Exit();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();

            }
        }

        private void timer1_tick(object sender, EventArgs e)
        {
            tiempo -= 1;
            this.Text = "Ingrese su login y contraseña. Le quedan...." + tiempo;
            if (tiempo == 0)
            {
                MessageBox.Show("Se acabó el tiempo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
