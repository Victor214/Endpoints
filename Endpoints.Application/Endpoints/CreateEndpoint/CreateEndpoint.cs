using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.CreateEndpoint
{
    public class CreateEndpoint : ICreateEndpoint
    {
        public async Task Execute(CreateEndpointModel model)
        {
            Endpoint endpoint = new Endpoint(
                model.EndpointSerialNumber,
                model.MeterModelId,
                model.MeterNumber,
                model.MeterFirmwareVersion,
                model.SwitchState
                );
        }
    }
}
