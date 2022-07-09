using Endpoints.Application.Endpoints.CreateEndpoint;
using Endpoints.Presentation.Endpoints.Models;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EndpointController : ControllerBase
    {
        private readonly ICreateEndpoint _createEndpoint;

        public EndpointController(
            ICreateEndpoint createEndpoint
        )
        {
            _createEndpoint = createEndpoint;
        }

        [HttpPost]
        public IActionResult CreateEndpoint(CreateEndpointViewModel createEndpointViewModel)
        {
            var model = createEndpointViewModel.Endpoint;
            _createEndpoint.Execute(model);
            return Ok();
        }
    }
}
