using DealershipManager.Data;
using DealershipManager.Models;

namespace DealershipManager.Repositories
{
    public class SqlSaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SqlSaleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Add(Sale sale)
        {
            _applicationDbContext.Sales.Add(sale);
            _applicationDbContext.SaveChanges();
        }

        public List<Sale> GetAll()
        {
            return _applicationDbContext.Sales.ToList();
        }
    }
}
