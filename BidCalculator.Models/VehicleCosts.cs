namespace BidCalculator.Models
{
    public class VehicleCosts
    {
        public string VehicleType { get; set; }

        public decimal VehicleBasePrice { get; set; }

        public decimal BasicUserFee { get; set; }

        public decimal SellersSpecialFee { get; set; }

        public decimal AssociationAddedCost { get; set; }
        
        public decimal FixedStoragFee { get; set; }

        public decimal TotalCost { get; set;}
    }
}
