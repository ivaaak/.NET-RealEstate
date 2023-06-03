namespace RealEstate.Shared.Core.Exceptions
{
    public abstract class BaseException : Exception
    {
        private protected BaseException() { }

        private protected BaseException(string message) : base(message) { }
    }
}
