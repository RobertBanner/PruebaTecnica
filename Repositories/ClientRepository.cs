using Dapper;
using Newtonsoft.Json.Linq;
using Proyecto_Cliente.Entities;
using Proyecto_Cliente.Helpers;

namespace Proyecto_Cliente.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbContextData _context;
        public ClientRepository(DbContextData context)
        {
            _context = context;
        }

        public async Task ClientCreate(Client client)
        {
            using var connection = _context.Createconnection();
            var sqlstr = "INSERT INTO Client(Rut,FirstName,LastName,Address,City,PhoneNumber)" +
                         "VALUES(@Rut,@FirstName,@LastName,@Address,@City,@PhoneNumber);";

           var out_ = await connection.ExecuteAsync(sqlstr, client);
           var log = (out_ == 1 ? Log.WriteLog(client, "CREATE") : false);
        }

        public async Task ClientDelete(int id)
        {
            using var connection = _context.Createconnection();
            var sqlstr = "DELETE FROM Client WHERE Id=@id";

            await connection.ExecuteAsync(sqlstr, new { id });
        }

        public async Task ClientUpdate(int id, Client client)
        {
            using var connection = _context.Createconnection();
            var sqlstr = "UPDATE Client SET FirstName=@FirstName,LastName=@LastName,Address=@Address," +
                         "City=@City,PhoneNumber=@PhoneNumber WHERE Id=" + id;

            var out_ = await connection.ExecuteAsync(sqlstr, client);
            var log = (out_ == 1 ? Log.WriteLog(client, "UPDATE") : false);
        }

        public async Task<Client> FindByName(string firstname)
        {
            using var connection = _context.Createconnection();
            var sqlstr = "SELECT * FROM Client WHERE FirstName='" + firstname + "\'";

            return await connection.QuerySingleOrDefaultAsync<Client>(sqlstr, new { firstname });
        }

        public async Task<Client> FindByRut(string rut)
        {
            using var connection = _context.Createconnection();
            var sqlstr = "SELECT * FROM Client WHERE Rut='" + rut + "\'";

            return await connection.QuerySingleOrDefaultAsync<Client>(sqlstr, new { rut });
        }

        public async Task<Client> FindById(int id)
        {

            using var connection = _context.Createconnection();
            var sqlstr = "SELECT * FROM Client WHERE Id=" + id;

            return await connection.QuerySingleOrDefaultAsync<Client>(sqlstr, new { id });
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            using var connection = _context.Createconnection();
            var sqlstr = "SELECT * FROM Client";

            return await connection.QueryAsync<Client>(sqlstr);

        }
    }
}
