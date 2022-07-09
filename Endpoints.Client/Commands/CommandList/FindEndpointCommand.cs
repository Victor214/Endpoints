using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public class FindEndpointCommand : BaseCommand
    {
        public override string BaseText => "5) Find an endpoint by serial number";
        protected override string Instructions => "New endpoint command instructions\nTest";

        public override async Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
