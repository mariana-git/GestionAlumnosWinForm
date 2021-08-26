using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Programa1DB
{
    public partial class Form1 : Form
    {


        //variables para mover el form  al no tener bordes
        public int xClick = 0, yClick = 0; 

        //evento MouseMove del Form, para desplazarlo
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
        public Form1()
        {
            InitializeComponent();
            AcceptButton = btnConsultar;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private Form formActivo = null;
        private void abrirFormHija (Form FormHija)
        {
            if (formActivo != null) formActivo.Dispose();
            formActivo = FormHija;
            FormHija.TopLevel = false;
            panelHijas.Controls.Add(FormHija);
            panelHijas.Tag = FormHija;
            FormHija.BringToFront();
            FormHija.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            abrirFormHija(new Consultar(txtBuscar.Text));
            txtBuscar.Text = "";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            abrirFormHija(new Insertar());
            txtBuscar.Text = "";
        }

        private void btnEliminiar_Click(object sender, EventArgs e)
        {
            abrirFormHija(new Eliminar());
            txtBuscar.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            abrirFormHija(new Modificar());
            txtBuscar.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
