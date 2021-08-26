using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Programa1DB
{
    public partial class Modificar : Form
    {
        static string conexion = "datasource=127.0.0.1;port=3306;username=root;password=;database=alumnos;sslmode=none;persistsecurityinfo=true;";
        public Modificar()
        {
            InitializeComponent();
            AcceptButton = btnMostrar;
            gbxMuestra.Visible = false;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            gbxMuestra.Visible = true;
            string idModif = txtID.Text;
            string consulta = "SELECT * FROM datos WHERE datos.IDAlumno = " + idModif;

            //controlo las excepciones para que me muestre el mensaje de error
            try
            {
                using(MySqlConnection conexionBD = new MySqlConnection(conexion))
                {
                    //establezco los pareametros para la conexion con el servidor
                    MySqlCommand comandosBD = new MySqlCommand(consulta, conexionBD);
                    comandosBD.CommandTimeout = 60;
                    conexionBD.Open();
                    MySqlDataReader leer = comandosBD.ExecuteReader();

                    if (leer.HasRows)
                    {
                        //muestro los datos del registro que corresponden al ID a modificar ingresado por el usuario
                        leer.Read();
                        lblNombre.Text = leer.GetString(1);
                        lblApellido.Text = leer.GetString(2);
                        lblDireccion.Text = leer.GetString(3);
                    }
                }                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idModif = txtID.Text;
            string nombre = txtNombre.Text, apellido =txtApellido.Text,direccion = txtDireccion.Text;       
            string modificacion = "";

            //*************** Desde aca: ESTRUCTURA DE CONTROL PARA MODIFICAR  *****************************
            //verifico los campos completados por el usuario y creo un control para modificar del regsitro solo
            //aquellos que cargo el usuario

            string campos = "";
            if ((txtNombre.Text != "") && (txtApellido.Text != "") && (txtDireccion.Text != "")) campos = "NAD";
            if ((txtNombre.Text != "") && (txtApellido.Text != "") && (txtDireccion.Text == "")) campos = "NA";
            if ((txtNombre.Text != "") && (txtApellido.Text == "") && (txtDireccion.Text == "")) campos = "N";
            if ((txtNombre.Text == "") && (txtApellido.Text != "") && (txtDireccion.Text == "")) campos = "A";
            if ((txtNombre.Text == "") && (txtApellido.Text == "") && (txtDireccion.Text != "")) campos = "D";
            if ((txtNombre.Text == "") && (txtApellido.Text != "") && (txtDireccion.Text != "")) campos = "AD";

            switch (campos)
            {
                case ("NAD"):
                    modificacion = "UPDATE datos SET Nombre = '" + nombre + "', Apellido = '"
                        + apellido + "', Direccion = '" + direccion + "' WHERE IDAlumno = " + idModif + ";";
                    break;

                case ("NA"):
                    modificacion = "UPDATE datos SET Nombre = '" + nombre + "', Apellido = '" + apellido + 
                        "' WHERE IDAlumno = " + idModif + ";";
                    break;

                case ("N"):
                    modificacion = "UPDATE datos SET Nombre = '" + nombre + "' WHERE IDAlumno = " + idModif + ";";
                    break;

                case ("A"):
                    modificacion = "UPDATE datos SET Apellido = '"+ apellido + "' WHERE IDAlumno = " + idModif + ";";
                    break;

                case ("D"):
                    modificacion = "UPDATE datos SET Direccion = '" + direccion + "' WHERE IDAlumno = " + idModif + ";";
                    break;

                case ("AD"):
                    modificacion = "UPDATE datos SET Apellido = '"+ apellido + "', Direccion = '" + direccion + 
                        "' WHERE IDAlumno = " + idModif + ";";
                    break;

                default:                    
                    break;
            }
            //********************  Hasta acá la ESTRUCTURA DE CONTROL PARA MODIFICACIONES  ***********************

            if (modificacion != "")
            {
                //intento conexion y guardado de datos, controlo las excepciones para que me muestre el mensaje de error
                try
                {
                    using (MySqlConnection conexionBD = new MySqlConnection(conexion))
                    {
                        //establezco los pareametros para la conexion con el servidor
                        MySqlCommand comandos2BD = new MySqlCommand(modificacion, conexionBD);
                        comandos2BD.CommandTimeout = 60;
                        conexionBD.Open();
                        MySqlDataReader modificar = comandos2BD.ExecuteReader();
                        MessageBox.Show("Registro modificado con éxito!", "VIVA PERON");
                    }                    
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO PUDO REALIZARSE LA CONEXION A LA BBDD\n\n" + error.ToString());
                }
                //cierro el form y muestro un mensaje de exito peronista
                this.Close();
            }
            else MessageBox.Show("No se ingresó nigún dato para modificar");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }


    }

}
