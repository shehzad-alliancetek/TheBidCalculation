namespace BidCalculator.Business.Interfaces
{
    /// <summary>
    /// Abstract Factory interface
    /// </summary>
    public interface IFeeFactory
    {
        /// <summary>
        /// Abstract Product to calculate Basic User Fee
        /// </summary>
        IBasicUserFeeStrategy CreateBasicUserFeeStrategy();

        /// <summary>
        /// Abstract Product to calculate Seller's Special Fee
        /// </summary>
        ISellersSpecialFeeStrategy CreateSellersSpecialFeeStrategy();

        /// <summary>
        /// Abstract Product to calculate Association Added Cost
        /// </summary>
        IAssociationAddedCostStrategy CreateAssociationAddedCostStrategy();
    }
}
