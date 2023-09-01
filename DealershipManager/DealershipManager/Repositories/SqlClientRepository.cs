using DealershipManager.Data;
using DealershipManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DealershipManager.Repositories
{
    public class SqlClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly DbSet<Client> _clients;

        public SqlClientRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _clients = applicationDbContext.Clients;
        }

        public void Add(Client client)
        {
            _clients.Add(client);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var clientToDelete = _clients.FirstOrDefault(c => c.Id == id);

            if (clientToDelete != null)
            {
                _clients.Remove(clientToDelete);
                _applicationDbContext.SaveChanges();
            }
        }

        public Client? Get(Guid id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }

        public List<Client> GetAll()
        {
            return _clients.ToList();
        }

        public void Update(Client client)
        {
            var clientToUpdate = _clients.FirstOrDefault(c => c.Id == client.Id);

            if (clientToUpdate != null)
            {
                clientToUpdate.Name = client.Name;
                clientToUpdate.IsCompany = client.IsCompany;

                _applicationDbContext.Update(clientToUpdate);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
