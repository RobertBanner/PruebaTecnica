using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;

namespace Proyecto_Cliente.Helpers
{
    public class DbContextData
    {
        private readonly IConfiguration _configuration;
        public DbContextData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Createconnection()
        {

            //return new SqliteConnection(_configuration.GetConnectionString("connectionstr"));
            return new SqlConnection(_configuration.GetConnectionString("connectionstr"));

        }

        public async Task Init()
        {
            var conn = Createconnection();

            await _initcustomer();

            async Task _initcustomer()
            {
                //var sqlstr = "CREATE TABLE IF NOT EXISTS Client(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,Rut TEXT, FirstName TEXT, LastName TEXT, Address TEXT, City TEXT, PhoneNumber TEXT);";
                //var sqlstr = "select * from client";
                //await conn.ExecuteAsync(sqlstr);

            }
        }
    }
}
