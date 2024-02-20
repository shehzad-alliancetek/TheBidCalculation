using BidCalculator.Business.ConcreteProducts;
using BidCalculator.Business.Interfaces;

namespace BidCalculator.Business.ConcreteFactories
{
    /// <summary>
    /// Concrete Factory class for the Luxury Vehicle type
    /// </summary>
    public class LuxuryVehicleFeeFactory : IFeeFactory
    {
        /// <summary>
        /// For calculating Basic User Fee of Luxury Vehicle type
        /// </summary>
        /// <returns><see cref="LuxuryBasicUserFeeStrategy">Basic User Fee</see> object for Luxury Vehicle type.</returns>
        public IBasicUserFeeStrategy CreateBasicUserFeeStrategy()
        {
            return new LuxuryBasicUserFeeStrategy();
        }

        /// <summary>
        /// For calculating Seller's Special Fee of Luxury Vehicle type
        /// </summary>
        /// <returns><see cref="CommonSellersSpecialFeeStrategy">Seller's Special Fee</see> object for Luxury Vehicle type.</returns>
        public ISellersSpecialFeeStrategy CreateSellersSpecialFeeStrategy()
        {
            return new LuxurySellersSpecialFeeStrategy();
        }

        /// <summary>
        /// For calculating Association Added Cost of Luxury Vehicle type
        /// </summary>
        /// <returns><see cref="AssociationAddedCostStrategy">Association Added Cost</see> object for Luxury Vehicle type.</returns>
        public IAssociationAddedCostStrategy CreateAssociationAddedCostStrategy()
        {
            return new AssociationAddedCostStrategy();
        }
    }
}
