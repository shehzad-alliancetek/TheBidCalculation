using BidCalculator.Business.Interfaces;
using BidCalculator.Models;

namespace BidCalculator.Business.Context
{
    /// <summary>
    /// Context class implementing the abstract factory to calculate various fees for the a given bid
    /// </summary>
    public class FeeCalculator : IFeeCalculator
    {
        private readonly IBasicUserFeeStrategy _basicUserFeeStrategy;
        private readonly ISellersSpecialFeeStrategy _sellersSpecialFeeStrategy;
        private readonly IAssociationAddedCostStrategy _associationAddedCostStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeeCalculator"/> class.
        /// </summary>
        /// <param name="feeFactory">The abstract factory object.</param>
        public FeeCalculator(IFeeFactory feeFactory)
        {
            _basicUserFeeStrategy = feeFactory.CreateBasicUserFeeStrategy();
            _sellersSpecialFeeStrategy = feeFactory.CreateSellersSpecialFeeStrategy();
            _associationAddedCostStrategy = feeFactory.CreateAssociationAddedCostStrategy();
        }

        /// <summary>
        /// Gets the various fees associated with the given bid
        /// </summary>
        /// <param name="basePrice">The base price of the vehicle.</param>
        /// <returns><see cref="VehicleCosts">Vehicle Costs</see> object containing details of various fees for the given bid.</returns>
        public VehicleCosts GetVehicleCosts(decimal basePrice)
        {
            var basicUserFee = _basicUserFeeStrategy.CalculateFee(basePrice);
            var sellersSpecialFee = _sellersSpecialFeeStrategy.CalculateFee(basePrice);
            var associationAddedCost = _associationAddedCostStrategy.CalculateFee(basePrice);
            var fixedStoragFee = 100; //Fixed storage fee

            var totalCost = basePrice + basicUserFee + sellersSpecialFee + associationAddedCost + fixedStoragFee;

            return new VehicleCosts 
            {
                VehicleBasePrice = basePrice,
                BasicUserFee = basicUserFee,
                SellersSpecialFee = sellersSpecialFee,
                AssociationAddedCost = associationAddedCost,
                FixedStoragFee = fixedStoragFee,
                TotalCost = totalCost
            };
        }
    }
}
