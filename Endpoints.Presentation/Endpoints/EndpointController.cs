using Endpoints.Application.Endpoints.CreateEndpoint;
using Endpoints.Application.Endpoints.EditEndpoint;
using Endpoints.Application.Endpoints.FindEndpoint;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Endpoints.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EndpointController : ControllerBase
    {
        private readonly ICreateEndpoint _createEndpoint;
        private readonly IEditEndpoint _editEndpoint;
        private readonly IFindEndpoint _findEndpoint;

        public EndpointController(
            ICreateEndpoint createEndpoint,
            IEditEndpoint editEndpoint,
            IFindEndpoint findEndpoint
        )
        {
            _createEndpoint = createEndpoint;
            _editEndpoint = editEndpoint;
            _findEndpoint = findEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEndpointAsync([FromBody] CreateEndpointModel createEndpointModel)
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

        [HttpPut("{endpointSerialNumber}")]
        public async Task<IActionResult> EditEndpointAsync([FromRoute] string? endpointSerialNumber, [FromBody] EditEndpointModel editEndpointModel)
        {
            try
            {
                editEndpointModel.EndpointSerialNumber = endpointSerialNumber;
                await _editEndpoint.Execute(editEndpointModel);
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

        [HttpGet("{endpointSerialNumber}")]
        public async Task<IActionResult> FindEndpointAsync([FromRoute] string? endpointSerialNumber)
        {
            try
            {
                FindEndpointModel findEndpointModel = new FindEndpointModel()
                {
                    EndpointSerialNumber = endpointSerialNumber
                };
                var findEndpointDto = await _findEndpoint.Execute(findEndpointModel);
                return Ok(findEndpointDto);
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
