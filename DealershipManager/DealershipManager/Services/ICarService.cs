using DealershipManager.Dtos;
using DealershipManager.Models;

namespace DealershipManager.Services
{
    public interface ICarService
    {
        void Add(AddCarDto carDto);

        Car? Get(Guid id);

        List<Car> GetAll(bool isSold);

        void Update(Guid carId, UpdateCarDto carDto);

        void Delete(Guid id);
    }
}
