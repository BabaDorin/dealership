using DealershipManager.Dtos;
using DealershipManager.Models;

namespace DealershipManager.Services
{
    public interface ISaleService
    {
        Result Add(AddSaleDto saleDto);

        GenericResult<List<Sale>> GetAll(DateTime startDate, DateTime endDate);
    }
}
