using DealershipManager.Models;

namespace DealershipManager.Repositories
{
    public interface ISaleRepository
    {
        void Add(Sale sale);

        List<Sale> GetAll(DateTime startDate, DateTime endDate);
    }
}
