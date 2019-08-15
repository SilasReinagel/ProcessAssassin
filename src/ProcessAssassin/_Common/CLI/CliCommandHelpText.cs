
public sealed class CliCommandHelpText
{
    private readonly ICliCommand _command;

    public CliCommandHelpText(ICliCommand command) => _command = command;

    public override string ToString() => $"\t{_command.Name}\t\t{_command.HelpText}";

    public static implicit operator string(CliCommandHelpText text) => text.ToString();
}
