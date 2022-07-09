using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.EditEndpoint
{
    public class EditEndpointModel
    {
        public string? EndpointSerialNumber { get; set; }
        public int SwitchState { get; set; }
    }
}
