using DealershipManager.Dtos;
using DealershipManager.Models;

namespace DealershipManager.Services
{
    public interface ISaleService
    {
        void Add(AddSaleDto saleDto);

        List<Sale> GetAll();
    }
}
