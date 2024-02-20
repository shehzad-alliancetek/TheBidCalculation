using BidCalculator.Business.ConcreteProducts;

namespace BidCalculator.Business.Tests.ConcreteProducts
{
    [TestFixture]
    public class AssociationAddedCostStrategyTests
    {
        private AssociationAddedCostStrategy _associationAddedCostStrategy;

        [SetUp]
        public void Setup()
        {
            _associationAddedCostStrategy = new AssociationAddedCostStrategy();
        }

        [Test]
        public void CalculateFee_Case1()
        {
            //Arrange
            var vehicleBasePrice = 398.00m;
            var associationAddedCost = 5.00m;

            //Act
            var result = _associationAddedCostStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(associationAddedCost, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case2()
        {
            //Arrange
            var vehicleBasePrice = 501.00m;
            var associationAddedCost = 10.00m;

            //Act
            var result = _associationAddedCostStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(associationAddedCost, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case3()
        {
            //Arrange
            var vehicleBasePrice = 57.00m;
            var associationAddedCost = 5.00m;

            //Act
            var result = _associationAddedCostStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(associationAddedCost, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case4()
        {
            //Arrange
            var vehicleBasePrice = 1800.00m;
            var associationAddedCost = 15.00m;

            //Act
            var result = _associationAddedCostStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(associationAddedCost, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case5()
        {
            //Arrange
            var vehicleBasePrice = 1100.00m;
            var associationAddedCost = 15.00m;

            //Act
            var result = _associationAddedCostStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(associationAddedCost, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case6()
        {
            //Arrange
            var vehicleBasePrice = 1000000.00m;
            var associationAddedCost = 20.00m;

            //Act
            var result = _associationAddedCostStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(associationAddedCost, Is.EqualTo(result));
        }
    }
}
