namespace Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        public DomainException(string exception) : base(exception)
        {

        }
    }
}
