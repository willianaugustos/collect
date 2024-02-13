using Asp.Versioning;
using collect_calculator.domain.Calculate;
using Microsoft.AspNetCore.Mvc;

namespace collect_calculator.api.Controller.v2
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2")]
    public class CalculateController : ControllerBase
    {
        private readonly ILogger<CalculateController> _logger;
        private readonly ICalculateHandler _handler;
        public CalculateController(ILogger<CalculateController> logger, ICalculateHandler handler)
        {
            _logger = logger;
            _handler = handler;
        }

        [HttpGet("{Id}")]
        [MapToApiVersion("2.0")]
        [ProducesResponseType(202)]
        [ProducesResponseType(404)]
        [ProducesErrorResponseType(typeof(CalculateErrorResponse))]
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

        [HttpPost]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> Post([FromBody] CalculateRequest request, CancellationToken cancellationToken)
        {

            var correlationId = new Guid();

            _logger.LogInformation("Request Received for Post: {0}", request);
            var result = await _handler.Handle(request, correlationId, cancellationToken);

            var data = new
            {
                Message = $"Data saved successfully."
            };

            return Accepted(data);
        }
    }
}

