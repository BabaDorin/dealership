using DealershipManager.Dtos;
using DealershipManager.Models;

namespace DealershipManager.Services
{
    public interface IClientService
    {
        Result Add(AddClientDto clientDto);

        GenericResult<List<Client>> GetAll();
    }
}
