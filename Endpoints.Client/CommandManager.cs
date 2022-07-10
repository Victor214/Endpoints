using Endpoints.Commands.CommandList;
using Endpoints.Commands.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints
{
    public class CommandManager
    {
        public readonly Dictionary<EEndpointCommand, BaseCommand> Commands = new Dictionary<EEndpointCommand, BaseCommand>
        {
            {EEndpointCommand.CreateEndpoint, new CreateEndpointCommand()},
            {EEndpointCommand.EditEndpoint,   new EditEndpointCommand()},
            {EEndpointCommand.DeleteEndpoint, new DeleteEndpointCommand()},
            {EEndpointCommand.ListEndpoint,   new ListEndpointCommand()},
            {EEndpointCommand.FindEndpoint,   new FindEndpointCommand()},
            {EEndpointCommand.Exit,           new ExitCommand()},
        };

        public void PrintOptions()
        {
            foreach (var command in Commands)
            {
                var commandClass = command.Value;
                Console.WriteLine(commandClass.BaseText);
            }
        }

        public EEndpointCommand? ReadOption()
        {
            var input = Console.ReadLine();
            if (input == null)
            {
                return null;
            }

            if (!IsValidCommandInput(input))
            {
                return null;
            }

            return (EEndpointCommand)int.Parse(input);
        }

        public async Task ExecuteOption(EEndpointCommand commandId)
        {
            var commandClass = Commands[commandId];
            await commandClass.ExecuteAsync();
            ClearConsole();
        }

        public static void ClearConsole()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private bool IsValidCommandInput(string? input)
        {
            var hasParsed = int.TryParse(input, out int digit);
            if (!hasParsed)
            {
                return false;
            }

            if (!Commands.ContainsKey((EEndpointCommand)digit))
            {
                return false;
            }

            return true;
        }
    }
}
