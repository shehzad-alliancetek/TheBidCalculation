namespace BidCalculator.Business.Interfaces
{
    /// <summary>
    /// Abstract Product interface for Seller's Special Fee
    /// </summary>
    public interface ISellersSpecialFeeStrategy
    {
        decimal CalculateFee(decimal basePrice);
    }
}
