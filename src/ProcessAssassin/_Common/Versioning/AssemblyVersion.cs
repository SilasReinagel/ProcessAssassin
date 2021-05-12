using System.Reflection;

public sealed class AssemblyVersion
{
    public override string ToString() 
        => $"v{Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "Unknown Version"}";
}
