namespace ProyMatricula_GUI
{
    partial class SeccionMan03
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
            this.cboGrado = new System.Windows.Forms.ComboBox();
            this.cboAula = new System.Windows.Forms.ComboBox();
            this.cboProfesor = new System.Windows.Forms.ComboBox();
            this.txtAforo = new System.Windows.Forms.TextBox();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAforo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboGrado
            // 
            this.cboGrado.FormattingEnabled = true;
            this.cboGrado.Location = new System.Drawing.Point(155, 104);
            this.cboGrado.Name = "cboGrado";
            this.cboGrado.Size = new System.Drawing.Size(121, 23);
            this.cboGrado.TabIndex = 0;
            // 
            // cboAula
            // 
            this.cboAula.FormattingEnabled = true;
            this.cboAula.Location = new System.Drawing.Point(461, 104);
            this.cboAula.Name = "cboAula";
            this.cboAula.Size = new System.Drawing.Size(121, 23);
            this.cboAula.TabIndex = 1;
            // 
            // cboProfesor
            // 
            this.cboProfesor.FormattingEnabled = true;
            this.cboProfesor.Location = new System.Drawing.Point(155, 177);
            this.cboProfesor.Name = "cboProfesor";
            this.cboProfesor.Size = new System.Drawing.Size(121, 23);
            this.cboProfesor.TabIndex = 2;
            // 
            // txtAforo
            // 
            this.txtAforo.Location = new System.Drawing.Point(461, 177);
            this.txtAforo.Name = "txtAforo";
            this.txtAforo.Size = new System.Drawing.Size(100, 23);
            this.txtAforo.TabIndex = 3;
            this.txtAforo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstado_keyPress);
            // 
            // txtTurno
            // 
            this.txtTurno.Location = new System.Drawing.Point(157, 255);
            this.txtTurno.MaxLength = 1;
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.Size = new System.Drawing.Size(100, 23);
            this.txtTurno.TabIndex = 4;
            this.txtTurno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLetra_keyPress);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(461, 246);
            this.txtEstado.MaxLength = 1;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(100, 23);
            this.txtEstado.TabIndex = 5;
            this.txtEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstado_keyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Codigo";
            // 
            // lblCodigo
            // 
            this.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCodigo.Location = new System.Drawing.Point(155, 48);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(100, 23);
            this.lblCodigo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Grado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Profesor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Turno";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Aula";
            // 
            // lblAforo
            // 
            this.lblAforo.AutoSize = true;
            this.lblAforo.Location = new System.Drawing.Point(367, 180);
            this.lblAforo.Name = "lblAforo";
            this.lblAforo.Size = new System.Drawing.Size(37, 15);
            this.lblAforo.TabIndex = 12;
            this.lblAforo.Text = "Aforo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(372, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Estado";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(406, 337);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 14;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(554, 337);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // SeccionMan03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblAforo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtTurno);
            this.Controls.Add(this.txtAforo);
            this.Controls.Add(this.cboProfesor);
            this.Controls.Add(this.cboAula);
            this.Controls.Add(this.cboGrado);
            this.Name = "SeccionMan03";
            this.Text = "Actualizar Seccion";
            this.Load += new System.EventHandler(this.SeccionMan03_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cboGrado;
        private ComboBox cboAula;
        private ComboBox cboProfesor;
        private TextBox txtAforo;
        private TextBox txtTurno;
        private TextBox txtEstado;
        private Label label1;
        private Label lblCodigo;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblAforo;
        private Label label8;
        private Button btnGrabar;
        private Button btnCancelar;
    }
}