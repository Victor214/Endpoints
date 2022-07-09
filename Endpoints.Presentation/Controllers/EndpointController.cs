using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EndpointController : ControllerBase
    {
        public EndpointController()
        {

        }

        [HttpGet]
        public List<string> Get()
        {
            return new List<string>()
            {
                "Test",
                "String"
            };
        }
    }
}
