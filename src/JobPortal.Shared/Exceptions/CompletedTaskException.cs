using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Shared.Exceptions
{
    public class CompletedTaskException : Exception
    {
        public CompletedTaskException(string message) : base(message)
        {
        }


    }
}
