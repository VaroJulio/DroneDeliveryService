namespace Application.Exceptions
{
    internal class BadRequestCustomException : IOException
    {
        public int StatusCode { get; }
        public BadRequestCustomException(string message) : base(message) { StatusCode = 400; }
    }
}
