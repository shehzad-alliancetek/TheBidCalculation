using BidCalculator.Business.ConcreteProducts;

namespace BidCalculator.Business.Tests.ConcreteProducts
{
    [TestFixture]
    public class LuxurySellersSpecialFeeStrategyTests
    {
        private LuxurySellersSpecialFeeStrategy _luxurySellersSpecialFeeStrategy;

        [SetUp]
        public void Setup()
        {
            _luxurySellersSpecialFeeStrategy = new LuxurySellersSpecialFeeStrategy();
        }

        [Test]
        public void CalculateFee_Case1()
        {
            //Arrange
            var vehicleBasePrice = 1800.00m;
            var sellersSpecialFee = 72.00m;

            //Act
            var result = _luxurySellersSpecialFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(sellersSpecialFee, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case2()
        {
            //Arrange
            var vehicleBasePrice = 1000000.00m;
            var sellersSpecialFee = 40000.00m;

            //Act
            var result = _luxurySellersSpecialFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(sellersSpecialFee, Is.EqualTo(result));
        }
    }
}
