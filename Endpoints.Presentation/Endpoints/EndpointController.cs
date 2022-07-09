using Endpoints.Application.Endpoints.CreateEndpoint;
using Endpoints.Presentation.Endpoints.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> CreateEndpointAsync(CreateEndpointModel createEndpointModel)
        {
            try
            {
                await _createEndpoint.Execute(createEndpointModel);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
    }
}
