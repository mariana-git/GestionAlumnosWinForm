
using System.Data;
using System.Windows.Forms;

namespace Programa1DB
{
    class OperacionesSql
    {
        private string sentencia;
        private Conexiones SqlConsulta = new Conexiones();

        public DataTable Consultar(string txtbuscar)
        //consultas sobre la tabla (todo o solo lo consultado)
        {
            DataTable dt = new DataTable();

            if (txtbuscar != "") sentencia = $"SELECT * FROM datos WHERE IDAlumno LIKE '%{txtbuscar}%' OR Nombre LIKE '%{txtbuscar}%' OR Apellido LIKE '%{txtbuscar}%' OR Direccion LIKE '%{txtbuscar}%'";
            else sentencia = "SELECT * FROM datos";
            var leer = SqlConsulta.Leer(sentencia);
            dt.Load(leer);
            if (dt.Rows.Count == 0) MessageBox.Show("La búsqueda no arrojó resultados");
            SqlConsulta.Desconectar();
            return dt;
        }

        public string[] Consultar(string borrarID, string accion)
            //sobrecargo el metodo para las consultas de ID especifica para eliminar como para modificar
        {
            sentencia = "SELECT * FROM datos WHERE datos.IDAlumno = " + borrarID;
            string[] resultado = new string[4];
            var leer = (SqlConsulta.Leer(sentencia));

            if (leer.HasRows)
            {
                leer.Read();
                for (int i = 0; i < 4; i++)
                {
                    resultado[i] = leer.GetString(i);
                }

                resultado[0] = leer.GetString(0);
                
            } else MessageBox.Show("La búsqueda no arrojó resultados");
            SqlConsulta.Desconectar();
            return resultado;
        }

        public void Eliminar(string borrarID)
            //elimino registro de la ID ingresada por el usuario
        {
            sentencia = "DELETE FROM datos WHERE datos.IDAlumno = " + borrarID;
            SqlConsulta.Leer(sentencia);
            SqlConsulta.Desconectar();
        }

        public void Modificar(string nombre, string apellido, string direccion, string idModif)
            //modifico regsitros, controlando cuales cargo el usuario, el resto lso dejo igual
        {

            string campos = "";

            //*************** Desde aca: ESTRUCTURA DE CONTROL PARA MODIFICAR  *****************************
            //verifico los campos completados por el usuario y creo un control para modificar del regsitro solo
            //aquellos que cargo el usuario
                        
            if ((nombre != "") && (apellido != "") && (direccion != "")) campos = "NAD";
            if ((nombre != "") && (apellido != "") && (direccion == "")) campos = "NA";
            if ((nombre != "") && (apellido == "") && (direccion == "")) campos = "N";
            if ((nombre == "") && (apellido != "") && (direccion == "")) campos = "A";
            if ((nombre == "") && (apellido == "") && (direccion != "")) campos = "D";
            if ((nombre == "") && (apellido != "") && (direccion != "")) campos = "AD";

            switch (campos)
            {
                case ("NAD"):
                    sentencia = "UPDATE datos SET Nombre = '" + nombre + "', Apellido = '"
                        + apellido + "', Direccion = '" + direccion + "' WHERE IDAlumno = " + idModif + ";";
                    break;

                case ("NA"):
                    sentencia = "UPDATE datos SET Nombre = '" + nombre + "', Apellido = '" + apellido +
                        "' WHERE IDAlumno = " + idModif + ";";
                    break;

                case ("N"):
                    sentencia = "UPDATE datos SET Nombre = '" + nombre + "' WHERE IDAlumno = " + idModif + ";";
                    break;

                case ("A"):
                    sentencia = "UPDATE datos SET Apellido = '" + apellido + "' WHERE IDAlumno = " + idModif + ";";
                    break;

                case ("D"):
                    sentencia = "UPDATE datos SET Direccion = '" + direccion + "' WHERE IDAlumno = " + idModif + ";";
                    break;

                case ("AD"):
                    sentencia = "UPDATE datos SET Apellido = '" + apellido + "', Direccion = '" + direccion +
                        "' WHERE IDAlumno = " + idModif + ";";
                    break;

                default:
                    break;
            }
            //********************  Hasta acá la ESTRUCTURA DE CONTROL PARA MODIFICACIONES  ***********************

            SqlConsulta.Leer(sentencia);
            SqlConsulta.Desconectar();
        }

        public void Insertar (string nombre, string apellido, string direccion)
        {
            sentencia = "INSERT INTO datos (IDAlumno,Nombre,Apellido,Direccion) VALUES (NULL,'" + nombre + "','" + apellido + "','" + direccion + "')";
            SqlConsulta.Leer(sentencia);
            SqlConsulta.Desconectar();
        }
    }
}
