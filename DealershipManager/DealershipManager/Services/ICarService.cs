using DealershipManager.Dtos;
using DealershipManager.Models;

namespace DealershipManager.Services
{
    public interface ICarService
    {
        Result Add(AddCarDto carDto);

        GenericResult<Car> Get(Guid id);

        GenericResult<List<Car>> GetAll(bool isSold);

        Result Update(Guid carId, UpdateCarDto carDto);

        Result Delete(Guid id);
    }
}
