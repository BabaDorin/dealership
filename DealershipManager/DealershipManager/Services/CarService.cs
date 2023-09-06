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

        public Result Add(AddCarDto carDto)
        {
            var isValid = _carValidator.IsValidAddCarDto(carDto);

            if (!isValid)
            {
                return Result.Fail("Invalid car info. Could not add the car.");
            }

            var car = new Car
            {
                Id = Guid.NewGuid(),
                Brand = carDto.Brand,
                Category = carDto.Category,
                Model = carDto.Model,
                Price = carDto.Price,
                ProductionYear = carDto.ProductionYear,
                IsSold = false
            };

            _carRepository.Add(car);

            return Result.Success();
        }

        public Result Delete(Guid id)
        {
            _carRepository.Delete(id);

            return Result.Success();
        }

        public GenericResult<Car> Get(Guid id)
        {
            var car = _carRepository.Get(id);

            if (car is null)
            {
                return GenericResult<Car>.Fail($"Could not find the car with id: {id}");
            }

            return GenericResult<Car>.Success(car);
        }

        public GenericResult<List<Car>> GetAll(bool isSold)
        {
            return GenericResult<List<Car>>.Success(_carRepository.GetAll(isSold));
        }

        public Result Update(Guid carId, UpdateCarDto carDto)
        {
            var isValid = _carValidator.IsValidUpdateCarDto(carDto);

            if (!isValid)
            {
                return Result.Fail("Invalid car info. Could not add the car");
            }

            var car = new Car
            {
                Id = carId,
                Brand = carDto.Brand,
                Category = carDto.Category,
                Model = carDto.Model,
                Price = carDto.Price,
                ProductionYear = carDto.ProductionYear,
            };

            _carRepository.Update(car);

            return Result.Success();
        }
    }
}
