// Added to avoid bug in .NET
// Ref.: https://stackoverflow.com/a/64749403
namespace System.Runtime.CompilerServices
{
    public static class IsExternalInit {}
}