using DealershipManager.Dtos;

namespace DealershipManager.Services
{
    public class CarValidator : ICarValidator
    {
        public bool IsValidAddCarDto(AddCarDto carDto)
        {
            if (string.IsNullOrEmpty(carDto.Brand)) return false;
            if (string.IsNullOrEmpty(carDto.Model)) return false;
            if (carDto.ProductionYear > DateTime.UtcNow.Year) return false;
            if (carDto.Price <= 0) return false;
            if (carDto.Category == 0) return false;

            return true;
        }

        public bool IsValidUpdateCarDto(UpdateCarDto carDto)
        {
            if (string.IsNullOrEmpty(carDto.Brand)) return false;
            if (string.IsNullOrEmpty(carDto.Model)) return false;
            if (carDto.ProductionYear > DateTime.UtcNow.Year) return false;
            if (carDto.Price <= 0) return false;
            if (carDto.Category == 0) return false;

            return true;
        }
    }
}
