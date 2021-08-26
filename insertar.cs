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
            //los parámetros "sslmode=none;persistsecurityinfo=true" los agregué por una recomendacion en google, ya que no me realizaba la conexion por problemas con SSL
            string conexion = "datasource=127.0.0.1;port=3306;username=root;password=;database=alumnos;sslmode=none;persistsecurityinfo=true;";
            string consulta = "INSERT INTO datos (IDAlumno,Nombre,Apellido,Direccion) VALUES (NULL,'"+txtNombre.Text+"','"+txtApellido.Text+"','"+txtDireccion.Text+"')";


            //intento conexion y guardado de datos, controlo las excepciones para que me muestre el mensaje de error
            try
            {
                using(MySqlConnection conexionBD = new MySqlConnection(conexion))
                {
                    //establezco los pareametros para la conexion con el servidor
                    MySqlCommand comandosBD = new MySqlCommand(consulta, conexionBD);
                    comandosBD.CommandTimeout = 60;
                    conexionBD.Open();
                    MySqlDataReader insertar = comandosBD.ExecuteReader();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            //cierro el form y muestro un mensaje de exito peronista
            this.Close();
            MessageBox.Show("Registro agregado con éxito!", "VIVA PERON");
        }
    }
}
