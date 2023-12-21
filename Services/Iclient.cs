using Proyecto_Cliente.Entities;
using Proyecto_Cliente.Models;

namespace Proyecto_Cliente.Services
{
    public interface Iclient
    {
        void Clientcreate(CreateClientRequest CustRequest);
        Task Clientupdate(int id, UpdateClientRequest CustRequest);
        Task Clientdelete(int id);
        Task<IEnumerable<Client>> GetAll();
        Task<Client> ClientGetById(int id);
    }
}
