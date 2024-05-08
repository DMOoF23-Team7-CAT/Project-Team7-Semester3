namespace Rally.Application.Exceptions
{
    public class DatabaseException : ApplicationException
    {
        public DatabaseException(string businessMessage, Exception innerException) 
            : base(businessMessage, innerException)
        {
                        
        }
    }
}
