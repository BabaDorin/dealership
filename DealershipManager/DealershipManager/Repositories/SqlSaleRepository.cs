using DealershipManager.Data;
using DealershipManager.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<Sale> GetAll(DateTime startDate, DateTime endDate)
        {
            return _applicationDbContext.Sales
                .Where(s => s.Date >= startDate && s.Date <= endDate)
                .Include(s => s.Car)
                .Include(s => s.Client)
                .ToList();
        }
    }
}
