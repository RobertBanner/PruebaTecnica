using Proyecto_Cliente.Entities;

namespace Proyecto_Cliente.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> FindByName(string firstname);
        Task<Client> FindByRut(string rut);
        Task<Client> FindById(int id);
        Task ClientCreate(Client client);
        Task ClientUpdate(int id, Client client);
        Task ClientDelete(int id);
    }
}
