namespace Shared.Exceptions
{
    public class InfraException : Exception
    {
        public InfraException(string message = "Internal server error") : base(message) { }
        public InfraException(Exception ex, string message = "Internal server error") : base(message, ex) { }
    }
}
