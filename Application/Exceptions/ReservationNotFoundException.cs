namespace Application.Exceptions
{
    public class ReservationNotFoundException : ApplicationException
    {
        public ReservationNotFoundException(string exception) : base(exception)
        {
        }
    }
}
