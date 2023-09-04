using DealershipManager.Models;

namespace DealershipManager.Repositories
{
    public interface ICarRepository
    {
        void Add(Car car);

        Car? Get(Guid id);

        List<Car> GetAll(bool isSold);

        List<Car> GetByFilter(string model, string brand, int productionYear);

        void Update(Car car);

        void Delete(Guid id);
    }
}
