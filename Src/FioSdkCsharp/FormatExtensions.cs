namespace FioSdkCsharp
{
    public static class FormatExtensions
    {
        public static string AsString(this Format format)
        {
            return format.ToString().ToLowerInvariant();
        }
    }
}