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
    public class SaleServiceTests
    {
        [Fact]
        public void Add_CarNotFound_ShouldThrowException()
        {
            // Arrange
            var carRepositoryMock = new Mock<ICarRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var saleRepositoryMock = new Mock<ISaleRepository>();
            var timeProviderMock = new Mock<ITimeProvider>();

            var sut = new SaleService(
                carRepositoryMock.Object,
                clientRepositoryMock.Object,
                saleRepositoryMock.Object,
                timeProviderMock.Object);

            carRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns((Car)null);

            clientRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(new Client());

            var saleDto = new Fixture().Create<AddSaleDto>();

            // Act
            var act = () => sut.Add(saleDto);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Add_CarAlreadySold_ShouldThrowException()
        {
            // Arrange
            var fixture = new Fixture();

            var carRepositoryMock = new Mock<ICarRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var saleRepositoryMock = new Mock<ISaleRepository>();
            var timeProviderMock = new Mock<ITimeProvider>();

            var sut = new SaleService(
                carRepositoryMock.Object,
                clientRepositoryMock.Object,
                saleRepositoryMock.Object,
                timeProviderMock.Object);

            var car = fixture.Create<Car>();
            car.IsSold = true;
            carRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(car);

            clientRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(new Client());

            var saleDto = fixture.Create<AddSaleDto>();

            // Act
            var act = () => sut.Add(saleDto);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Add_NegativeFinalPrice_ShouldThrowException()
        {
            // Arrange
            var fixture = new Fixture();

            var carRepositoryMock = new Mock<ICarRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var saleRepositoryMock = new Mock<ISaleRepository>();
            var timeProviderMock = new Mock<ITimeProvider>();

            var sut = new SaleService(
                carRepositoryMock.Object,
                clientRepositoryMock.Object,
                saleRepositoryMock.Object,
                timeProviderMock.Object);

            var car = fixture.Create<Car>();
            car.IsSold = false;
            carRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(car);

            clientRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(new Client());

            var saleDto = fixture.Create<AddSaleDto>();
            saleDto.FinalPrice = -20000;

            // Act
            var act = () => sut.Add(saleDto);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Add_ClientNotFound_ShouldThrowException()
        {
            // Arrange
            var fixture = new Fixture();

            var carRepositoryMock = new Mock<ICarRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var saleRepositoryMock = new Mock<ISaleRepository>();
            var timeProviderMock = new Mock<ITimeProvider>();

            var sut = new SaleService(
                carRepositoryMock.Object,
                clientRepositoryMock.Object,
                saleRepositoryMock.Object,
                timeProviderMock.Object);

            var car = fixture.Create<Car>();
            car.IsSold = false;
            carRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(car);

            clientRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns((Client)null);

            var saleDto = fixture.Create<AddSaleDto>();

            // Act
            var act = () => sut.Add(saleDto);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Add_ValidSale_ShouldAddSale()
        {
            // Arrange
            var fixture = new Fixture();

            var carRepositoryMock = new Mock<ICarRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var saleRepositoryMock = new Mock<ISaleRepository>();
            var timeProviderMock = new Mock<ITimeProvider>();

            var sut = new SaleService(
                carRepositoryMock.Object,
                clientRepositoryMock.Object,
                saleRepositoryMock.Object,
                timeProviderMock.Object);

            var simulatedCurrentDate = new DateTime(2009, 06, 06);

            timeProviderMock.Setup(m => m.UtcNow)
                .Returns(simulatedCurrentDate);

            var car = fixture.Create<Car>();
            car.IsSold = false;
            carRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(car);

            var client = fixture.Create<Client>();
            clientRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(client);

            var saleDto = fixture.Create<AddSaleDto>();

            // Act
            sut.Add(saleDto);

            // Assert
            saleRepositoryMock.Verify(m => 
                m.Add(It.Is<Sale>(s =>
                    s.Car == car
                    && s.Client == client
                    && s.FinalPrice == saleDto.FinalPrice
                    && s.Id != Guid.Empty
                    && s.Date == simulatedCurrentDate)),
                Times.Once);
        }

        [Fact]
        public void Add_ValidSale_ShouldMarkCarAsSold()
        {
            // Arrange
            var fixture = new Fixture();

            var carRepositoryMock = new Mock<ICarRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var saleRepositoryMock = new Mock<ISaleRepository>();
            var timeProviderMock = new Mock<ITimeProvider>();

            var sut = new SaleService(
                carRepositoryMock.Object,
                clientRepositoryMock.Object,
                saleRepositoryMock.Object,
                timeProviderMock.Object);

            var simulatedCurrentDate = new DateTime(2009, 06, 06);

            timeProviderMock.Setup(m => m.UtcNow)
                .Returns(simulatedCurrentDate);

            var car = fixture.Create<Car>();
            car.IsSold = false;
            carRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(car);

            var client = fixture.Create<Client>();
            clientRepositoryMock.Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(client);

            var saleDto = fixture.Create<AddSaleDto>();

            // Act
            sut.Add(saleDto);

            // Assert
            carRepositoryMock.Verify(m =>
                m.Update(It.Is<Car>(c => c.IsSold == true)),
                Times.Once);
        }

        [Fact]
        public void GetAll_ShouldCallRepository()
        {
            // Arrange
            var carRepositoryMock = new Mock<ICarRepository>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var saleRepositoryMock = new Mock<ISaleRepository>();
            var timeProviderMock = new Mock<ITimeProvider>();

            var sut = new SaleService(
                carRepositoryMock.Object,
                clientRepositoryMock.Object,
                saleRepositoryMock.Object,
                timeProviderMock.Object);

            var startDate = DateTime.UtcNow - TimeSpan.FromDays(1);
            var endDate = DateTime.UtcNow;

            // Act
            var result = sut.GetAll(startDate, endDate);

            // Assert
            saleRepositoryMock.Verify(m =>
                m.GetAll(startDate, endDate),
                Times.Once);
        }
    }
}
