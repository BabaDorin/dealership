using DealershipManager.Models;

namespace DealershipManager.Repositories
{
    public class InMemorySaleRepository : ISaleRepository
    {
        private static readonly List<Sale> _sales = new List<Sale>();

        public void Add(Sale sale)
        {
            _sales.Add(sale);
        }

        public List<Sale> GetAll()
        {
            return _sales;
        }
    }
}
