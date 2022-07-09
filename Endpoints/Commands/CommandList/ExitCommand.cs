using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public class ExitCommand : BaseCommand
    {
        public override string BaseText => "6) Exit the system";
        protected override string Instructions => "New endpoint command instructions\nTest";

        public override async Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
