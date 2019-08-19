using System;
using System.Linq;
using ProcessAssassin._Common.CLI;

public sealed class CommandsWithHelp : ICliCommand, ICliCommands
{
    private readonly string _appName;
    private readonly ILog _log;
    private readonly string _fullHelpText;
    private readonly ICliCommands _inner;

    public CommandsWithHelp(string appName, string exeName, ILog log, params ICliCommand[] commands)
    {
        _appName = appName;
        _log = log;
        var all = commands.Append(this).ToArray();
        _fullHelpText = $"Usage: {Environment.NewLine}" + string.Join($"{Environment.NewLine}", all.Select(x => $"  {exeName} {x.Info}"));
        _inner = new CliCommands(all);
    }

    public void Execute(string name, string[] args) => _inner.Execute(name, args);
    
    public CliCommandDoc Info { get; } = new CliCommandDoc("help") { Description = "Show this screen" };
    public void Execute(string[] args)
    {
        _log.Info($"{_appName} - {new AssemblyVersion()}");
        _log.Info("");
        _log.Info(_fullHelpText);
    }
}
