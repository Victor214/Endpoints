using Endpoints.Application.Endpoints.CreateEndpoint.Factory;
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
        private readonly IEndpointFactory _endpointFactory;

        public CreateEndpoint(
            IEndpointRepository endpointRepository,
            IEndpointFactory endpointFactory
            )
        {
            _endpointRepository = endpointRepository;
            _endpointFactory = endpointFactory;
        }

        public async Task Execute(CreateEndpointModel model)
        {
            Endpoint endpoint = _endpointFactory.Create(
                model.EndpointSerialNumber,
                model.MeterModelId,
                model.MeterNumber,
                model.MeterFirmwareVersion,
                model.SwitchState
                );

            bool exists = await _endpointRepository.SerialNumberExists(endpoint.EndpointSerialNumber);
            if (exists)
                throw new ValidationException("An endpoint already exists with the given serial number.");

            _endpointRepository.Create(endpoint);
            await _endpointRepository.SaveAsync();
        }
    }
}
