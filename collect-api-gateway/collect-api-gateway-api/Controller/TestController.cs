using Microsoft.AspNetCore.Mvc;

namespace collect_api_gateway.Controller
{
    [Route("/Test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = new
            {
                Message = "It is working!"
            };

            // Return 200 OK status code along with the data
            return Ok(data);
        }
    }
}
