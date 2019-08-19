using System.Diagnostics;
using System.Linq;
using ProcessAssassin._Common.CLI;

namespace Commands
{
    public sealed class ViewCurrentProcessNames : ICliCommand
    {
        private readonly ILog _log;

        public ViewCurrentProcessNames(ILog log)
        {
            _log = log;
        }

        public CliCommandDoc Info { get; } = new CliCommandDoc("current") { Description = "Lists all currently running process names" };

        public void Execute(string[] args) =>
            Process.GetProcesses()
                .Select(x => x.ProcessName)
                .Distinct()
                .OrderBy(x => x)
                .ToList()
                .ForEach(p => _log.Info(p));
    }
}
