using DealershipManager.Dtos;

namespace DealershipManager.Services
{
    public interface ICarValidator
    {
        bool IsValidAddCarDto(AddCarDto carDto);

        bool IsValidUpdateCarDto(UpdateCarDto carDto);
    }
}
