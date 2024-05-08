
namespace Rally.Application.Exceptions
{
    public class MappingException : ApplicationException
    {
        internal MappingException(string businessMessage) : base(businessMessage)
        {
        }
    }
}