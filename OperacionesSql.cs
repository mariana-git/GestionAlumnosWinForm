
using System;
using System.Data;

namespace Programa1DB
{
    class OperacionesSql
    {
        #region ATRIBUTOS
        private string sentencia;
        private readonly Conexiones SqlConsulta = new Conexiones();
        private readonly Validaciones val = new Validaciones();

        #endregion
        #region MÉTODOS
        public DataTable ConsultarGral(string txtbuscar)
        //consultas generales sobre la tabla, trae todo o solo lo consultado(form consultar)
        //devuelve un datatable con el que luego lleno el datagridview del form
        {
            DataTable dt = new DataTable();

            sentencia= val.SentenciaConsultaGral(txtbuscar);

            var leer = SqlConsulta.ConectarYLeer(sentencia);
            dt.Load(leer);
            if (dt.Rows.Count == 0) throw new Exception("LA BUSQUEDA NO ARROJÓ RESULTADOS\n\n");
            SqlConsulta.Desconectar();
            return dt;
        }

        public string[] ConsultarID(string id)
        //consultas en las que se carga una ID especifica (form eliminar y form modificar) y devuelvo un array para 
        //luego cargar los label en el form
        {
            sentencia = val.SentenciaConsultaID(id);
            string[] resultado = new string[4];
            var leer = SqlConsulta.ConectarYLeer(sentencia);

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

        public void Eliminar(string id)
        //elimino registro de la ID ingresada por el usuario
        {
            sentencia = val.SentenciaEliminar(id);
            SqlConsulta.ConectarYLeer(sentencia);
            SqlConsulta.Desconectar();
        }

        public void Modificar(string nombre, string apellido, string direccion, string id)
        //modifico en los registros aquellos campos que cargo el usuario, el resto los dejo igual
        {
            sentencia = val.SentenciaModificar(nombre, apellido, direccion, id);
            SqlConsulta.ConectarYLeer(sentencia);
            SqlConsulta.Desconectar();
        }

        public void Insertar (string nombre, string apellido, string direccion)
        // Agrego registros a la tabla
        {
            sentencia = val.SentenciaInsertar(nombre,apellido,direccion);
            SqlConsulta.ConectarYLeer(sentencia);
            SqlConsulta.Desconectar();
        }

        #endregion
    }
}
