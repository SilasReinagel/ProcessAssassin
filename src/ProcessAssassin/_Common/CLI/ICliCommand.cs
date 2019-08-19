
using ProcessAssassin._Common.CLI;

public interface ICliCommand
{
    CliCommandDoc Info { get; }
    void Execute(string[] args);
}

public static class ICliCommandExtensions
{
    public static string Name(this ICliCommand cmd) => cmd.Info.Name;
}
