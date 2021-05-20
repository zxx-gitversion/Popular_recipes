using System.Web;

namespace GMS.Framework.Web
{
    public class ExplicitException : HttpException
    {
        public ExplicitException()
            : base()
        {
        }

        public ExplicitException(string message)
            : base(message)
        {
        }

        public ExplicitException(int httpCode, string message)
            : base(httpCode, message)
        {
        }
    }
}
