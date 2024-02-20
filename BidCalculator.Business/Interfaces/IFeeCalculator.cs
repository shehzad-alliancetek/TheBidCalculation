using BidCalculator.Models;

namespace BidCalculator.Business.Interfaces
{
    /// <summary>
    /// Strategy interface for Fee Calculator
    /// </summary>
    public interface IFeeCalculator
    {
        VehicleCosts GetVehicleCosts(decimal basePrice);
    }
}
