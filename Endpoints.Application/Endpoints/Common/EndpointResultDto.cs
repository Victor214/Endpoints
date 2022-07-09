using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.Common
{
    public class EndpointResultDto
    {
        public string? EndpointSerialNumber { get; set; }
        public string? MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string? MeterFirmwareVersion { get; set; }
        public ESwitchState SwitchState { get; set; }
    }
}
