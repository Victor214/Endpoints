using Endpoints.Client.Commands.Output;
using Endpoints.Client;
using System.Reflection;
using Endpoints.Client.Commands.Attributes;
using Spectre.Console;

namespace Endpoints.Commands.CommandList
{
    public class ListEndpointCommand : BaseCommand
    {
        public override string BaseText => "List all endpoints";

        private List<string> GetEndpointColumns()
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

                columns.Add(attr.Name);
            }
            return columns;
        }

        private List<string> GetEndpointRow(EndpointOutput endpointOutput)
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

                cells.Add(cell);
            }
            return cells;
        }

        private void DisplayTableResult(List<EndpointOutput>? listEndpointOutput)
        { 
            var columns = GetEndpointColumns();
            var tableColumns = columns.Select(
                x => new TableColumn(new Panel(x).BorderColor(Color.IndianRed_1)));

            var table = new Table();
            table.AddColumns(tableColumns.ToArray());
            foreach (var endpointOutput in listEndpointOutput)
            {
                var row = GetEndpointRow(endpointOutput);
                table.AddRow(row.ToArray());
            }
            AnsiConsole.Write(table);
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
