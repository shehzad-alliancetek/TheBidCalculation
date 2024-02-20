using BidCalculator.Business.ConcreteFactories;
using BidCalculator.Business.Context;
using BidCalculator.Business.Interfaces;
using BidCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculator.API.Controllers
{
    /// <summary>
    /// This controller is responsible from managing request and response for Bid Calculations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BidCalculatorController : ControllerBase
    {
        private readonly ILogger<BidCalculatorController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BidCalculatorController"/> class.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        public BidCalculatorController(ILogger<BidCalculatorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Calculates various fees for the bid.
        /// </summary>
        /// <param name="bidRequest">Contains the user input from the index page form.</param>
        /// <returns><see cref="VehicleCosts">Vehicle Costs object</see> containing detail of various fees for the bid.</returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("GetVehicleCosts")]
        public VehicleCosts Post(BidRequest bidRequest)
        {
            if (bidRequest == null || bidRequest.VehicleBasePrice <= 0 || string.IsNullOrWhiteSpace(bidRequest.VehicleType))
                return null;

            try
            {
                decimal vehicleBasePrice = bidRequest.VehicleBasePrice;
                VehicleCosts vehicleCosts;

                if (string.Equals(bidRequest.VehicleType, "Common", StringComparison.OrdinalIgnoreCase))
                {
                    IFeeFactory commonVehicleFeeFactory = new CommonVehicleFeeFactory();
                    var commonVehicleFeeCalculator = new FeeCalculator(commonVehicleFeeFactory);

                    vehicleCosts = commonVehicleFeeCalculator.GetVehicleCosts(vehicleBasePrice);
                }
                else
                {
                    IFeeFactory luxuryVehicleFeeFactory = new LuxuryVehicleFeeFactory();
                    var luxuryVehicleFeeCalculator = new FeeCalculator(luxuryVehicleFeeFactory);

                    vehicleCosts = luxuryVehicleFeeCalculator.GetVehicleCosts(vehicleBasePrice);
                }

                return vehicleCosts;
            }
            catch (Exception ex)
            {
                _logger.LogError($"BidCalculatorController - GetVehicleCosts - {ex}");
                throw new Exception(ex.Message);
            }
        }
    }
}
