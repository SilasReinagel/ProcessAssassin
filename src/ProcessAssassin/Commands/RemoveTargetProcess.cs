using ProcessAssassin._Common.CLI;

namespace Commands
{
    public sealed class RemoveTargetProcess : ICliCommand
    {
        private readonly ILog _log;
        private readonly IStored<ProcessTargetList> _targets;

        public RemoveTargetProcess(ILog log, IStored<ProcessTargetList> targets)
        {
            _log = log;
            _targets = targets;
        }

        public CliCommandDoc Info { get; } = new CliCommandDoc("remove") { Description = "Removes Targeted Process", RequiredPositionalArgs = "processname".AsList() };

        public void Execute(string[] args)
        {
            if (args.Length < 1)
            {
                _log.Error("Missing Target Process Name");
            }
            else
            {
                _targets.Update(t =>
                {
                    t.Remove(args[0]);
                    t.OutputTo(_log);
                    return t;
                });
            }
        }
    }
}
