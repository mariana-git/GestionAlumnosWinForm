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
        private MySqlConnection CN = new MySqlConnection(conexion);

        private MySqlConnection Conectar()
        {
            //Metodo para abrir la conexion
            if (CN.State == ConnectionState.Open) CN.Close();
            CN.Open();
            return CN;
        }

        public MySqlConnection Desconectar()
        {
            //Nétodo para cerrar la conexion
            if (CN.State == ConnectionState.Open) CN.Close();
            return CN;
        }

        public MySqlDataReader Leer(string sentencia)
        {
            MySqlCommand comandosBD = new MySqlCommand(sentencia, CN);
            comandosBD.CommandTimeout = 20;
            Conectar();
            MySqlDataReader leer = comandosBD.ExecuteReader();
            return leer;
        }
        
    }
}

