using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Cliente.Repositories
{
    public class Usuario
    {
        public bool userInsert(string rut, string nombre, string apellido, string email, string password)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();

            p = new SqlParameter(); p.ParameterName = "Rut"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = rut; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "Nombre"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "Apellido"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = apellido; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "Email"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = email; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "Clave"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = password; SqlParams.Add(p);
            var dt = AccesoDatos.ExecuteStoredProcedure("dbo.spUsuariosInsert", SqlParams.ToArray());

            return true;
        }
    }
}
