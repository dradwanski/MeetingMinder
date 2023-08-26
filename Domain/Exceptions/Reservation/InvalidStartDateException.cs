namespace Domain.Exceptions.Reservation
{
    public class InvalidStartDateException : DomainException
    {
        public InvalidStartDateException(string exception) : base(exception)
        {
        }
    }
}
