namespace Domain.Exceptions.Reservation
{
    public class InvalidEndDateException : DomainException
    {
        public InvalidEndDateException(string exception) : base(exception)
        {
        }
    }
}
