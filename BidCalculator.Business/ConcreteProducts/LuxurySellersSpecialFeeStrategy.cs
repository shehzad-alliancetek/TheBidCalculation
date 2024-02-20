using BidCalculator.Business.Interfaces;

namespace BidCalculator.Business.ConcreteProducts
{
    /// <summary>
    /// Concrete Product class for calculation of Seller's Special Fee for Luxury Vehicle type
    /// </summary>
    public class LuxurySellersSpecialFeeStrategy : ISellersSpecialFeeStrategy
    {
        /// <summary>
        /// Calculates the total amount of the Seller's Special Fee for Luxury Vehicle type
        /// </summary>
        /// <param name="basePrice">The base bid price of the vehicle.</param>
        /// <returns>The total amount of the Seller's Special Fee for Luxury Vehicle type.</returns>
        public decimal CalculateFee(decimal basePrice)
        {
            decimal percentage = 4;
            
            return basePrice * percentage / 100;
        }
    }
}
