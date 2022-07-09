using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Client.Commands.Input
{
    public class EditEndpointInput
    {
        public string? EndpointSerialNumber { get; set; }
        public int SwitchState { get; set; }
    }
}
