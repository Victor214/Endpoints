using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public class EditEndpointCommand : BaseCommand
    {
        public override string BaseText => "2) Edit an endpoint";

        protected override string Instructions => "Editing endpoint test";

        public override async Task ExecuteAsync()
        {
            Console.WriteLine(Instructions);
        }
    }
}
