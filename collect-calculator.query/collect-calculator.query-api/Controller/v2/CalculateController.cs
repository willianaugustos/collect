using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace collect_calculator.query_api.Controller.v2
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ILogger<CalculateController> _logger;
        public CalculateController(ILogger<CalculateController> logger)
        {
                _logger = logger;
        }

        [HttpGet("{Id}")]
        [MapToApiVersion("2.0")]
        public IActionResult Get(Guid Id)
        {
            _logger.LogInformation("Request Received for v2: {0}", new { Id });

            var data = new
            {
                Id,
                Message = $"Data retrieved successfully v2.0. Machine Name: {Environment.MachineName}"
            };

            return Ok(data);
        }

    }
}

