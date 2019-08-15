using System.Collections.Generic;
using System.Linq;

public sealed class ProcessTargetList : HashSet<string>
{
    public void OutputTo(ILog log) => this.ToList().ForEach(x => log.Info(x));
}
