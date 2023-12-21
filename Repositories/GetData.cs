using System.Data;

namespace Proyecto_Cliente.Repositories
{
    public class GetData
    {

        public async Task<string> GetDbData(string nombre, string parametros = "")
        {
            // Buscar consulta asociada al nombre recibido
            DataTable dt = AccesoDatos.GetTmpDataTable($"SELECT * FROM apiquery WHERE Nombre='{nombre}'");

            if (dt.Rows.Count == 0) { return "NotFound"; }

            string query = dt.Rows[0]["query"].ToString();


            string[] listaParametros = new string[0];
            // Si hay parámetros, asignarlos (separamos los parámetros por el caracter |)
            if (parametros.Length > 0)
            {
                 { listaParametros = parametros.Split('|'); }
            }

            // Ejecutar consulta
            return await AccesoDatos.JsonDataReader(query, listaParametros);
        }

    }
}
