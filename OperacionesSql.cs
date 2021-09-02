
using System;
using System.Data;

namespace Programa1DB
{
    class OperacionesSql
    {
        #region ATRIBUTOS
        private string sentencia;
        private readonly Conexiones SqlConsulta = new Conexiones();

        #endregion
        #region MÉTODOS
        public DataTable Consultar(string txtbuscar)
        //consultas sobre la tabla (todo o solo lo consultado)
        {
            DataTable dt = new DataTable();

            //si el usuario no ingreso parámetros de consulta, se trae toda la tabla, sino se busca en la base con LIKE
            if (txtbuscar != "") sentencia = $"SELECT * FROM datos WHERE IDAlumno LIKE '%{txtbuscar}%' OR Nombre LIKE '%{txtbuscar}%' OR Apellido LIKE '%{txtbuscar}%' OR Direccion LIKE '%{txtbuscar}%'";
            else sentencia = "SELECT * FROM datos";

            var leer = SqlConsulta.Conectar(sentencia);
            dt.Load(leer);
            if (dt.Rows.Count == 0) throw new Exception("LA BUSQUEDA NO ARROJÓ RESULTADOS\n\n");
            SqlConsulta.Desconectar();
            return dt;
        }

        public string[] Consultar(string borrarID, string accion)
        //sobrecargo el metodo para las consultas en las  que se carga una ID especifica (form eliminar y form modificar)
        {
            sentencia = "SELECT * FROM datos WHERE datos.IDAlumno = " + borrarID;
            string[] resultado = new string[4];
            var leer = SqlConsulta.Conectar(sentencia);

            if (leer.HasRows)
            {
                leer.Read();
                for (int i = 0; i < 4; i++)
                {
                    resultado[i] = leer.GetString(i);
                }
                resultado[0] = leer.GetString(0);
                
            } else throw new Exception("LA BUSQUEDA NO ARROJÓ RESULTADOS\n\n");
            SqlConsulta.Desconectar();
            return resultado;
        }

        public void Eliminar(string borrarID)
            //elimino registro de la ID ingresada por el usuario
        {
            sentencia = "DELETE FROM datos WHERE datos.IDAlumno = " + borrarID;
            SqlConsulta.Conectar(sentencia);
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
                    throw new Exception("FALTAN PARÁMETROS DE BÚSQUEDA\n\n");
            }
            //********************  Hasta acá la ESTRUCTURA DE CONTROL PARA MODIFICACIONES  ***********************

            SqlConsulta.Conectar(sentencia);
            SqlConsulta.Desconectar();
        }

        public void Insertar (string nombre, string apellido, string direccion)
        {

            sentencia = "INSERT INTO datos (IDAlumno,Nombre,Apellido,Direccion) VALUES (NULL,'" + nombre + "','" + apellido + "','" + direccion + "')";
            SqlConsulta.Conectar(sentencia);
            SqlConsulta.Desconectar();
        }

        #endregion
    }
}
