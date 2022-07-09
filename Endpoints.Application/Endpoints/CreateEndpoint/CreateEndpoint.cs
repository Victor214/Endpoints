using Endpoints.Application.Interfaces;
using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.CreateEndpoint
{
    public class CreateEndpoint : ICreateEndpoint
    {
        private readonly IEndpointRepository _endpointRepository;

        public CreateEndpoint(
            IEndpointRepository endpointRepository
            )
        {
            _endpointRepository = endpointRepository;
        }

        public async Task Execute(CreateEndpointModel model)
        {
            Endpoint endpoint = new Endpoint(
                model.EndpointSerialNumber,
                model.MeterModelId,
                model.MeterNumber,
                model.MeterFirmwareVersion,
                model.SwitchState
                );

            Endpoint? repeatedEndpoint = _endpointRepository.GetEndpointBySerialNumber(endpoint.EndpointSerialNumber);
            if (repeatedEndpoint != null)
                throw new ValidationException("An endpoint already exists with the given serial number.");

            await _endpointRepository.CreateAsync(endpoint);
            await _endpointRepository.SaveAsync();
        }
    }
}
