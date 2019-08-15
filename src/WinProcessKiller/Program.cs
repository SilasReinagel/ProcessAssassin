using System.Linq;
using WinProcessKiller.Commands;

namespace WinProcessKiller
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new ConsoleLog();
            var storage = JsonFileStorage.AppData("WinProcessKiller");
            var targetList = new KeyStored<ProcessTargetList>(storage, "targets.json", () => new ProcessTargetList());

            var currentTargets = targetList.Get();
            log.Info($"Targeting {currentTargets.Count} Processes");
            currentTargets.ToList().ForEach(x => log.Info($"Targeting Process: {x}"));

            var defaultCommand = "run";
            var cmd = args.Length > 0 ? args[0] : defaultCommand;
            var paramArgs = args.Skip(1).ToArray();
            
            new CommandsWithHelp(log, 
                new Run(new WithDateTime(log), targetList), 
                new ViewCurrentProcessNames(log),
                new AddTargetProcess(log, targetList))
                    .Execute(cmd, paramArgs);
        }
    }
}
