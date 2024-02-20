using BidCalculator.Business.ConcreteProducts;
using BidCalculator.Business.Interfaces;

namespace BidCalculator.Business.ConcreteFactories
{
    /// <summary>
    /// Concrete Factory class for the Common Vehicle type
    /// </summary>
    public class CommonVehicleFeeFactory : IFeeFactory
    {
        /// <summary>
        /// For calculating Basic User Fee of Common Vehicle type
        /// </summary>
        /// <returns><see cref="CommonBasicUserFeeStrategy">Basic User Fee</see> object for Common Vehicle type.</returns>
        public IBasicUserFeeStrategy CreateBasicUserFeeStrategy()
        {
            return new CommonBasicUserFeeStrategy();
        }

        /// <summary>
        /// For calculating Seller's Special Fee of Common Vehicle type
        /// </summary>
        /// <returns><see cref="CommonSellersSpecialFeeStrategy">Seller's Special Fee</see> object for Common Vehicle type.</returns>
        public ISellersSpecialFeeStrategy CreateSellersSpecialFeeStrategy()
        {
            return new CommonSellersSpecialFeeStrategy();
        }

        /// <summary>
        /// For calculating Association Added Cost of Common Vehicle type
        /// </summary>
        /// <returns><see cref="AssociationAddedCostStrategy">Association Added Cost</see> object for Common Vehicle type.</returns>
        public IAssociationAddedCostStrategy CreateAssociationAddedCostStrategy()
        {
            return new AssociationAddedCostStrategy();
        }
    }
}
