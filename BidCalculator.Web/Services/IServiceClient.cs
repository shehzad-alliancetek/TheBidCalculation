using BidCalculator.Models;

namespace BidCalculator.Web.Services
{
    /// <summary>
    /// Interface for the <see cref="ServiceClient"/> class.
    /// </summary>
    public interface IServiceClient
    {
        /// <summary>
        /// Template helper to make HTTP calls using POST method.
        /// </summary>
        /// <typeparam name="T">Expected return type of the HTTP response data.</typeparam>
        /// <param name="url">The API endpoint.</param>
        /// <param name="model">The user input model object.</param>
        /// <returns>Generic <see cref="ApiResponse">API response</see> indicating success/failure, optional Message, and optional Data.</returns>
        Task<ApiResponse> PostModelAsync<T>(string url, dynamic model);
    }
}
