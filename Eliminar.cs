using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Programa1DB
{
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
            AcceptButton = btnMostrar;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            gbxMuestra.Visible = true;

            string borrarID = txtID.Text;            
            string conexion = "datasource=127.0.0.1;port=3306;username=root;password=;database=alumnos;sslmode=none;persistsecurityinfo=true;";
            string consulta = "SELECT * FROM datos WHERE datos.IDAlumno = " + borrarID;

            //controlo las excepciones para que me muestre el mensaje de error
            try
            {
                //establezco los pareametros para la conexion con el servidor
                using(MySqlConnection conexionBD = new MySqlConnection(conexion))
                {
                    MySqlCommand comandosBD = new MySqlCommand(consulta, conexionBD);
                    comandosBD.CommandTimeout = 60;
                    conexionBD.Open();
                    MySqlDataReader leer = comandosBD.ExecuteReader();

                    if (leer.HasRows)
                    {
                        //muestro los datos que corresponden al ID a eliminar ingresado por el usuario
                        leer.Read();
                        lblNombre.Text = leer.GetString(1);
                        lblApellido.Text = leer.GetString(2);
                        lblDireccion.Text = leer.GetString(3);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("NO PUDO REALIZARSE LA CONEXION A LA BBDD\n\n" + error.ToString());
            }
            //Muestro mensaje de advertencia antes de borrar el registro
            DialogResult = MessageBox.Show("El registro se eliminará de manera permanente","ATENCION!",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);

            if (DialogResult == DialogResult.OK)
            {                
                string eliminar = "DELETE FROM datos WHERE datos.IDAlumno = " + borrarID;

                //intento conexion y guardado de datos, controlo las excepciones para que me muestre el mensaje de error
                try
                {
                    //establezco los pareametros para la conexion con el servidor
                    using (MySqlConnection conexionBD = new MySqlConnection(conexion))
                    {
                        MySqlCommand comandos2BD = new MySqlCommand(eliminar, conexionBD);
                        comandos2BD.CommandTimeout = 60;
                        conexionBD.Open();
                        MySqlDataReader leer = comandos2BD.ExecuteReader();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO PUDO REALIZARSE LA CONEXION A LA BBDD\n\n" + error.ToString());
                }
                //cierro el form y muestro un mensaje de exito peronista
                this.Dispose();
                MessageBox.Show("Registro borrado con éxito!", "VIVA PERON");
            }
            else
            {
                txtID.Clear();
                gbxMuestra.Visible = false;
            } 
                

        }
    }
}
