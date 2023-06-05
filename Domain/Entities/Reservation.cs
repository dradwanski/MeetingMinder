﻿namespace Domain.Entities
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
            StartReservationDate = startDate;
        }

        public void ChangeEndDate(DateTime endDate)
        {
            EndReservationDate= endDate;
        }

        public void Invite(User user)
        {
            InvitedUser invitedUser = new InvitedUser(user);

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
                invitedUsers.Remove(invitedUser);
            }
            
        }

    }
}