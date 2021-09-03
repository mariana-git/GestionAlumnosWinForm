using System;
using System.Windows.Forms;

namespace Programa1DB
{
    public partial class Modificar : Form
    {
        #region MÉTODOS
        public Modificar()
        {
            InitializeComponent();
            AcceptButton = btnMostrar;
            gbxMuestra.Visible = false;
        }
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones verificar = new Validaciones();
            verificar.SoloNumeros(e);
        }
        #endregion

        #region BOTONES
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string idModificar = txtID.Text;

            try
            {
                //instancio la clase Consultas y creo un objeto para conectar y pasar los parámetros de busqueda 
                OperacionesSql conectar = new OperacionesSql();

                var registro = conectar.ConsultarID(idModificar);
                gbxMuestra.Visible = true;
                lblNombre.Text = registro[1].ToString();
                lblApellido.Text = registro[2].ToString();
                lblDireccion.Text = registro[3].ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("NO FUE POSIBLE REALIZAR LA ACCIÓN\n\n" + error.ToString(), "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("NO FUE POSIBLE REALIZAR LA ACCIÓN\n\n" + error.ToString(), "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else MessageBox.Show("No se ingresaron datos a modificar!");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion
    }

}
