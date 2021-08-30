using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Programa1DB
{
    public partial class Insertar : Form
    {
        public Insertar()
        {
            InitializeComponent();
            AcceptButton = btnAgregar;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text, apellido = txtApellido.Text, direccion = txtDireccion.Text;
            try
            {
                OperacionesSql conectar = new OperacionesSql();
                conectar.Insertar(nombre, apellido, direccion);
                MessageBox.Show("Registro agregado con éxito!", "VIVA PERON");
                this.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
