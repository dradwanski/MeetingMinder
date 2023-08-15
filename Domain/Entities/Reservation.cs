using Domain.Exceptions.Reservation;

namespace Domain.Entities
{
    public class Reservation
    {
        public int Id { get; private set; }
        public Room ReservedRoom { get; private set; }
        public User ReservedUser { get; private set; }
        public DateTime StartReservationDate { get; private set; }
        public DateTime EndReservationDate { get; private set; }

        private List<InvitedUser> invitedUsers = new List<InvitedUser>();
        public IReadOnlyCollection<InvitedUser> InvitedUsers => invitedUsers.AsReadOnly();

        private Reservation()
        {
            
        }

        public Reservation(Room reservedRoom, User reservedUser, DateTime startReservationDate, DateTime endReservationDate)
        {
            ReservedRoom = reservedRoom;
            ReservedUser = reservedUser;
            StartReservationDate = startReservationDate;
            EndReservationDate = endReservationDate;
        }

        public void ChangeRoom(Room room)
        {
            ReservedRoom = room;
        }

        public void ChangeUser(User user)
        {
            ReservedUser = user;
        }

        public void ChangeStartDate(DateTime startDate)
        {
            if(startDate > EndReservationDate)
            {
                throw new InvalidStartDateException("Reservation start date cannot be heigher than reservation end date");
            }
            StartReservationDate = startDate;
        }

        public void ChangeEndDate(DateTime endDate)
        {
            if (endDate < StartReservationDate)
            {
                throw new InvalidEndDateException("Reservation end date cannot be lower than reservation start date");
            }
            EndReservationDate = endDate;
        }

        public void Invite(User user)
        {

            InvitedUser invitedUser = new InvitedUser(user);

            if (ReservedUser.Role.Name == ValueObjects.Role.RoleName.Boss)
            {
                invitedUser.Accept();
            }


            invitedUsers.Add(invitedUser);
            
        }

        public void Invite(List<User> users)
        {

            foreach (var item in users)
            {
                Invite(item);
            }
            
        }

        public void CancelInvite(User user)
        {
            var invitedUser = invitedUsers.FirstOrDefault(x => x.User.UserId == user.UserId);

            if(invitedUser != null)
            {
                invitedUser.Cancel();
            }
         
        }
        

    }
}
