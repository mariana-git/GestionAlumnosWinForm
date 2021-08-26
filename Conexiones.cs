using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Programa1DB
{
    class Conexiones
    {
        // establezco los parámetros para la conexion
        static private string conexion = "datasource=127.0.0.1;port=3306;username=root;password=;database=alumnos;sslmode=none;persistsecurityinfo=true;";
        private string sentencia;
        private MySqlConnection CN = new MySqlConnection(conexion);

        private MySqlConnection Conectar()
        {
            if (CN.State == ConnectionState.Open) CN.Close();
            CN.Open();
            return CN;
        }

        private MySqlConnection Desconectar()
        {
            if (CN.State == ConnectionState.Open) CN.Close();
            return CN;
        }
        public DataTable Consultas(string txtbuscar)
        {
            DataTable dt = new DataTable();

            if (txtbuscar != "") sentencia = $"SELECT * FROM datos WHERE Nombre LIKE '%{txtbuscar}%' OR Apellido LIKE '%{txtbuscar}%' OR Direccion LIKE '%{txtbuscar}%'";
            else sentencia = "SELECT * FROM datos";

            MySqlCommand comandosBD = new MySqlCommand(sentencia, CN);
            comandosBD.CommandTimeout = 60;
            Conectar();
            MySqlDataReader leer = comandosBD.ExecuteReader();
            dt.Load(leer);
            Desconectar();
            return dt;
        }
    }
}

