using System;

namespace FioSdkCsharp.Exceptions
{
    public class ApiExplorerException : Exception
    {
        public ApiExplorerException() { }

        public ApiExplorerException(string message) : base(message) { }

        public ApiExplorerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
