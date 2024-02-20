using BidCalculator.Models;
using Newtonsoft.Json;
using System.Text;

namespace BidCalculator.Web.Services
{
    /// <summary>
    /// A generice HTTP service client implementation
    /// </summary>
    public class ServiceClient : IServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ServiceClient> _logger;

        public ServiceClient(HttpClient httpClient,
                             ILogger<ServiceClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ApiResponse> PostModelAsync<T>(string url, dynamic model)
        {
            var response = new ApiResponse();

            try
            {
                var jsonData = JsonConvert.SerializeObject(model);
                using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var uri = new Uri(url);

                var httpResponse = await _httpClient.PostAsync(uri, content).ConfigureAwait(false);
                var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (httpResponse.IsSuccessStatusCode)
                    response.Data = JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ServiceClient - PostModelAsync - URL: {url} - Error: {ex}");

                response.IsSuccess = false;
                response.Message = "An error occurred.";
            }

            return response;
        }
    }
}
