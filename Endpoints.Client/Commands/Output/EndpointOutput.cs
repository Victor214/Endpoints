using Endpoints.Client.Commands.Attributes;
using Endpoints.Commands.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Client.Commands.Output
{
    public class EndpointOutput
    {
        [EndpointDisplay(Name = "Serial Number")]
        public string? EndpointSerialNumber { get; set; }

        [EndpointDisplay(Name = "Model Id")]
        public string? MeterModelId { get; set; }

        [EndpointDisplay(Name = "Meter Number")]
        public int MeterNumber { get; set; }

        [EndpointDisplay(Name = "Firmware Version")]
        public string? MeterFirmwareVersion { get; set; }

        [EndpointDisplay(Name = "Switch State")]
        public ESwitchState SwitchState { get; set; }
    }
}
