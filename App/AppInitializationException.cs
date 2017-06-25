using System;
using System.Collections.Generic;
using System.Text;

namespace App.Framework
{
    public class AppInitializationException : AppException
    {
        public AppInitializationException() { }

        public AppInitializationException(string message) : base(message)
        {
        }

        public AppInitializationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
