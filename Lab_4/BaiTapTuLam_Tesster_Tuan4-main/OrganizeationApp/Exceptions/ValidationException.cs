using System;
using System.Collections.Generic;

namespace OrganizationApp.Exceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string> Errors { get; }

        public ValidationException(Dictionary<string, string> e)
        {
            Errors = e;
        }
    }
}