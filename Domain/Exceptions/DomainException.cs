namespace Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string exception) : base(exception)
        {

        }
    }
}
