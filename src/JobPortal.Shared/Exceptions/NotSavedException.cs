using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Shared.Exceptions
{
    public class NotSavedException : Exception
    {
        public NotSavedException(string message) : base(message)
        {
        }

        public NotSavedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
