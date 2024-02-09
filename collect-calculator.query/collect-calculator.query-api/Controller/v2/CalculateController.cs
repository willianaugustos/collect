using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace collect_calculator.query_api.Controller.v2
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        [HttpGet("{Id}")]
        [MapToApiVersion("2.0")]
        public IActionResult Get(Guid Id)
        {
            // Your logic to retrieve data based on the provided Id
            // For demonstration purposes, let's assume we return a sample response
            var data = new
            {
                Id,
                Message = $"Data retrieved successfully v2.0. Machine Name: {Environment.MachineName}"
                // Add more properties as needed
            };

            // Return 200 OK status code along with the data
            return Ok(data);
        }

    }
}

