using BidCalculator.Models;
using BidCalculator.Web.Controllers;
using BidCalculator.Web.Models;
using BidCalculator.Web.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace BidCalculator.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private Mock<ILogger<HomeController>> _loggerMock;
        private Mock<IServiceClient> _serviceClientMock;
        private IOptions<AppSettings> _appSettingsOptions;
        private ApiResponse _apiResponse;
        private HomeController _homeController;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<HomeController>>();
            _serviceClientMock = new Mock<IServiceClient>();
            _apiResponse = new ApiResponse();

            _appSettingsOptions = Options.Create(new AppSettings { ApiBaseUrl = "https://localhost:44346" });
        }

        [Test]
        public void Post_Index_ReturnsErrorWhenRequestIsBad()
        {
            //Arrange
            BidRequest bidRequest = null;
            _homeController = new HomeController(_loggerMock.Object, _serviceClientMock.Object, _appSettingsOptions);

            //Act
            var response = _homeController.Index(bidRequest).Result as ViewResult;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response?.ViewData["ErrorMessage"]?.ToString(), Is.EqualTo("Bad input. Please enter proper values."));
                Assert.That(response?.Model, Is.Null);
            });
        }

        [Test]
        public void Post_Index_ReturnsSuccess()
        {
            //Arrange
            var bidRequest = new BidRequest { VehicleBasePrice = 398, VehicleType = "Common" };

            _homeController = new HomeController(_loggerMock.Object, _serviceClientMock.Object, _appSettingsOptions);

            _apiResponse.Data = new VehicleCosts
            {
                VehicleType = "Common",
                VehicleBasePrice = 398.00m,
                BasicUserFee = 39.80m,
                SellersSpecialFee = 7.96m,
                AssociationAddedCost = 5.00m,
                FixedStoragFee = 100.00m,
                TotalCost = 550.76m
            };

            _serviceClientMock
                .Setup(x => x.PostModelAsync<VehicleCosts>(It.IsAny<string>(), bidRequest))
                .ReturnsAsync(_apiResponse);

            //Act
            var response = _homeController.Index(bidRequest).Result as ViewResult;

            //Assert
            Assert.That(response?.ViewData["Message"]?.ToString(), Is.EqualTo("Bid calculation done successfully."));
            ((VehicleCosts)_apiResponse.Data).Should().BeEquivalentTo(response.Model as VehicleCosts);
        }

        [Test]
        public void Post_Index_ReturnsNotSuccess()
        {
            //Arrange
            var bidRequest = new BidRequest { VehicleBasePrice = 1, VehicleType = "Common" };

            _homeController = new HomeController(_loggerMock.Object, _serviceClientMock.Object, _appSettingsOptions);

            _apiResponse.IsSuccess = false;
            _apiResponse.Data = null;

            _serviceClientMock
                .Setup(x => x.PostModelAsync<VehicleCosts>(It.IsAny<string>(), bidRequest))
                .ReturnsAsync(_apiResponse);

            //Act
            var response = _homeController.Index(bidRequest).Result as ViewResult;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response?.ViewData["ErrorMessage"]?.ToString(), Is.EqualTo("Could not fetch the bid calculation."));
                Assert.That(response?.Model, Is.Null);
            });
        }

        [Test]
        public void Post_Index_ThrowsException()
        {
            //Arrange
            var bidRequest = new BidRequest { VehicleBasePrice = 1, VehicleType = "Common" };

            _homeController = new HomeController(_loggerMock.Object, _serviceClientMock.Object, _appSettingsOptions);

            _apiResponse.IsSuccess = false;
            _apiResponse.Data = null;

            _serviceClientMock
                .Setup(x => x.PostModelAsync<VehicleCosts>(It.IsAny<string>(), bidRequest))
                .ThrowsAsync(new Exception("Error"));

            //Act
            var response = _homeController.Index(bidRequest).Result as ViewResult;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response?.ViewData["ErrorMessage"]?.ToString(), Is.EqualTo("Could not fetch the bid calculation."));
                Assert.That(response?.Model, Is.Null);
            });
        }
    }
}
