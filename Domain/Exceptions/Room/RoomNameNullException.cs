namespace Domain.Exceptions.Room
{
    internal class RoomNameNullException : DomainException
    {
        public RoomNameNullException(string exception) : base(exception)
        {
        }
    }
}
