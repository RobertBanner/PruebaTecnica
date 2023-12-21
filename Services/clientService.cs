using AutoMapper;
using Proyecto_Cliente.Entities;
using Proyecto_Cliente.Helpers;
using Proyecto_Cliente.Models;
using Proyecto_Cliente.Repositories;

namespace Proyecto_Cliente.Services
{
    public class clientService : Iclient
    {
        private IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public clientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public void Clientcreate(CreateClientRequest ClientRequest)
        {

            //var ClientExist = _clientRepository.FindByName(ClientRequest.FirstName);
            var ClientExist = _clientRepository.FindByRut(ClientRequest.Rut);
            if (ClientExist.Result != null)
            {
                throw new AppException("Client Rut: '" + ClientRequest.Rut + "' Already Exist.");
            }

            var client = _mapper.Map<Client>(ClientRequest);
            _clientRepository.ClientCreate(client);
        }

        public async Task Clientdelete(int id)
        {
            await _clientRepository.ClientDelete(id);
        }

        public async Task<Client> ClientGetById(int id)
        {
            var client = _clientRepository.FindById(id);
            if (client == null)
            {
                throw new AppException("Client Not Found.");
            }
            return await client;
        }

        public async Task Clientupdate(int id, UpdateClientRequest ClienttRequest)
        {
            var client = await _clientRepository.FindById(id);

            if (client == null)
            {
                throw new KeyNotFoundException("Client Not Found.");

            }
            _mapper.Map(ClienttRequest, client);

            await _clientRepository.ClientUpdate(id, client);

        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }
    }
}
