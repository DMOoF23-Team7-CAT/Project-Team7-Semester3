namespace Rally.Application.Exceptions
{
    public class DatabaseException : ApplicationException
    {
        internal DatabaseException(string businessMessage)  {}
        internal DatabaseException(string businessMessage, Exception innerException)  {}
    }
}
