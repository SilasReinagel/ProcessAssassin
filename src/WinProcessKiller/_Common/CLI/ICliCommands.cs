using System.Linq;

public interface ICliCommands
{
    void Execute(string name, string[] args);
}

public static class CliCommandsExtensions
{
    public static void Execute(this ICliCommands commands, string[] args) => commands.Execute(args[0], args.Skip(1).ToArray());
}
