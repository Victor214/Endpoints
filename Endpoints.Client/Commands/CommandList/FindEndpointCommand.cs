using Endpoints.Client;
using Endpoints.Client.Commands.Input;
using Endpoints.Client.Commands.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public class FindEndpointCommand : BaseCommand
    {
        public override string BaseText => "5) Find an endpoint by serial number";

        private FindEndpointInput ReadInput()
        {
            Console.WriteLine("Enter the serial number of the endpoint you want to find (text):");
            string endpointSerialNumber = ReadString();

            FindEndpointInput input = new FindEndpointInput
            {
                EndpointSerialNumber = endpointSerialNumber
            };
            return input;
        }

        private void DisplayResult(FindEndpointOutput? findEndpointOutput)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Endpoint Serial Number: {findEndpointOutput?.EndpointSerialNumber}");
            Console.WriteLine($"Meter Model Id        : {findEndpointOutput?.MeterModelId}");
            Console.WriteLine($"Meter Number          : {findEndpointOutput?.MeterNumber}");
            Console.WriteLine($"Meter Firmware Version: {findEndpointOutput?.MeterFirmwareVersion}");
            Console.WriteLine($"Meter Switch State    : {findEndpointOutput?.SwitchState}");
            Console.WriteLine("----------------------------------------------------");
        }

        public override async Task ExecuteAsync()
        {
            var input = ReadInput();
            var editEndpointResponse = await Client.GetAsync($"{ClientConfig.ApiPath}/api/Endpoint/{input.EndpointSerialNumber}");
            if (!editEndpointResponse.IsSuccessStatusCode)
            {
                await DisplayError(editEndpointResponse);
                return;
            }

            var findEndpointOutput = await DeserializeResponseAsync<FindEndpointOutput>(editEndpointResponse);
            DisplayResult(findEndpointOutput);
        }
    }
}
