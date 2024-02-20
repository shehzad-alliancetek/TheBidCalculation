using BidCalculator.Business.Interfaces;

namespace BidCalculator.Business.ConcreteProducts
{
    /// <summary>
    /// Concrete Product class for calculation of Basic User Fee for Luxury Vehicle type
    /// </summary>
    public class LuxuryBasicUserFeeStrategy : IBasicUserFeeStrategy
    {
        /// <summary>
        /// Calculates the total amount of the Basic User Fee for Common Vehicle type
        /// </summary>
        /// <param name="basePrice">The base bid price of the vehicle.</param>
        /// <returns>The total amount of the Basic User Fee for Luxury Vehicle type.</returns>
        public decimal CalculateFee(decimal basePrice)
        {
            decimal percentage = 10;
            decimal minAmount = 25;
            decimal maxAmount = 200;

            decimal calculatedFee = basePrice * percentage / 100;
            
            return Math.Min(Math.Max(calculatedFee, minAmount), maxAmount);
        }
    }
}
