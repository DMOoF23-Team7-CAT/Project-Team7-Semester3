﻿
namespace Rally.Application.Exceptions
{
    public class ApplicationException : Exception
    {
        internal ApplicationException() : base() { }
        internal ApplicationException(string businessMessage)
               : base(businessMessage)
        {
        }

        internal ApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
