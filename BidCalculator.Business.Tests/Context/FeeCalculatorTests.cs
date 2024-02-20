using BidCalculator.Business.ConcreteFactories;
using BidCalculator.Business.Context;
using BidCalculator.Business.Interfaces;
using BidCalculator.Models;
using FluentAssertions;

namespace BidCalculator.Business.Tests.Context
{
    [TestFixture]
    public class FeeCalculatorTests
    {
        private IFeeFactory _feeFactory;
        private FeeCalculator _feeCalculator;
        private VehicleCosts _vehicleCosts;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetVehicleCosts_Case1()
        {
            //Arrange
            var vehicleBasePrice = 398.00m;

            _feeFactory = new CommonVehicleFeeFactory();
            _feeCalculator = new FeeCalculator(_feeFactory);

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
            var result = _feeCalculator.GetVehicleCosts(vehicleBasePrice);

            //Assert
            _vehicleCosts.Should().BeEquivalentTo(result);
        }

        [Test]
        public void GetVehicleCosts_Case2()
        {
            //Arrange
            var vehicleBasePrice = 501.00m;

            _feeFactory = new CommonVehicleFeeFactory();
            _feeCalculator = new FeeCalculator(_feeFactory);

            _vehicleCosts = new VehicleCosts
            {
                VehicleBasePrice = 501.00m,
                BasicUserFee = 50.00m,
                SellersSpecialFee = 10.02m,
                AssociationAddedCost = 10.00m,
                FixedStoragFee = 100.00m,
                TotalCost = 671.02m
            };

            //Act
            var result = _feeCalculator.GetVehicleCosts(vehicleBasePrice);

            //Assert
            _vehicleCosts.Should().BeEquivalentTo(result);
        }

        [Test]
        public void GetVehicleCosts_Case3()
        {
            //Arrange
            var vehicleBasePrice = 57.00m;

            _feeFactory = new CommonVehicleFeeFactory();
            _feeCalculator = new FeeCalculator(_feeFactory);

            _vehicleCosts = new VehicleCosts
            {
                VehicleBasePrice = 57.00m,
                BasicUserFee = 10.00m,
                SellersSpecialFee = 1.14m,
                AssociationAddedCost = 5.00m,
                FixedStoragFee = 100.00m,
                TotalCost = 173.14m
            };

            //Act
            var result = _feeCalculator.GetVehicleCosts(vehicleBasePrice);

            //Assert
            _vehicleCosts.Should().BeEquivalentTo(result);
        }

        [Test]
        public void GetVehicleCosts_Case4()
        {
            //Arrange
            var vehicleBasePrice = 1800.00m;

            _feeFactory = new LuxuryVehicleFeeFactory();
            _feeCalculator = new FeeCalculator(_feeFactory);

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
            var result = _feeCalculator.GetVehicleCosts(vehicleBasePrice);

            //Assert
            _vehicleCosts.Should().BeEquivalentTo(result);
        }

        [Test]
        public void GetVehicleCosts_Case5()
        {
            //Arrange
            var vehicleBasePrice = 1100.00m;

            _feeFactory = new CommonVehicleFeeFactory();
            _feeCalculator = new FeeCalculator(_feeFactory);

            _vehicleCosts = new VehicleCosts
            {
                VehicleBasePrice = 1100.00m,
                BasicUserFee = 50.00m,
                SellersSpecialFee = 22.00m,
                AssociationAddedCost = 15.00m,
                FixedStoragFee = 100.00m,
                TotalCost = 1287.00m
            };

            //Act
            var result = _feeCalculator.GetVehicleCosts(vehicleBasePrice);

            //Assert
            _vehicleCosts.Should().BeEquivalentTo(result);
        }

        [Test]
        public void GetVehicleCosts_Case6()
        {
            //Arrange
            var vehicleBasePrice = 1000000.00m;

            _feeFactory = new LuxuryVehicleFeeFactory();
            _feeCalculator = new FeeCalculator(_feeFactory);

            _vehicleCosts = new VehicleCosts
            {
                VehicleBasePrice = 1000000.00m,
                BasicUserFee = 200.00m,
                SellersSpecialFee = 40000.00m,
                AssociationAddedCost = 20.00m,
                FixedStoragFee = 100.00m,
                TotalCost = 1040320.00m
            };

            //Act
            var result = _feeCalculator.GetVehicleCosts(vehicleBasePrice);

            //Assert
            _vehicleCosts.Should().BeEquivalentTo(result);
        }
    }
}
