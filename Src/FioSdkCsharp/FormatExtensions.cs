namespace FioSdkCsharp
{
    public static class FormatExtensions
    {
        public static string AsString(this Format f)
        {
            return f.ToString().ToLowerInvariant();
        }
    }
}