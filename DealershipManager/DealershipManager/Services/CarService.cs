using DealershipManager.Dtos;
using DealershipManager.Models;
using DealershipManager.Repositories;

namespace DealershipManager.Services
{
    public class CarService : ICarService
    {
        private readonly ICarValidator _carValidator;
        private readonly ICarRepository _carRepository;

        public CarService(
            ICarValidator carValidator,
            ICarRepository carRepository)
        {
            _carValidator = carValidator;
            _carRepository = carRepository;
        }

        public void Add(AddCarDto carDto)
        {
            var isValid = _carValidator.IsValidAddCarDto(carDto);

            if (!isValid)
            {
                throw new ArgumentException("Invalid car info. Could not add the car.");
            }

            var car = new Car
            {
                Id = Guid.NewGuid(),
                Brand = carDto.Brand,
                Category = carDto.Category,
                Model = carDto.Model,
                Price = carDto.Price,
                Year = carDto.ProductionYear,
                IsSold = false
            };

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

        public List<Car> GetAll(bool isSold)
        {
            return _carRepository.GetAll(isSold);
        }

        public void Update(Guid carId, UpdateCarDto carDto)
        {
            var isValid = _carValidator.IsValidUpdateCarDto(carDto);

            if (!isValid)
            {
                throw new ArgumentException("Invalid car info. Could not add the car");
            }

            var car = new Car
            {
                Id = carId,
                Brand = carDto.Brand,
                Category = carDto.Category,
                Model = carDto.Model,
                Price = carDto.Price,
                Year = carDto.ProductionYear,
            };

            _carRepository.Update(car);
        }
    }
}
