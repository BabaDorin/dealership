﻿using DealershipManager.Dtos;
using DealershipManager.Models;
using DealershipManager.Repositories;
using System.Transactions;

namespace DealershipManager.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ITimeProvider _timeProvider;
        private readonly ICarRepository _carRepository;
        private readonly IClientRepository _clientRepository;

        public SaleService(
            ICarRepository carRepository,
            IClientRepository clientRepository,
            ISaleRepository saleRepository,
            ITimeProvider timeProvider)
        {
            _saleRepository = saleRepository;
            _timeProvider = timeProvider;
            _carRepository = carRepository;
            _clientRepository = clientRepository;
        }

        public void Add(AddSaleDto saleDto)
        {
            var car = _carRepository.Get(saleDto.CarId);
            var isValidCar = IsValidCar(car);

            var client = _clientRepository.Get(saleDto.ClientId);
            var isValidClient = IsValidClient(client);

            if (isValidCar && isValidClient && saleDto.FinalPrice >= 0)
            {
                var sale = new Sale
                {
                    Id = Guid.NewGuid(),
                    Date = _timeProvider.UtcNow,
                    Car = car,
                    Client = client,
                    FinalPrice = saleDto.FinalPrice,
                };

                _saleRepository.Add(sale);

                car.IsSold = true;
                _carRepository.Update(car);
            }
            else
            {
                throw new ArgumentException("Invalid sale data. Could not register the sale.");
            }
        }

        public List<Sale> GetAll(DateTime startDate, DateTime endDate)
        {
            return _saleRepository.GetAll(startDate, endDate);
        }

        private bool IsValidCar(Car? car)
        {
            if (car is null)
            {
                return false;
            }

            if (car.IsSold)
            {
                return false;
            }

            return true;
        }

        private bool IsValidClient(Client? client)
        {
            if (client is null)
            {
                return false;
            }

            return true;
        }
    }
}
