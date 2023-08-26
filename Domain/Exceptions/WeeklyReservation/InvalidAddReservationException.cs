namespace Domain.Exceptions.WeeklyReservation
{
    public class InvalidAddReservationException : DomainException
    {
        public InvalidAddReservationException(string exception) : base(exception)
        {

        }
    }
}
