using System.Runtime;
using AutoMapper;
using Proyecto_Cliente.Entities;

namespace Proyecto_Cliente.Models
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateClientRequest, Client>();
            CreateMap<UpdateClientRequest, Client>().ForAllMembers(m => m.Condition(

                (source, destination, prop) =>
                {
                    if (prop == null) return false;

                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                    return true;

                }
                ));
        }
    }
}