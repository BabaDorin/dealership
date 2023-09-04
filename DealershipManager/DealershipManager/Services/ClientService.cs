using DealershipManager.Dtos;
using DealershipManager.Models;
using DealershipManager.Repositories;

namespace DealershipManager.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientValidator _clientValidator;
        private readonly IClientRepository _clientRepository;

        public ClientService(
            IClientValidator clientValidator,
            IClientRepository clientRepository)
        {
            _clientValidator = clientValidator;
            _clientRepository = clientRepository;
        }

        public Result Add(AddClientDto clientDto)
        {
            var isValid = _clientValidator.IsValidAddClientDto(clientDto);

            if (!isValid)
            {
                return Result.Fail("Invalid client info. Could not add client.");
            }

            var client = new Client
            {
                Id = Guid.NewGuid(),
                IsCompany = clientDto.IsCompany,
                Name = clientDto.Name,
            };

            _clientRepository.Add(client);

            return Result.Success();
        }

        public GenericResult<List<Client>> GetAll()
        {
            return GenericResult<List<Client>>.Success(_clientRepository.GetAll());
        }
    }
}
