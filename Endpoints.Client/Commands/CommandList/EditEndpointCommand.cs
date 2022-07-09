using Endpoints.Client;
using Endpoints.Client.Commands.Input;
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
        public override string BaseText => "2) Edit an endpoint";

        private string ReadSerialNumber()
        {
            Console.WriteLine("Enter the serial number of the endpoint you want to update (text):");
            return ReadString();
        }

        private EditEndpointInput ReadInput()
        {
            Console.WriteLine("Enter a meter switch state to replace the old one (integer):");
            Console.WriteLine("  0) Disconnected");
            Console.WriteLine("  1) Connected");
            Console.WriteLine("  2) Armed");
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
            var input = ReadInput();
            input.EndpointSerialNumber = serialNumber;

            var editEndpointResponse = await Client.PutAsJsonAsync($"{ClientConfig.ApiPath}/api/Endpoint/{input.EndpointSerialNumber}", input);
            if (!editEndpointResponse.IsSuccessStatusCode)
            {
                await DisplayError(editEndpointResponse);
                return;
            }
            Console.WriteLine("Endpoint edited successfully.");
        }
    }
}
