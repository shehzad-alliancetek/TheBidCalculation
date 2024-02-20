using BidCalculator.Models;
using BidCalculator.Web.Models;
using BidCalculator.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BidCalculator.Web.Controllers
{
    /// <summary>
    /// This controller is responsible from managing request and response for Bid Calculations.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceClient _serviceClient;
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="serviceClient">The http client helper object.</param>
        /// <param name="options">The configuration settings helper object.</param>
        public HomeController(ILogger<HomeController> logger,
                              IServiceClient serviceClient,
                              IOptions<AppSettings> options)
        {
            _logger = logger;
            _serviceClient = serviceClient;
            _appSettings = options.Value;
        }

        /// <summary>
        /// Gets the index page view
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets the index page view with data in response
        /// </summary>
        /// <param name="bidRequest">Contains the user input from the index page form.</param>
        [HttpPost]
        public async Task<IActionResult> Index(BidRequest bidRequest)
        {
            if (bidRequest == null || bidRequest.VehicleBasePrice <= 0 || string.IsNullOrWhiteSpace(bidRequest.VehicleType))
            {
                ViewBag.ErrorMessage = "Bad input. Please enter proper values.";
                return View();
            }

            var vehicleCosts = new VehicleCosts(); 

            try
            {
                var apiEndPoint = $"{_appSettings.ApiBaseUrl}/BidCalculator/GetVehicleCosts";
                var response = await _serviceClient.PostModelAsync<VehicleCosts>(apiEndPoint, bidRequest);

                if (response != null && response.IsSuccess && response.Data != null)
                {
                    vehicleCosts = response.Data as VehicleCosts;
                    vehicleCosts.VehicleType = bidRequest.VehicleType;

                    ViewBag.Message = "Bid calculation done successfully.";
                }
                else
                {
                    vehicleCosts = null;
                    ViewBag.ErrorMessage = "Could not fetch the bid calculation.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"HomeController - Index - Error: {ex}");
                ViewBag.ErrorMessage = "Could not fetch the bid calculation.";
                
                return View();
            }

            return View(vehicleCosts);
        }
    }
}
