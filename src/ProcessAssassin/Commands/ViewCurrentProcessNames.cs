using System.Diagnostics;
using System.Linq;

namespace Commands
{
    public sealed class ViewCurrentProcessNames : ICliCommand
    {
        private readonly ILog _log;
        public string Name => "viewCurrent";
        public string HelpText => "Lists all process names";

        public ViewCurrentProcessNames(ILog log)
        {
            _log = log;
        }
        
        public void Execute(string[] args) =>
            Process.GetProcesses()
                .Select(x => x.ProcessName)
                .Distinct()
                .OrderBy(x => x)
                .ToList()
                .ForEach(p => _log.Info(p));
    }
}
