using System;
using System.Windows.Forms;

namespace Programa1DB
{
    public partial class Eliminar : Form
    {
        #region MÉTODOS
        public Eliminar()
        {
            InitializeComponent();
            AcceptButton = btnMostrar;
            gbxMuestra.Visible = false;
        }
        #endregion

        #region BOTONES
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string borrar = txtID.Text;
            gbxMuestra.Visible = true;

            try
            {
                //instancio la clase Consultas y creo un objeto para conectar y pasar los parámetros de busqueda 
                OperacionesSql conectar = new OperacionesSql();
                
                var registro = conectar.Consultar(borrar, borrar);

                lblNombre.Text = registro[1].ToString();
                lblApellido.Text = registro[2].ToString();
                lblDireccion.Text = registro[3].ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("NO FUE POSIBLE REALIZAR LA ACCIÓN\n\n" + error.ToString(),"Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string borrar = txtID.Text;
            try
            {
                //instancio la clase Consultas y creo un objeto para conectar y pasar los parámetros de busqueda 
                OperacionesSql conectar = new OperacionesSql();
                conectar.Eliminar(borrar);
                this.Dispose();
                MessageBox.Show("Registro borrado con éxito!");
            }
            catch (Exception error)
            {
                MessageBox.Show("NO FUE POSIBLE REALIZAR LA ACCIÓN\n\n" + error.ToString(), "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

    }
}
