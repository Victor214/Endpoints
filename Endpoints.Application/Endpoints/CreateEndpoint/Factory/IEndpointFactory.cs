using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.CreateEndpoint.Factory
{
    public interface IEndpointFactory
    {
        Endpoint Create(string? endpointSerialNumber, string? meterModelId, int meterNumber, string? meterFirmwareVersion, int switchState);
    }
}
