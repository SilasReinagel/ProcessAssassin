using System.Collections.Generic;
using System.Linq;

namespace ProcessAssassin._Common.CLI
{
    public sealed class CliCommandDoc
    {
        public string Name { get; }

        public bool IsDefaultCommand { get; set; } = false;
        public List<string> RequiredPositionalArgs { get; set; } = new List<string>();
        public List<string> OptionalPositionalArgs { get; set; } = new List<string>();
        public string Description { get; set; } = "";

        public CliCommandDoc(string name) => Name = name;
        
        public override string ToString() => $"{Command()} {Description}";

        private string Optional(string name) => $"[{name}]";

        private string Command() =>
            ($"{(IsDefaultCommand ? Optional(Name) : Name)}" +
            $"{string.Concat(RequiredPositionalArgs.Select(a => " <" + a + ">"))}" +
            $"{string.Concat(OptionalPositionalArgs.Select(a => " [" + a + "]"))}")
                .PadRight(24);
    }
}
