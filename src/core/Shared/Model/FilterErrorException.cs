namespace Shared.Model
{
    public class FilterErrorException
    {
        public List<string> Messages { get; set; } = [];

        public int ErrorCode { get; set; }

        public Exception ErrorException { get; set; }

        public FilterErrorException(List<string> messages,
            int errorCode,
            Exception exception)
        {
            Messages = messages;
            ErrorCode = errorCode;
            ErrorException = exception;
        }

        public FilterErrorException(string message,
            int errorCode,
            Exception exception)
        {
            Messages = [message];
            ErrorCode = errorCode;
            ErrorException = exception;
        }
    }
}
