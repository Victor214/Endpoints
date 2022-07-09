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
        [EndpointDisplay(Name = "Serial Number", TableMaxWidth = 15)]
        public string? EndpointSerialNumber { get; set; }

        [EndpointDisplay(Name = "Model Id", TableMaxWidth = 11)]
        public string? MeterModelId { get; set; }

        [EndpointDisplay(Name = "Meter Number", TableMaxWidth = 13)]
        public int MeterNumber { get; set; }

        [EndpointDisplay(Name = "Firmware Version", TableMaxWidth = 16)]
        public string? MeterFirmwareVersion { get; set; }

        [EndpointDisplay(Name = "Switch State", TableMaxWidth = 13)]
        public ESwitchState SwitchState { get; set; }
    }
}
