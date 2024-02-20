using BidCalculator.Business.Interfaces;

namespace BidCalculator.Business.ConcreteProducts
{
    /// <summary>
    /// Concrete Product class for calculation of Basic User Fee for Common Vehicle type
    /// </summary>
    public class CommonBasicUserFeeStrategy : IBasicUserFeeStrategy
    {
        /// <summary>
        /// Calculates the total amount of the Basic User Fee for Common Vehicle type
        /// </summary>
        /// <param name="basePrice">The base bid price of the vehicle.</param>
        /// <returns>The total amount of the Basic User Fee for Common Vehicle type.</returns>
        public decimal CalculateFee(decimal basePrice)
        {
            decimal percentage = 10;
            decimal minAmount = 10;
            decimal maxAmount = 50;

            decimal calculatedFee = basePrice * percentage / 100;
            
            return Math.Min(Math.Max(calculatedFee, minAmount), maxAmount);
        }
    }
}
