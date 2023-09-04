using AutoFixture;
using DealershipManager.Dtos;
using DealershipManager.Models;
using DealershipManager.Repositories;
using DealershipManager.Services;
using Moq;
using System;
using Xunit;

namespace DealershipManager.Tests.Services
{
    public class CarServiceTests
    {
        [Fact]
        public void Add_InvalidCarData_ShouldThrowArgumentException()
        {
            // Arrange
            var carValidatorMock = new Mock<ICarValidator>();
            var carRepositoryMock = new Mock<ICarRepository>();

            carValidatorMock
                .Setup(m => m.IsValidAddCarDto(It.IsAny<AddCarDto>()))
                .Returns(false);

            var sut = new CarService(carValidatorMock.Object, carRepositoryMock.Object);

            var addCarDto = new Fixture().Create<AddCarDto>();

            // Act
            var act = () => sut.Add(addCarDto);

            // Assert
            Assert.Throws<ArgumentException>(act);
            carValidatorMock.Verify(m => m.IsValidAddCarDto(It.IsAny<AddCarDto>()), Times.Once);
            carRepositoryMock.Verify(m => m.Add(It.IsAny<Car>()), Times.Never);
        }

        [Fact]
        public void Add_ValidCarData_ShouldAddCar()
        {
            // Arrange
            var carValidatorMock = new Mock<ICarValidator>();
            var carRepositoryMock = new Mock<ICarRepository>();

            carValidatorMock
                .Setup(m => m.IsValidAddCarDto(It.IsAny<AddCarDto>()))
                .Returns(true);

            var sut = new CarService(carValidatorMock.Object, carRepositoryMock.Object);

            var addCarDto = new Fixture().Create<AddCarDto>();

            // Act
            sut.Add(addCarDto);

            // Assert
            carValidatorMock.Verify(m => m.IsValidAddCarDto(It.IsAny<AddCarDto>()), Times.Once);
            carRepositoryMock.Verify(m => 
                m.Add(It.Is<Car>(c => 
                    c.Id != Guid.Empty
                    && c.Brand == addCarDto.Brand
                    && c.Model == addCarDto.Model
                    && c.Price == addCarDto.Price
                    && c.ProductionYear == addCarDto.ProductionYear
                    && c.IsSold == false)),
                Times.Once);
        }
    }
}
