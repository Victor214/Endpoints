using Endpoints.Client.Commands.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public abstract class BaseCommand
    {
        public abstract string BaseText { get; }
        protected HttpClient Client { get; set; } = new HttpClient()
        {
            Timeout = TimeSpan.FromMinutes(10)
        };
        public abstract Task ExecuteAsync();


        protected string ReadString()
        {
            var input = Console.ReadLine() ?? "";
            return input;
        }

        protected int ReadInt()
        {
            var input = Console.ReadLine() ?? "";
            var hasParsed = int.TryParse(input, out var intInput);
            if (!hasParsed)
            {
                Console.WriteLine("Please input a valid integer.");
                return ReadInt();
            }

            return intInput;
        }

        protected async Task DisplayError(HttpResponseMessage endpointResponse)
        {
            if (endpointResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                var textContent = await endpointResponse.Content.ReadAsStringAsync();
                Console.WriteLine(textContent);
            }
            else
            {
                Console.WriteLine($"An error has occurred when communicating with the server. StatusCode: {endpointResponse.StatusCode}");
            }
        }

        protected static async Task<T?> DeserializeResponseAsync<T>(HttpResponseMessage? response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var output = JsonSerializer.Deserialize<T>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return output;
        }

        public BaseCommand()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        }
    }
}
