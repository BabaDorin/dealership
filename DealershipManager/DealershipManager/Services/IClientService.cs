using DealershipManager.Dtos;
using DealershipManager.Models;

namespace DealershipManager.Services
{
    public interface IClientService
    {
        void Add(AddClientDto clientDto);

        List<Client> GetAll();
    }
}
