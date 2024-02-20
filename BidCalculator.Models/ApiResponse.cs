namespace BidCalculator.Models
{
    public class ApiResponse
    {
        public ApiResponse() 
        {
            IsSuccess = true;
            Message = string.Empty;
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public dynamic Data { get; set; }
    }
}
