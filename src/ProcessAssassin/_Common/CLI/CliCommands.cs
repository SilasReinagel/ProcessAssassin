using System;
using System.Collections.Generic;
using System.Linq;

public sealed class CliCommands : ICliCommands
{
    private readonly Dictionary<string, Action<string[]>> _commands;

    public CliCommands(params ICliCommand[] commands)
        : this ((IEnumerable<ICliCommand>)commands) {}
    
    public CliCommands(IEnumerable<ICliCommand> commands)
        : this(commands.ToDictionary(x => x.Name.ToLowerInvariant(), k => (Action<string[]>)(k.Execute))) {}
    
    public CliCommands(Dictionary<string, Action<string[]>> commands)
    {
        _commands = commands;
    }

    public void Execute(string name, string[] args)
    {
        if (!_commands.ContainsKey(name.ToLowerInvariant()))
            throw new KeyNotFoundException($"Unknown command '{name}'");
        _commands[name](args);
    }
}
    
