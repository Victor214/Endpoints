using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public class CreateEndpointCommand : BaseCommand
    {
        public override string BaseText => "1) Insert a new endpoint";

        protected override string Instructions => "New endpoint command instructions\nTest";

        public override async Task ExecuteAsync()
        {
            var stringTask = await Client.GetStringAsync("https://www.google.com");
        }
    }
}
