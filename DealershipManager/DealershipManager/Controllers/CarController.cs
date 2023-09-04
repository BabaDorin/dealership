using DealershipManager.Dtos;
using DealershipManager.Models;
using DealershipManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipManager.Controllers
{
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // Add Car: POST /cars
        [HttpPost]
        [Route("cars")]
        public IActionResult Add(AddCarDto car)
        {
            _carService.Add(car);

            return Ok();
        }

        // Get all cars: GET /cars
        [HttpGet]
        [Route("cars")]
        public IActionResult GetAll(bool isSold)
        {
            var result = _carService.GetAll(isSold);

            return Ok(result);
        }

        // Get car by id: GET /cars/{id}
        [HttpGet]
        [Route("cars/{carId}")]
        public IActionResult GetById(Guid carId)
        {
            var result = _carService.Get(carId);

            return result is null ? NotFound() : Ok(result);
        }

        // Update car: PUT /cars/{id}
        [HttpPut]
        [Route("cars/{carId}")]
        public IActionResult Update(Guid carId, UpdateCarDto car)
        {
            _carService.Update(carId, car);

            return Ok();
        }

        // Delete: DELETE /cars/{id}
        [HttpDelete]
        [Route("cars/{carId}")]
        public IActionResult Delete(Guid carId)
        {
            _carService.Delete(carId);

            return NoContent();
        }
    }
}
