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
    public class DeleteEndpointCommand : BaseCommand
    {
        public override string BaseText => "3) Delete endpoint";

        private string ReadSerialNumber()
        {
            Console.WriteLine("Enter the serial number of the endpoint you want to delete (text):");
            return ReadString();
        }

        private string ReadConfirmation()
        {
            Console.WriteLine("Are you sure you would like to delete this endpoint? (y/n)");
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
            Console.WriteLine("Endpoint removed successfully.");
        }
    }
}
