using Domain.ValueObjects.InvitedUser;

namespace Domain.Entities
{
    public class InvitedUser
    {

        
        public User User { get; init; }
        public InvitedUserStatus UserStatus { get; private set; }

        private InvitedUser() { }

        public InvitedUser(User user)
        {
            User = user;
            UserStatus = InvitedUserStatus.Invited;
        }

        public void Accept()
        {
            UserStatus = InvitedUserStatus.Accepted;
        }

        public void Cancel()
        {
            UserStatus = InvitedUserStatus.Canceled;
        }

        public void Reject()
        {
            UserStatus = InvitedUserStatus.Rejected;
        }

        

    }
}
