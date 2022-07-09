using Endpoints.Client.Commands.Output;
using Endpoints.Client;
using Endpoints.Client.Common.Extensions;
using System.Reflection;
using Endpoints.Client.Commands.Attributes;

namespace Endpoints.Commands.CommandList
{
    public class ListEndpointCommand : BaseCommand
    {
        public override string BaseText => "4) List all endpoints";
        private static readonly string tableSeparator = " | ";

        private List<string> GetFormattedEndpointColumns()
        {
            List<string> columns = new List<string>();
            PropertyInfo[] props = typeof(EndpointOutput).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var attr = prop.GetCustomAttribute<EndpointDisplayAttribute>();
                if (attr == null)
                {
                    continue;
                }

                columns.Add(attr.Name.TruncateWithEllipsis(attr.TableMaxWidth));
            }
            return columns;
        }

        private List<string> GetFormattedEndpointRow(EndpointOutput endpointOutput)
        {
            List<string> cells = new List<string>();
            PropertyInfo[] props = typeof(EndpointOutput).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var attr = prop.GetCustomAttribute<EndpointDisplayAttribute>();
                if (attr == null)
                {
                    continue;
                }

                var cell = prop.GetValue(endpointOutput)?.ToString();
                if (cell == null)
                {
                    continue;
                }

                cell = cell.TruncateWithEllipsis(attr.TableMaxWidth);
                cells.Add(cell);
            }
            return cells;
        }

        private int CalculateTotalRowWidth()
        {
            int total = 0;
            PropertyInfo[] props = typeof(EndpointOutput).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var attr = prop.GetCustomAttribute<EndpointDisplayAttribute>();
                if (attr == null)
                {
                    continue;
                }

                total += attr.TableMaxWidth + tableSeparator.Length;
            }
            return total - tableSeparator.Length;
        }

        private void DisplayTableResult(List<EndpointOutput>? listEndpointOutput)
        {
            var columns = GetFormattedEndpointColumns();
            Console.WriteLine(string.Join(tableSeparator, columns));
            Console.WriteLine(" " + new string('-', CalculateTotalRowWidth()));

            foreach (var endpointOutput in listEndpointOutput)
            {
                var row = GetFormattedEndpointRow(endpointOutput);
                Console.WriteLine(string.Join(tableSeparator, row));
            }
        }

        public override async Task ExecuteAsync()
        {
            var listEndpointResponse = await Client.GetAsync($"{ClientConfig.ApiPath}/api/Endpoint");
            if (!listEndpointResponse.IsSuccessStatusCode)
            {
                await DisplayError(listEndpointResponse);
                return;
            }

            var listEndpointOutput = await DeserializeResponseAsync<List<EndpointOutput>>(listEndpointResponse);
            DisplayTableResult(listEndpointOutput);
        }
    }
}
