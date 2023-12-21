using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Cliente.Repositories
{
    public class Log_Bitacora
    {
        public static bool InsertLog(string rut, string comentario)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();

            p = new SqlParameter(); p.ParameterName = "Rut"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = rut; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "comentario"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = comentario; SqlParams.Add(p);
            AccesoDatos.ExecuteStoredProcedure("dbo.spInsertLog", SqlParams.ToArray());

            return true;
        }

        public string GetLogsByRut(string usuario, string fecha)
        {
            DataTable dt_ = new DataTable(); ;
            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p = new SqlParameter(); p.ParameterName = "usuario"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = usuario; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "fecha"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = fecha; SqlParams.Add(p);
            var dt = AccesoDatos.ExecuteStoredProcedure("dbo.spGetLogs", SqlParams.ToArray());

            if (dt.Rows.Count == 0)
            {
                return "0";
            }

            return AccesoDatos.DataTableToJSON(dt);
        }
    }
}
