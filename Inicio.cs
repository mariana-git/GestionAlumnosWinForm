using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Programa1DB
{
    public partial class Inicio : Form
    {
        #region ATRIBUTOS
        
        private int xClick = 0, yClick = 0;//variables para mover el form  al no tener bordes
        private Form formActivo = null; //variable para manipular en el metodo de Control del Formulario Activo

        #endregion

        #region MÉTODOS
        public Inicio()
        {
            InitializeComponent();
            AcceptButton = btnConsultar;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        //evento MouseMove del Form, para desplazarlo
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { Left += e.X - xClick; Top += e.Y - yClick; }
        }
        private void abrirFormHija(Form FormHija)
        {
            //Controla que solo haya un formulario abierto dentro del Panel
            if (formActivo != null) formActivo.Dispose();
            formActivo = FormHija;
            FormHija.TopLevel = false;
            panelHijas.Controls.Add(FormHija);
            panelHijas.Tag = FormHija;
            FormHija.BringToFront();
            FormHija.Show();
        }
        #endregion

        #region BOTONES
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            abrirFormHija(new Consultar(txtBuscar.Text));
            txtBuscar.Text = "";
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            abrirFormHija(new Insertar());
            txtBuscar.Text = "";
        }

        private void BtnEliminiar_Click(object sender, EventArgs e)
        {
            abrirFormHija(new Eliminar());
            txtBuscar.Text = "";
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            abrirFormHija(new Modificar());
            txtBuscar.Text = "";
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        #endregion
    }
}
