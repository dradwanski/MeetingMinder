namespace Application.Exceptions
{
    public class ReservationNotFoundException : AppException
    {
        public ReservationNotFoundException(string exception) : base(exception)
        {
        }
    }
}
