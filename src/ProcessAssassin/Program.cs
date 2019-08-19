using System.Linq;
using Commands;

class Program
{
    static void Main(string[] args)
    {
        var log = new ConsoleLog();
        var storage = JsonFileStorage.AppData("ProcessAssassin");
        var targetList = new KeyStored<ProcessTargetList>(storage, "targets", () => new ProcessTargetList());
        
        var defaultCommand = "run";
        var cmd = args.Length > 0 ? args[0] : defaultCommand;
        var paramArgs = args.Skip(1).ToArray();
        
        var currentTargets = targetList.Get();
        if (cmd.ToLowerInvariant() != "help")
        {
            log.Info($"Targeting {currentTargets.Count} Processes");
            currentTargets.ToList().ForEach(x => log.Info($"  {x}"));
        }

        new CommandsWithHelp("Process Assassin", "ProcessAssassin", log, 
            new Run(new WithDateTime(log), targetList), 
            new ViewCurrentProcessNames(log),
            new AddTargetProcess(log, targetList))
                .Execute(cmd, paramArgs);
    }
}
