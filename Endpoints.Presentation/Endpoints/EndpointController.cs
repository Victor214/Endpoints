using Endpoints.Application.Endpoints.CreateEndpoint;
using Endpoints.Application.Endpoints.DeleteEndpoint;
using Endpoints.Application.Endpoints.EditEndpoint;
using Endpoints.Application.Endpoints.FindEndpoint;
using Endpoints.Application.Endpoints.ListEndpoint;
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
        private readonly IDeleteEndpoint _deleteEndpoint;
        private readonly IFindEndpoint _findEndpoint;
        private readonly IListEndpoint _listEndpoint;

        public EndpointController(
            ICreateEndpoint createEndpoint,
            IEditEndpoint editEndpoint,
            IDeleteEndpoint deleteEndpoint,
            IFindEndpoint findEndpoint,
            IListEndpoint listEndpoint
        )
        {
            _createEndpoint = createEndpoint;
            _editEndpoint = editEndpoint;
            _deleteEndpoint = deleteEndpoint;
            _findEndpoint = findEndpoint;
            _listEndpoint = listEndpoint;
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

        [HttpDelete("{endpointSerialNumber}")]
        public async Task<IActionResult> DeleteEndpointAsync([FromRoute] string? endpointSerialNumber)
        {
            try
            {
                DeleteEndpointModel deleteEndpointModel = new DeleteEndpointModel()
                {
                    EndpointSerialNumber = endpointSerialNumber
                };
                await _deleteEndpoint.Execute(deleteEndpointModel);
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

        [HttpGet]
        public async Task<IActionResult> ListEndpointAsync()
        {
            try
            {
                var endpointsDto = await _listEndpoint.Execute();
                return Ok(endpointsDto);
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
