
public interface ICliCommand
{
    string Name { get; }
    string HelpText { get; }
    void Execute(string[] args);
}
