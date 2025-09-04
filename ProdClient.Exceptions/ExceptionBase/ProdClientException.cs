using System.Net;

namespace ProdClient.Exceptions.ExceptionBase
{
    public abstract class ProdClientException : SystemException
    {
        public ProdClientException(string errorMessage) : base(errorMessage)
        { 
        }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
