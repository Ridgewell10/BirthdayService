using Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IBirthdayProcessor _birthdayProcessor;
        public EmailController(ILoggerManager logger, IBirthdayProcessor processor)
        {
            _logger = logger;
            _birthdayProcessor = processor;
        }

        [HttpPost()]
        [SwaggerResponse(200)]
        public async Task<IActionResult> SendEmail()
        {
            var result = await _birthdayProcessor.GetEmployeeBirthday();

            return Ok(result);
        }
    }
}
