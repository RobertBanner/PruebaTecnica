using System.Data.SqlClient;

namespace Proyecto_Cliente.Repositories
{
    public class Localidad
    {
        public bool PaisInsert(string nombre)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p = new SqlParameter(); p.ParameterName = "Nombre"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre; SqlParams.Add(p);
            AccesoDatos.ExecuteStoredProcedure("dbo.spPaisInsert", SqlParams.ToArray());

            return true;
        }


        public bool RegionInsert(string nombre_region, string nombre_pais)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p = new SqlParameter(); p.ParameterName = "Nombre_Region"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_region; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "Nombre_Pais"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_pais; SqlParams.Add(p);
            AccesoDatos.ExecuteStoredProcedure("dbo.spRegionInsert", SqlParams.ToArray());

            return true;
        }

        public bool ComunaInsert(string nombre_comuna, string nombre_region)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p = new SqlParameter(); p.ParameterName = "Nombre_Comuna"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_comuna; SqlParams.Add(p);
            p = new SqlParameter(); p.ParameterName = "Nombre_Region"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_region; SqlParams.Add(p);
            AccesoDatos.ExecuteStoredProcedure("dbo.spComunaInsert", SqlParams.ToArray());

            return true;
        }

        public bool ComunaDel(string nombre_comuna)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p = new SqlParameter(); p.ParameterName = "Nombre_Comuna"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_comuna; SqlParams.Add(p);
            AccesoDatos.ExecuteStoredProcedure("dbo.spDelComuna", SqlParams.ToArray());

            return true;
        }

        public bool RegionDel(string nombre_region)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p = new SqlParameter(); p.ParameterName = "Nombre_Region"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_region; SqlParams.Add(p);
            AccesoDatos.ExecuteStoredProcedure("dbo.spDelRegion", SqlParams.ToArray());

            return true;
        }


        public bool PaisDel(string nombre_pais)
        {

            List<SqlParameter> SqlParams = new List<SqlParameter>();
            SqlParameter p = new SqlParameter();
            p = new SqlParameter(); p.ParameterName = "Nombre_Pais"; p.SqlDbType = System.Data.SqlDbType.VarChar; p.SqlValue = nombre_pais; SqlParams.Add(p);
            AccesoDatos.ExecuteStoredProcedure("dbo.spDelPais", SqlParams.ToArray());

            return true;
        }
    }
}
