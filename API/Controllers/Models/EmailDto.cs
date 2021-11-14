namespace API.Controllers.Models
{
    public class EmailDto
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }

        public const string STATUS_SUCCESS = "Success";
        public const string STATUS_ERROR = "Error";
        public const string STATUS_SUCCESS_MESSAGE = "Email sent";
    }
}
