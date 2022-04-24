using System;

namespace FioSdkCsharp
{
    /// <summary>
    /// Generic exception in FioClient
    /// </summary>
    public class FioClientException : Exception
    {
        public ExceptionReason Reason { get; private set; }

        public FioClientException(string message, Exception innerException, ExceptionReason reason = ExceptionReason.Generic) : base(message, innerException)
        {
            Reason = reason;
        }
    }
}