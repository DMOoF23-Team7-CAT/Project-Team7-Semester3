
namespace Rally.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        internal NotFoundException(string businessMessage) : base(businessMessage)
        {
        }
    }
}