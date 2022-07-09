using Endpoints.Application.Endpoints.FindEndpoint;
using Endpoints.Application.Interfaces;
using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.FindEndpoint
{
    public class FindEndpoint : IFindEndpoint
    {
        private readonly IEndpointRepository _endpointRepository;

        public FindEndpoint(
            IEndpointRepository endpointRepository
            )
        {
            _endpointRepository = endpointRepository;
        }

        public async Task<FindEndpointDto> Execute(FindEndpointModel model)
        {
            Endpoint? existingEndpoint = await _endpointRepository.GetEndpointBySerialNumberAsync(model.EndpointSerialNumber);
            if (existingEndpoint == null)
                throw new ValidationException("No endpoint was found with the given serial number.");

            return new FindEndpointDto
            {
                EndpointSerialNumber = existingEndpoint.EndpointSerialNumber,
                MeterModelId = existingEndpoint.MeterModelId.ToString(),
                MeterNumber = existingEndpoint.MeterNumber,
                MeterFirmwareVersion = existingEndpoint.MeterFirmwareVersion,
                SwitchState = existingEndpoint.SwitchState,
            };
        }
    }
}
