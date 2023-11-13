namespace ProyMatricula_GUI
{
    partial class MDIPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionAulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionSeccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionProfesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionMatriculaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSesion = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.salirDelSistemaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionToolStripMenuItem,
            this.gestionAulaToolStripMenuItem,
            this.gestionCursoToolStripMenuItem,
            this.gestionSeccionToolStripMenuItem,
            this.gestionProfesorToolStripMenuItem,
            this.gestionMatriculaToolStripMenuItem});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            this.gestionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.gestionToolStripMenuItem.Text = "Gestion Alumno";
            this.gestionToolStripMenuItem.Click += new System.EventHandler(this.gestionToolStripMenuItem_Click);
            // 
            // gestionAulaToolStripMenuItem
            // 
            this.gestionAulaToolStripMenuItem.Name = "gestionAulaToolStripMenuItem";
            this.gestionAulaToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.gestionAulaToolStripMenuItem.Text = "Gestion Aula";
            this.gestionAulaToolStripMenuItem.Click += new System.EventHandler(this.gestionAulaToolStripMenuItem_Click);
            // 
            // gestionCursoToolStripMenuItem
            // 
            this.gestionCursoToolStripMenuItem.Name = "gestionCursoToolStripMenuItem";
            this.gestionCursoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.gestionCursoToolStripMenuItem.Text = "Gestion Curso";
            this.gestionCursoToolStripMenuItem.Click += new System.EventHandler(this.gestionCursoToolStripMenuItem_Click);
            // 
            // gestionSeccionToolStripMenuItem
            // 
            this.gestionSeccionToolStripMenuItem.Name = "gestionSeccionToolStripMenuItem";
            this.gestionSeccionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.gestionSeccionToolStripMenuItem.Text = "Gestion Seccion";
            this.gestionSeccionToolStripMenuItem.Click += new System.EventHandler(this.gestionSeccionToolStripMenuItem_Click);
            // 
            // gestionProfesorToolStripMenuItem
            // 
            this.gestionProfesorToolStripMenuItem.Name = "gestionProfesorToolStripMenuItem";
            this.gestionProfesorToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.gestionProfesorToolStripMenuItem.Text = "Gestion Profesor";
            this.gestionProfesorToolStripMenuItem.Click += new System.EventHandler(this.gestionProfesorToolStripMenuItem_Click);
            // 
            // gestionMatriculaToolStripMenuItem
            // 
            this.gestionMatriculaToolStripMenuItem.Name = "gestionMatriculaToolStripMenuItem";
            this.gestionMatriculaToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.gestionMatriculaToolStripMenuItem.Text = "Gestion Matricula";
            this.gestionMatriculaToolStripMenuItem.Click += new System.EventHandler(this.gestionMatriculaToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // salirDelSistemaToolStripMenuItem
            // 
            this.salirDelSistemaToolStripMenuItem.Name = "salirDelSistemaToolStripMenuItem";
            this.salirDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.salirDelSistemaToolStripMenuItem.Text = "Salir del Sistema";
            this.salirDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salirDelSistemaToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl1,
            this.lblSesion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl1
            // 
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(47, 17);
            this.lbl1.Text = "Usuario";
            // 
            // lblSesion
            // 
            this.lblSesion.AutoSize = false;
            this.lblSesion.Name = "lblSesion";
            this.lblSesion.Size = new System.Drawing.Size(40, 17);
            this.lblSesion.Text = "....";
            // 
            // MDIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyMatricula_GUI.Properties.Resources.pizarra;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIPrincipal";
            this.Text = "MDIPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mdiFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mdiFormClosed);
            this.Load += new System.EventHandler(this.MDIPrincipal_Load);
            this.Resize += new System.EventHandler(this.MDIPrincipal_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mantenimientoToolStripMenuItem;
        private ToolStripMenuItem gestionToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbl1;
        private ToolStripStatusLabel lblSesion;
        private ToolStripMenuItem gestionAulaToolStripMenuItem;
        private ToolStripMenuItem gestionCursoToolStripMenuItem;
        private ToolStripMenuItem gestionSeccionToolStripMenuItem;
        private ToolStripMenuItem gestionProfesorToolStripMenuItem;
        private ToolStripMenuItem gestionMatriculaToolStripMenuItem;
        private ToolStripMenuItem consultasToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem salirDelSistemaToolStripMenuItem;
    }
}