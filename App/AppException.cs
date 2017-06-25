using System;

namespace App.Framework
{
    /// <summary>
    /// Base exception type for those are thrown by App system for App specific exceptions.
    /// </summary>
    public class AppException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="AppException"/> object.
        /// </summary>
        public AppException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="AppException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AppException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AppException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public AppException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
