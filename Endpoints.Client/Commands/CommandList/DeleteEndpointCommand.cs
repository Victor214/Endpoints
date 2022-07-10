using Endpoints.Client;
using Endpoints.Client.Commands.Input;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public class DeleteEndpointCommand : BaseCommand
    {
        public override string BaseText => "Delete endpoint";

        private string ReadSerialNumber()
        {
            AnsiConsole.MarkupLine("Enter the [underline #f7d53e]serial number[/] of the endpoint you want to delete ([#246ff0]text[/]):");
            return ReadString();
        }

        private string ReadConfirmation()
        {
            AnsiConsole.MarkupLine("Are you sure you would like to [#f02443]delete[/] this endpoint? [underline #f7d53e](y/n)[/]");
            return ReadString();
        }

        public override async Task ExecuteAsync()
        {
            // Checks if given endpoint exists by attempting to hit the FIND endpoint.
            var serialNumber = ReadSerialNumber();
            var findEndpointResponse = await Client.GetAsync($"{ClientConfig.ApiPath}/api/Endpoint/{serialNumber}");
            if (!findEndpointResponse.IsSuccessStatusCode)
            {
                await DisplayError(findEndpointResponse);
                return;
            }

            // Confirmation
            string confirmation = ReadConfirmation();
            if (confirmation.ToLower() != "y")
            {
                Console.WriteLine("Operation canceled by user request.");
                return;
            }

            // Executes delete
            var deleteEndpointResponse = await Client.DeleteAsync($"{ClientConfig.ApiPath}/api/Endpoint/{serialNumber}");
            if (!deleteEndpointResponse.IsSuccessStatusCode)
            {
                await DisplayError(deleteEndpointResponse);
                return;
            }
            AnsiConsole.MarkupLine("[#3ce66c]Endpoint removed successfully.[/]");
        }
    }
}
