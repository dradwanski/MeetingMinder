namespace Application.Exceptions
{
    public class OccupiedRoomException : ApplicationException
    {
        public OccupiedRoomException(string exception) : base(exception)
        {
        }
    }
}
