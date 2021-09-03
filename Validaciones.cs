using System;
using System.Windows.Forms;

namespace Programa1DB
{
    class Validaciones
    {
        #region ATRIBUTOS
        private string sentencia;
        #endregion

        #region MÉTODOS
        public string SentenciaConsultaGral(string buscar)
        {
            //si el usuario no ingreso parámetros de consulta, se trae toda la tabla, sino se busca en la base con LIKE
            if (buscar != "") sentencia = $"SELECT * FROM datos WHERE IDAlumno LIKE '%{buscar}%' OR Nombre LIKE '%{buscar}%' " +
                    $"OR Apellido LIKE '%{buscar}%' OR Direccion LIKE '%{buscar}%'";
            else sentencia = "SELECT * FROM datos";
            return sentencia;
        }
        public string SentenciaConsultaID(string id)
        {
            sentencia = "SELECT * FROM datos WHERE datos.IDAlumno = " + id;
            return sentencia;
        }
        public string SentenciaModificar(string nombre, string apellido, string direccion, string id)
        {
            string campos = "";

            //**********************ESTRUCTURA DE CONTROL PARA MODIFICAR  *****************************
            //verifico los campos completados por el usuario y creo un control para modificar unicamente
            //aquellos que cargó el usuario

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
                        + apellido + "', Direccion = '" + direccion + "' WHERE IDAlumno = " + id + ";";
                    break;

                case ("NA"):
                    sentencia = "UPDATE datos SET Nombre = '" + nombre + "', Apellido = '" + apellido +
                        "' WHERE IDAlumno = " + id + ";";
                    break;

                case ("N"):
                    sentencia = "UPDATE datos SET Nombre = '" + nombre + "' WHERE IDAlumno = " + id + ";";
                    break;

                case ("A"):
                    sentencia = "UPDATE datos SET Apellido = '" + apellido + "' WHERE IDAlumno = " + id + ";";
                    break;

                case ("D"):
                    sentencia = "UPDATE datos SET Direccion = '" + direccion + "' WHERE IDAlumno = " + id + ";";
                    break;

                case ("AD"):
                    sentencia = "UPDATE datos SET Apellido = '" + apellido + "', Direccion = '" + direccion +
                        "' WHERE IDAlumno = " + id + ";";
                    break;

                default:
                    throw new Exception("FALTAN PARÁMETROS DE BÚSQUEDA\n\n");
            }
            return sentencia;
        }
        public string SentenciaInsertar(string nombre, string apellido, string direccion)
        {
            sentencia = "INSERT INTO datos (IDAlumno,Nombre,Apellido,Direccion) VALUES (NULL,'" + nombre + "','" + apellido + "','" + direccion + "')";
            return sentencia;
        }
        public string SentenciaEliminar(string id)
        {
            sentencia = "DELETE FROM datos WHERE datos.IDAlumno = " + id;
            return sentencia;
        }

        public bool SoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar)) e.Handled = false;
            else e.Handled = true;
            return e.Handled;
        }
        #endregion
    }
}
