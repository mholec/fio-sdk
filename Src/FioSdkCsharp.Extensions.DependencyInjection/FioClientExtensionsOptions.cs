using System.Diagnostics;

namespace FioSdkCsharp.Extensions.DependencyInjection
{
    [DebuggerDisplay("AuthToken: {" + nameof(AuthToken) + "}")]
    public sealed class FioClientExtensionsOptions : FioClientConfiguration
    {
    }
}