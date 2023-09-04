using DealershipManager.Dtos;
using DealershipManager.Exceptions;
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

        public void Add(AddClientDto clientDto)
        {
            var isValid = _clientValidator.IsValidAddClientDto(clientDto);

            if (!isValid)
            {
                throw new ValidationException("Invalid client info. Could not add client.");
            }

            var client = new Client
            {
                Id = Guid.NewGuid(),
                IsCompany = clientDto.IsCompany,
                Name = clientDto.Name,
            };

            _clientRepository.Add(client);
        }

        public List<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }
    }
}
