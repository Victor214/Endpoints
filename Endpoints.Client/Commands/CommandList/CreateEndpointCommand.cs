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
    public class CreateEndpointCommand : BaseCommand
    {
        public override string BaseText => "Insert a new endpoint";

        private CreateEndpointInput ReadInput()
        {
            AnsiConsole.MarkupLine("Enter a [underline #f7d53e]serial number[/] ([#246ff0]text[/]):");
            string endpointSerialNumber = ReadString();

            AnsiConsole.MarkupLine("Enter a [underline #f7d53e]meter model id[/] ([#246ff0]text[/]):");
            string meterModelId = ReadString();

            AnsiConsole.MarkupLine("Enter a [underline #f7d53e]meter number[/] ([#f02443]integer[/]):");
            int meterNumber = ReadInt();

            AnsiConsole.MarkupLine("Enter a [underline #f7d53e]meter firmware version[/] ([#246ff0]text[/]):");
            string meterFirmwareVersion = ReadString();

            AnsiConsole.MarkupLine("Enter a [underline #f7d53e]meter switch state[/] ([#f02443]integer[/]):");
            AnsiConsole.MarkupLine("  [#f02443]0)[/] Disconnected");
            AnsiConsole.MarkupLine("  [#f02443]1)[/] Connected");
            AnsiConsole.MarkupLine("  [#f02443]2)[/] Armed");
            int switchState = ReadInt();

            CreateEndpointInput input = new CreateEndpointInput
            {
                EndpointSerialNumber = endpointSerialNumber,
                MeterModelId = meterModelId,
                MeterNumber = meterNumber,
                MeterFirmwareVersion = meterFirmwareVersion,
                SwitchState = switchState
            };
            return input;
        }

        public override async Task ExecuteAsync()
        {
            var createEndpointInput = ReadInput();
            var createEndpointResponse = await Client.PostAsJsonAsync($"{ClientConfig.ApiPath}/api/Endpoint/", createEndpointInput);
            if (!createEndpointResponse.IsSuccessStatusCode)
            {
                await DisplayError(createEndpointResponse);
                return;
            }
            AnsiConsole.MarkupLine("[#3ce66c]Endpoint created successfully.[/]");
        }
    }
}
