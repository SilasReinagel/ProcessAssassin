using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Commands
{
    public sealed class Run : ICliCommand
    {
        private readonly IStored<ProcessTargetList> _targets;
        private readonly ILog _log;

        public string Name => "run";
        public string HelpText => "Runs the Process Killer";
        
        public Run(ILog log, IStored<ProcessTargetList> targets)
        {
            _targets = targets;
            _log = log;
        }

        public void Execute(string[] args)
        {
            while (true)
            {
                var targets = _targets.Get();
                var processes = Process.GetProcesses();
                processes
                    .Where(x => targets.Contains(x.ProcessName))
                    .OrderBy(x => x.ProcessName)
                    .ToList()
                    .ForEach(x =>
                    {
                        x.Kill();
                        _log.Info($"Killed {x.ProcessName}");
                    });
                
                Thread.Sleep(2000);
            }
        }
    }
}
