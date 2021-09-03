using System.Data;
using MySql.Data.MySqlClient;

namespace Programa1DB
{
    class Conexiones
    {
        #region ATRIBUTOS
        // establezco los parámetros para la conexion
        private static readonly string conexion = "datasource=127.0.0.1;port=3306;username=root;password=;database=alumnos;sslmode=none;persistsecurityinfo=true;";
        private readonly MySqlConnection CN = new MySqlConnection(Conexion);
        #endregion

        #region PROPIERTIES
        public static string Conexion => conexion;
        #endregion

        #region MÉTODOS
        public MySqlDataReader ConectarYLeer(string sentencia)
        {
            MySqlCommand comandosBD = new MySqlCommand(sentencia, CN);
            comandosBD.CommandTimeout = 10;
            if (CN.State == ConnectionState.Open) CN.Close();
            CN.Open();
            MySqlDataReader leer = comandosBD.ExecuteReader();
            return leer;
        }
        public MySqlConnection Desconectar()
        {
            //Nétodo para cerrar la conexion
            if (CN.State == ConnectionState.Open) CN.Close();
            return CN;
        }
        #endregion

    }
}

