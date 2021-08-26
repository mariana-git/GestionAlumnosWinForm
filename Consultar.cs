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
            dgvDatos.AllowUserToAddRows = false; //desactiva  la ultima fila 
        }
        private void Consultar_Load(object sender, EventArgs e)
        {
            Conexiones conectar = new Conexiones();
            dgvDatos.DataSource = conectar.Consultas(buscar);//envio la consulta con el parámetro ingresado
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
