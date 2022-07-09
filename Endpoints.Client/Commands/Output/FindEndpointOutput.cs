using Endpoints.Commands.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Client.Commands.Output
{
    public class FindEndpointOutput
    {
        public string? EndpointSerialNumber { get; set; }
        public string? MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string? MeterFirmwareVersion { get; set; }
        public ESwitchState SwitchState { get; set; }
    }
}
