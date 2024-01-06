namespace Shared.Exceptions
{
    public class BusinessException(List<string> messages) : Exception
    {
        public List<string> Messages { get; set; } = messages;
    }
}
