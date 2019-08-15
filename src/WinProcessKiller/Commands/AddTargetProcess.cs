namespace WinProcessKiller.Commands
{
    public sealed class AddTargetProcess : ICliCommand
    {
        private readonly ILog _log;
        private readonly IStored<ProcessTargetList> _targets;
        public string Name => "add";
        public string HelpText => "Adds Targeted Process";

        public AddTargetProcess(ILog log, IStored<ProcessTargetList> targets)
        {
            _log = log;
            _targets = targets;
        }
        
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
                    t.Add(args[0]);
                    t.OutputTo(_log);
                    return t;
                });
            }
        }
    }
}
