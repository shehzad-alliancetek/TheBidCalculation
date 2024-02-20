using BidCalculator.Business.ConcreteProducts;

namespace BidCalculator.Business.Tests.ConcreteProducts
{
    [TestFixture]
    public class LuxuryBasicUserFeeStrategyTests
    {
        private LuxuryBasicUserFeeStrategy _luxuryBasicUserFeeStrategy;

        [SetUp]
        public void Setup()
        {
            _luxuryBasicUserFeeStrategy = new LuxuryBasicUserFeeStrategy();
        }

        [Test]
        public void CalculateFee_Case1()
        {
            //Arrange
            var vehicleBasePrice = 1800.00m;
            var basicUserFee = 180.00m;

            //Act
            var result = _luxuryBasicUserFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(basicUserFee, Is.EqualTo(result));
        }

        [Test]
        public void CalculateFee_Case2()
        {
            //Arrange
            var vehicleBasePrice = 1000000.00m;
            var basicUserFee = 200.00m;

            //Act
            var result = _luxuryBasicUserFeeStrategy.CalculateFee(vehicleBasePrice);

            //Assert
            Assert.That(basicUserFee, Is.EqualTo(result));
        }
    }
}
