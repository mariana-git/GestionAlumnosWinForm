using System;
using System.Windows.Forms;

namespace Programa1DB
{
    public partial class Insertar : Form
    {
        #region MÉTODOS
        public Insertar()
        {
            InitializeComponent();
            AcceptButton = btnAgregar;
        }
        #endregion

        #region BOTONES
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text, apellido = txtApellido.Text, direccion = txtDireccion.Text;
            if (!(nombre == "" || apellido == "" || direccion == ""))
            {
                try
                {
                    OperacionesSql conectar = new OperacionesSql();
                    conectar.Insertar(nombre, apellido, direccion);
                    MessageBox.Show("Registro agregado con éxito!");
                    this.Dispose();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO FUE POSIBLE REALIZAR LA ACCIÓN\n\n" + error.ToString(), "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else MessageBox.Show("Debe completar todos los campos");
        }
        #endregion
    }
}
