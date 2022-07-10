using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.CreateEndpoint.Factory
{
    public class EndpointFactory : IEndpointFactory
    {
        public Endpoint Create(string? endpointSerialNumber, string? meterModelId, int meterNumber, string? meterFirmwareVersion, int switchState)
        {
            var endpoint = new Endpoint(endpointSerialNumber, meterModelId, meterNumber, meterFirmwareVersion, switchState);
            return endpoint;
        }
    }
}
