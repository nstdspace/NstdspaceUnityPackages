namespace Nstdspace.UnityCodeGenerator
{
    public record GeneratedSource(
        string SourceCode,
        string Name,
        string RelativeNamespace = ""
    );
}