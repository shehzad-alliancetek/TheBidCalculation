using BidCalculator.Business.Interfaces;

namespace BidCalculator.Business.ConcreteProducts
{
    /// <summary>
    /// Concrete Product class for calculation of Seller's Special Fee for Common Vehicle type
    /// </summary>
    public class CommonSellersSpecialFeeStrategy : ISellersSpecialFeeStrategy
    {
        /// <summary>
        /// Calculates the total amount of the Seller's Special Fee for Common Vehicle type
        /// </summary>
        /// <param name="basePrice">The base bid price of the vehicle.</param>
        /// <returns>The total amount of the Seller's Special Fee for Common Vehicle type.</returns>
        public decimal CalculateFee(decimal basePrice)
        {
            decimal percentage = 2;
            
            return basePrice * percentage / 100;
        }
    }
}
