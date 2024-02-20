using System.ComponentModel.DataAnnotations;

namespace BidCalculator.Models
{
    public class BidRequest
    {
        [Required]
        public decimal VehicleBasePrice { get; set; }

        public string VehicleType { get; set; }
    }
}
