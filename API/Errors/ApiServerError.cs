namespace API.Errors
{
    public class ApiServerError : ApiResponse
    {
        public ApiServerError(int statusCode, string message = null, string details = null)
            : base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}
