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
    public class EditEndpointCommand : BaseCommand
    {
        public override string BaseText => "Edit an endpoint";

        private string ReadSerialNumber()
        {
            AnsiConsole.MarkupLine("Enter the [underline #f7d53e]serial number[/] of the endpoint you want to update ([#246ff0]text[/]):");
            return ReadString();
        }

        private EditEndpointInput ReadInput()
        {
            AnsiConsole.MarkupLine("Enter a [underline #f7d53e]meter switch state[/] to replace the old one ([#f02443]integer[/]):");
            AnsiConsole.MarkupLine("  [#f02443]0)[/] Disconnected");
            AnsiConsole.MarkupLine("  [#f02443]1)[/] Connected");
            AnsiConsole.MarkupLine("  [#f02443]2)[/] Armed");
            int switchState = ReadInt();

            EditEndpointInput input = new EditEndpointInput
            {
                SwitchState = switchState
            };
            return input;
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

            // Finally executes the edit call
            var editEndpointInput = ReadInput();
            editEndpointInput.EndpointSerialNumber = serialNumber;

            var editEndpointResponse = await Client.PutAsJsonAsync($"{ClientConfig.ApiPath}/api/Endpoint/{editEndpointInput.EndpointSerialNumber}", editEndpointInput);
            if (!editEndpointResponse.IsSuccessStatusCode)
            {
                await DisplayError(editEndpointResponse);
                return;
            }
            AnsiConsole.MarkupLine("[#3ce66c]Endpoint edited successfully.[/]");
        }
    }
}
