using System.Diagnostics;

namespace FioSdkCsharp
{
    [DebuggerDisplay("AuthToken: {" + nameof(AuthToken) + "}")]
    public class FioClientConfiguration
    {
        public string AuthToken { get; set; }
    }
}