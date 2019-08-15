using System;
using System.Linq;

public sealed class CommandsWithHelp : ICliCommand, ICliCommands
{
    private readonly ILog _log;
    private readonly string _fullHelpText;
    private readonly ICliCommands _inner;

    public string Name => "help";
    public string HelpText => "usage: help";

    public CommandsWithHelp(ILog log, params ICliCommand[] commands)
    {
        _log = log;
        var all = commands.Append(this).OrderBy(x => x.Name).ToArray();
        _fullHelpText = $"Commands: {Environment.NewLine}" + string.Join(Environment.NewLine, all.Select(x => new CliCommandHelpText(x)));
        _inner = new CliCommands(all);
    }

    public void Execute(string[] args) => _log.Info(_fullHelpText);

    public void Execute(string name, string[] args) => _inner.Execute(name, args);
}
