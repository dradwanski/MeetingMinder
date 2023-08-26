using Domain.Entities;
using Domain.EntitiesGenerator;
using Domain.ValueObjects.InvitedUser;
using Domain.ValueObjects.Role;

namespace Domain.Tests
{
    public class InvitedUserTest
    {
        private static UserGenerator userGenerator = new UserGenerator();

        [Fact]
        public void Invite_InviteNewUser_UserStatusInvited()
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);


            //act

            var invitedUser = new InvitedUser(user);

            //assert

            Assert.Equal(InvitedUserStatus.Invited, invitedUser.UserStatus);
        }


        [Fact]
        public void Accept_UserStatusAccepted()
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);
            var invitedUser = new InvitedUser(user);

            //act

            invitedUser.Accept();

            //assert

            Assert.Equal(InvitedUserStatus.Accepted, invitedUser.UserStatus);
        }

        [Fact]
        public void Reject_UserStatusRejected()
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);
            var invitedUser = new InvitedUser(user);


            //act

            invitedUser.Reject();

            //assert

            Assert.Equal(InvitedUserStatus.Rejected, invitedUser.UserStatus);
        }

        [Fact]
        public void Cancel_UserStatusCanceled()
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);
            var invitedUser = new InvitedUser(user);


            //act

            invitedUser.Cancel();

            //assert

            Assert.Equal(InvitedUserStatus.Canceled, invitedUser.UserStatus);
        }
    }
}
