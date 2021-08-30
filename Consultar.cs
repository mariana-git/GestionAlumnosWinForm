using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Programa1DB
{
    public partial class Consultar : Form
    {
        private string buscar;//creo var para almacenar el txt de busqeuda del form1
        public Consultar(string txtbuscar)
        {
            InitializeComponent();
            DiseñoDgv();
            buscar = txtbuscar;
        }
        private void DiseñoDgv()
        {
            dgvDatos.ReadOnly = true; //hace que la grilla no se pueda editar
            dgvDatos.RowsDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;//alterna colores de las filas
            dgvDatos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;//alterna colores de las filas
            dgvDatos.AllowUserToAddRows = false; //desactiva la ultima fila 
        }
        private void Consultar_Load(object sender, EventArgs e)
        {
            try
            {
                //instancio la clase Consultas y creo un objeto para conectar y pasar los parámetros de busqueda 
                OperacionesSql conectar = new OperacionesSql();
               
                dgvDatos.DataSource = conectar.Consultar(buscar);//Cargo el datagridview con la tabla q devuelve el método Consultas de la clase Conexion
            }
            catch (Exception error)
            {
                MessageBox.Show("NO PUDO REALIZARSE LA CONEXION A LA BBDD\n\n" + error.ToString());
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
