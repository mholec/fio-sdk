namespace FioSdkCsharp
{
    public enum ExceptionReason
    {
        /// <summary>
        /// Generic error
        /// </summary>
        Generic,

        /// <summary>
        /// Invalid token
        /// </summary>
        InvalidCredentials,

        /// <summary>
        /// Rate limit, max 1 req. p. 30 sec.
        /// </summary>
        RateLimit,

        /// <summary>
        /// Bad Request data, filtering or validation failed
        /// </summary>
        BadRequest,

        /// <summary>
        /// Bad Request because of wrong collection limit
        /// </summary>
        TooManyItems,
    }
}