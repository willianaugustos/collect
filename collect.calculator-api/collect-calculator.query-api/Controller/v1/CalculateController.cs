using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace collect_calculator.api.Controller.v1
{
    //[Route("api/v1/[controller]")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class CalculateController : ControllerBase
    {

        private readonly ILogger<CalculateController> _logger;
        public CalculateController(ILogger<CalculateController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{Id}")]
        [MapToApiVersion("1.0")]
        public IActionResult Get(Guid Id)
        {
            _logger.LogInformation("Request Received for v1: {0}", new { Id });

            // Your logic to retrieve data based on the provided Id
            // For demonstration purposes, let's assume we return a sample response
            var data = new
            {
                Id,
                Message = $"Data retrieved successfully v1.0. Machine Name: {Environment.MachineName}"
                // Add more properties as needed
            };

            // Return 200 OK status code along with the data
            return Ok(data);
        }

    }
}
