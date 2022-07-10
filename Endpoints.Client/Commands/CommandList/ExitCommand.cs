using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public class ExitCommand : BaseCommand
    {
        public override string BaseText => "Exit the system";


        private string ReadConfirmation()
        {
            AnsiConsole.MarkupLine("Are you sure you want to [#f02443]close[/] the application? [underline #f7d53e](y/n)[/]");
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
