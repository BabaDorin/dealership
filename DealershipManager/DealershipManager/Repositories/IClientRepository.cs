using DealershipManager.Models;

namespace DealershipManager.Repositories
{
    public interface IClientRepository
    {
        void Add(Client client);

        void Update(Client client);

        Client? Get(Guid id);

        List<Client> GetAll();

        void Delete(Guid id);
    }
}
