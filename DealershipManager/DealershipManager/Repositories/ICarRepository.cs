using DealershipManager.Models;

namespace DealershipManager.Repositories
{
    public interface ICarRepository
    {
        void Add(Car car);

        Car? Get(Guid id);

        List<Car> GetAll();

        void Update(Guid carId, Car car);

        void Delete(Guid id);
    }
}
