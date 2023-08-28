using DealershipManager.Models;

namespace DealershipManager.Repositories
{
    public class InMemoryClientRepository : IClientRepository
    {
        private static readonly List<Client> _clients = new List<Client>();

        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public void Delete(Guid id)
        {
            var clientToDelete = _clients.FirstOrDefault(c => c.Id == id);

            if (clientToDelete != null)
            {
                _clients.Remove(clientToDelete);
            }
        }

        public Client? Get(Guid id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }

        public List<Client> GetAll()
        {
            return _clients;
        }

        public void Update(Client client)
        {
            var clientToUpdate = _clients.FirstOrDefault(c => c.Id == client.Id);

            if (clientToUpdate != null)
            {
                clientToUpdate.Name = client.Name;
                clientToUpdate.IsCompany = client.IsCompany;
            }
        }
    }
}
