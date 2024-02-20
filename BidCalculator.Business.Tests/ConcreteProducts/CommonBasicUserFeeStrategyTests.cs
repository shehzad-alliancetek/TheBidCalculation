using BidCalculator.Business.ConcreteProducts;

namespace BidCalculator.Business.Tests.ConcreteProducts
{
    [TestFixture]
    public class CommonBasicUserFeeStrategyTests
    {
        private CommonBasicUserFeeStrategy _commonBasicUserFeeStrategy;

        [SetUp]
        public void Setup()
        {
            _commonBasicUserFeeStrategy = new CommonBasicUserFeeStrategy();
        }

        [Test]
        public void CalculateFee_Case1()
        {
            //Arrange
            var vehicleBasePrice = 398.00m;
            var basicUserFee = 39.80m;

            //Act
            var result = _commonBasicUserFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(basicUserFee, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case2()
        {
            //Arrange
            var vehicleBasePrice = 501.00m;
            var basicUserFee = 50.00m;

            //Act
            var result = _commonBasicUserFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(basicUserFee, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case3()
        {
            //Arrange
            var vehicleBasePrice = 57.00m;
            var basicUserFee = 10.00m;

            //Act
            var result = _commonBasicUserFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(basicUserFee, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case4()
        {
            //Arrange
            var vehicleBasePrice = 1100.00m;
            var basicUserFee = 50.00m;

            //Act
            var result = _commonBasicUserFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(basicUserFee, Is.EqualTo(result));
        }
    }
}
