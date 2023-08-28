using DealershipManager.Dtos;

namespace DealershipManager.Services
{
    public interface IClientValidator
    {
        bool IsValidAddClientDto(AddClientDto clientDto);
    }
}
