using Endpoints;

while (true)
{
    CommandManager commandManager = new CommandManager();
    commandManager.PrintOptions();
    var option = commandManager.ReadOption();
    if (option == null)
    {
        Console.WriteLine("O comando ou entrada especificado não foi reconhecido.");
        return;
    }
    await commandManager.ExecuteOption(option.Value);
}