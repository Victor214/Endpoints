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


        private string ReadConfirmation()
        {
            Console.WriteLine("Are you sure you want to close the application? (y/n)");
            return ReadString();
        }

        public override async Task ExecuteAsync()
        {
            // Confirmation
            string confirmation = ReadConfirmation();
            if (confirmation.ToLower() != "y")
            {
                return;
            }

            Console.Write("Exiting...");
            Environment.Exit(0);
        }
    }
}
