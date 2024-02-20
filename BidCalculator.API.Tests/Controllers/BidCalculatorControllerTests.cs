using BidCalculator.API.Controllers;
using BidCalculator.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BidCalculator.API.Tests.Controllers
{
    [TestFixture]
    public class BidCalculatorControllerTests
    {
        private Mock<ILogger<BidCalculatorController>> _loggerMock;
        private BidCalculatorController _bidCalculatorController;
        private VehicleCosts _vehicleCosts;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<BidCalculatorController>>();
        }

        [Test]
        public void GetVehicleCosts_ReturnsNull()
        {
            //Arrange
            BidRequest bidRequest = null;
            _bidCalculatorController = new BidCalculatorController(_loggerMock.Object);

            //Act
            var response = _bidCalculatorController.Post(bidRequest);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Null);
            });
        }

        [Test]
        public void GetVehicleCosts_ReturnsDataForCommonVehicleType()
        {
            //Arrange
            BidRequest bidRequest = new() { VehicleBasePrice = 398.00m, VehicleType = "Common" };
            _bidCalculatorController = new BidCalculatorController(_loggerMock.Object);
            
            _vehicleCosts = new VehicleCosts
            {
                VehicleBasePrice = 398.00m,
                BasicUserFee = 39.80m,
                SellersSpecialFee = 7.96m,
                AssociationAddedCost = 5.00m,
                FixedStoragFee = 100.00m,
                TotalCost = 550.76m
            };

            //Act
            var response = _bidCalculatorController.Post(bidRequest);

            //Assert
            Assert.That(response, Is.Not.Null);
            _vehicleCosts.Should().BeEquivalentTo(response);
        }

        [Test]
        public void GetVehicleCosts_ReturnsDataForLuxuryVehicleType()
        {
            //Arrange
            BidRequest bidRequest = new() { VehicleBasePrice = 1800.00m, VehicleType = "Luxury" };
            _bidCalculatorController = new BidCalculatorController(_loggerMock.Object);
            
            _vehicleCosts = new VehicleCosts
            {
                VehicleBasePrice = 1800.00m,
                BasicUserFee = 180.00m,
                SellersSpecialFee = 72.00m,
                AssociationAddedCost = 15.00m,
                FixedStoragFee = 100.00m,
                TotalCost = 2167.00m
            };

            //Act
            var response = _bidCalculatorController.Post(bidRequest);

            //Assert
            Assert.That(response, Is.Not.Null);
            _vehicleCosts.Should().BeEquivalentTo(response);
        }
    }
}