namespace BidCalculator.Business.Interfaces
{
    /// <summary>
    /// Abstract Product interface for Basic User Fee
    /// </summary>
    public interface IBasicUserFeeStrategy
    {
        decimal CalculateFee(decimal basePrice);
    }
}
