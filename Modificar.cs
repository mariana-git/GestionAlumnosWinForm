using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Programa1DB
{
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
            AcceptButton = btnMostrar;
            gbxMuestra.Visible = false;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            gbxMuestra.Visible = true;
            string modificar = txtID.Text;

            try
            {
                //instancio la clase Consultas y creo un objeto para conectar y pasar los parámetros de busqueda 
                OperacionesSql conectar = new OperacionesSql();

                var registro = conectar.Consultar(modificar, modificar);

                lblNombre.Text = registro[1].ToString();
                lblApellido.Text = registro[2].ToString();
                lblDireccion.Text = registro[3].ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("NO PUDO REALIZARSE LA CONEXION A LA BBDD\n\n" + error.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string modificar = txtID.Text;
            string nombre = txtNombre.Text, apellido =txtApellido.Text,direccion = txtDireccion.Text;

            if (!(nombre == "" && apellido == "" && direccion == ""))
            {
                try
                {
                    //instancio la clase Consultas y creo un objeto para conectar y pasar los parámetros de busqueda 
                    OperacionesSql conectar = new OperacionesSql();
                    conectar.Modificar(nombre, apellido, direccion, modificar);
                    MessageBox.Show("Registro modificado con éxito!");
                    this.Dispose();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO PUDO REALIZARSE LA CONEXION A LA BBDD\n\n" + error.ToString());
                }
            }
            else MessageBox.Show("No se ingresaron datos a modificar");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }

}
