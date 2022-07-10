using Endpoints;

while (true)
{
    CommandManager commandManager = new CommandManager();
    commandManager.PrintOptions();
    var option = commandManager.ReadOption();
    if (option == null)
    {
        Console.WriteLine("The specified command or input was not recognized as a valid action.");
        CommandManager.ClearConsole();
        continue;
    }
    await commandManager.ExecuteOption(option.Value);
}