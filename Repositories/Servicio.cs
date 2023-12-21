using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Cliente.Repositories
{
    public class Servicio
    {
        public bool ServicioAsignar(string rut, string nombre_servicio, string anio)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p = new SqlParameter(); p.ParameterName = "rut"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = rut; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "anio_entrega"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_servicio; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "nombre_servicio"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = anio; SqlParams.Add(p);
            var dt = AccesoDatos.ExecuteStoredProcedure("dbo.spCreateServicioPersona", SqlParams.ToArray());

            if(dt.Rows[0].ToString() == "1")
            {
                return false;
            }

            return true;
        }

        public string GetAsignacionByRut(string rut)
        {
            DataTable dt_ = new DataTable(); ;
            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p = new SqlParameter(); p.ParameterName = "rut"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = rut; SqlParams.Add(p);
            var dt = AccesoDatos.ExecuteStoredProcedure("dbo.spGetAsignacionbyRut", SqlParams.ToArray());

            if (dt.Rows.Count == 0)
            {
                return "0";
            }

            return AccesoDatos.DataTableToJSON(dt);
        }

        public bool CreateServicioComuna(string nombre_comuna, string nombre_region, string nombre_servicio)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p = new SqlParameter(); p.ParameterName = "nombre_comuna"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_comuna; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "nombre_region"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_region; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "nombre_servicio"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_servicio; SqlParams.Add(p);
            AccesoDatos.ExecuteStoredProcedure("dbo.spCreateServicioComuna", SqlParams.ToArray());

            return true;
        }
    }
}
