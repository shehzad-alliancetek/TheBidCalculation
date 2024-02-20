namespace BidCalculator.Business.Interfaces
{
    /// <summary>
    /// Abstract Product interface for Association Added Cost
    /// </summary>
    public interface IAssociationAddedCostStrategy
    {
        decimal CalculateFee(decimal basePrice);
    }
}
