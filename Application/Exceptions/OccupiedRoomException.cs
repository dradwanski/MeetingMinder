namespace Application.Exceptions
{
    public class OccupiedRoomException : AppException
    {
        public OccupiedRoomException(string exception) : base(exception)
        {
        }
    }
}
