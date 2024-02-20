using BidCalculator.Business.ConcreteProducts;

namespace BidCalculator.Business.Tests.ConcreteProducts
{
    [TestFixture]
    public class CommonSellersSpecialFeeStrategyTests
    {
        private CommonSellersSpecialFeeStrategy _commonSellersSpecialFeeStrategy;

        [SetUp]
        public void Setup()
        {
            _commonSellersSpecialFeeStrategy = new CommonSellersSpecialFeeStrategy();
        }

        [Test]
        public void CalculateFee_Case1()
        {
            //Arrange
            var vehicleBasePrice = 398.00m;
            var sellersSpecialFee = 7.96m;

            //Act
            var result = _commonSellersSpecialFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(sellersSpecialFee, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case2()
        {
            //Arrange
            var vehicleBasePrice = 501.00m;
            var sellersSpecialFee = 10.02m;

            //Act
            var result = _commonSellersSpecialFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(sellersSpecialFee, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case3()
        {
            //Arrange
            var vehicleBasePrice = 57.00m;
            var sellersSpecialFee = 1.14m;

            //Act
            var result = _commonSellersSpecialFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(sellersSpecialFee, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case4()
        {
            //Arrange
            var vehicleBasePrice = 1100.00m;
            var sellersSpecialFee = 22.00m;

            //Act
            var result = _commonSellersSpecialFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(sellersSpecialFee, Is.EqualTo(result));
        }
    }
}
