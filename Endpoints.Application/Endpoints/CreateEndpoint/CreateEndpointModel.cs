using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.CreateEndpoint
{
    public class CreateEndpointModel
    {
        public string EndpointSerialNumber { get; set; }
        public EModelId MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public ESwitchState SwitchState { get; set; }
    }
}
