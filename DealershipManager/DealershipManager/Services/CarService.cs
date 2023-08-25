using DealershipManager.Models;
using DealershipManager.Repositories;

namespace DealershipManager.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void Add(Car car)
        {
            _carRepository.Add(car);
        }

        public void Delete(Guid id)
        {
            _carRepository.Delete(id);
        }

        public Car? Get(Guid id)
        {
            return _carRepository.Get(id);
        }

        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public void Update(Guid carId, Car car)
        {
            _carRepository.Update(carId, car);
        }
    }
}
