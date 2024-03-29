﻿using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Programa1DB
{
    public partial class Consultar : Form
    {
        private string buscar;//variable para almacenar el txt de busqeuda capturada del form Inicio
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
               
                dgvDatos.DataSource = conectar.ConsultarGral(buscar);//Cargo el datagridview con la tabla q devuelve el método Consultas de la clase Conexion
            }
            catch (Exception error)
            {
                MessageBox.Show("NO FUE POSIBLE REALIZAR LA ACCIÓN\n\n" + error.ToString(),"Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
