using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Client.Commands.Input
{
    public class CreateEndpointInput
    {
        public string? EndpointSerialNumber { get; set; }
        public string? MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string? MeterFirmwareVersion { get; set; }
        public int SwitchState { get; set; }
    }
}
