using Endpoints.Client;
using Endpoints.Client.Commands.Attributes;
using Endpoints.Client.Commands.Input;
using Endpoints.Client.Commands.Output;
using Endpoints.Client.Common.Extensions;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public class FindEndpointCommand : BaseCommand
    {
        public override string BaseText => "Find an endpoint by serial number";
        private static readonly int EndpointDisplayTextMaxLength = 18;

        private FindEndpointInput ReadInput()
        {
            AnsiConsole.MarkupLine("Enter the [underline #f7d53e]serial number[/] of the endpoint you want to find ([#246ff0]text[/]):");
            string endpointSerialNumber = ReadString();

            FindEndpointInput input = new FindEndpointInput
            {
                EndpointSerialNumber = endpointSerialNumber
            };
            return input;
        }

        private List<(string key, string value)> GetDisplayData(EndpointOutput? endpointOutput)
        {
            List<(string key, string value)> allPropertiesData = new List<(string key, string value)>();
            PropertyInfo[] props = typeof(EndpointOutput).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var attr = prop.GetCustomAttribute<EndpointDisplayAttribute>();
                if (attr == null)
                {
                    continue;
                }

                var propData = prop.GetValue(endpointOutput)?.ToString();
                if (propData == null)
                {
                    continue;
                }

                var propDisplay = attr.Name.PadRight(EndpointDisplayTextMaxLength);
                allPropertiesData.Add((propDisplay, propData));
            }
            return allPropertiesData;
        }

        private void DisplayResult(EndpointOutput? findEndpointOutput)
        {
            AnsiConsole.MarkupLine("[#f28d8d]" + new string('-', 60) + "[/]");
            foreach (var propertyData in GetDisplayData(findEndpointOutput))
            {
                AnsiConsole.MarkupLineInterpolated($"[#f28d8d]{propertyData.key}:[/] {propertyData.value}");
            }
            AnsiConsole.MarkupLine("[#f28d8d]" + new string('-', 60) + "[/]");
        }

        public override async Task ExecuteAsync()
        {
            var findEndpointInput = ReadInput();
            var findEndpointResponse = await Client.GetAsync($"{ClientConfig.ApiPath}/api/Endpoint/{findEndpointInput.EndpointSerialNumber}");
            if (!findEndpointResponse.IsSuccessStatusCode)
            {
                await DisplayError(findEndpointResponse);
                return;
            }

            var findEndpointOutput = await DeserializeResponseAsync<EndpointOutput>(findEndpointResponse);
            DisplayResult(findEndpointOutput);
        }
    }
}
