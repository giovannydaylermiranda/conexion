using System.Drawing;          // Point, Size, Font
using System.Windows.Forms;    // Label, Button, TextBox, DataGridView

namespace Conexion1_CodigoClase
{
    // Este archivo lo usa el DISEÑADOR de Visual Studio: aquí se crean y ubican los controles.
    // Normalmente no se escribe a mano: se arrastran los controles desde el Cuadro de herramientas.
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnProbar = new Button();
            btnListar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscarSP = new Button();
            dgvDatos = new DataGridView();
            lblEstado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(14, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(442, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Forma 1 · Cadena escrita en una clase";
            // 
            // btnProbar
            // 
            btnProbar.Location = new Point(118, 64);
            btnProbar.Margin = new Padding(3, 4, 3, 4);
            btnProbar.Name = "btnProbar";
            btnProbar.Size = new Size(194, 43);
            btnProbar.TabIndex = 1;
            btnProbar.Text = "1. Probar conexión";
            btnProbar.Click += BtnProbar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(719, 64);
            btnListar.Margin = new Padding(3, 4, 3, 4);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(194, 43);
            btnListar.TabIndex = 2;
            btnListar.Text = "2. Listar clientes";
            btnListar.Click += BtnListar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(14, 127);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(139, 20);
            lblBuscar.TabIndex = 3;
            lblBuscar.Text = "Nombre o apellido:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(160, 123);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(228, 27);
            txtBuscar.TabIndex = 4;
            txtBuscar.Text = "Rojas";
            // 
            // btnBuscarSP
            // 
            btnBuscarSP.Location = new Point(400, 117);
            btnBuscarSP.Margin = new Padding(3, 4, 3, 4);
            btnBuscarSP.Name = "btnBuscarSP";
            btnBuscarSP.Size = new Size(331, 43);
            btnBuscarSP.TabIndex = 5;
            btnBuscarSP.Text = "3. Buscar con procedimiento almacenado";
            btnBuscarSP.Click += BtnBuscarSP_Click;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.ColumnHeadersHeight = 29;
            dgvDatos.Location = new Point(51, 168);
            dgvDatos.Margin = new Padding(3, 4, 3, 4);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.Size = new Size(866, 453);
            dgvDatos.TabIndex = 6;
            // 
            // lblEstado
            // 
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEstado.Location = new Point(14, 640);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(983, 53);
            lblEstado.TabIndex = 7;
            lblEstado.Text = "Presiona un botón para empezar.";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 708);
            Controls.Add(lblTitulo);
            Controls.Add(btnProbar);
            Controls.Add(btnListar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscarSP);
            Controls.Add(dgvDatos);
            Controls.Add(lblEstado);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TecnoHogar · Forma 1 · Cadena escrita en una clase";
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private Button btnProbar;
        private Button btnListar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscarSP;
        private DataGridView dgvDatos;
        private Label lblEstado;
    }
}
