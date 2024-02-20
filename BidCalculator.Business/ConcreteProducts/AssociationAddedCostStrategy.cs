using BidCalculator.Business.Interfaces;

namespace BidCalculator.Business.ConcreteProducts
{
    /// <summary>
    /// Concrete Product class for calculation of Association Added Cost
    /// </summary>
    public class AssociationAddedCostStrategy : IAssociationAddedCostStrategy
    {
        /// <summary>
        /// Calculates the total amount of the Association Added Cost
        /// </summary>
        /// <param name="basePrice">The base bid price of the vehicle.</param>
        /// <returns>The total amount of the Association Added Cost.</returns>
        public decimal CalculateFee(decimal basePrice)
        {
            if (basePrice >= 1 && basePrice <= 500)
                return 5;
            else if (basePrice > 500 && basePrice <= 1000)
                return 10;
            else if (basePrice > 1000 && basePrice <= 3000)
                return 15;
            else if (basePrice > 3000)
                return 20;
            else
                return 0;
        }
    }
}
