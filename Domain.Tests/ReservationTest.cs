using Domain.Entities;
using Domain.EntitiesGenerator;
using Domain.Exceptions.Reservation;
using Domain.Tests.EntitiesGenerator;
using Domain.ValueObjects.InvitedUser;
using Domain.ValueObjects.Role;

namespace Domain.Tests
{
    public class ReservationTest
    {

        private static UserGenerator userGenerator = new UserGenerator();
        private static ReservationGenerator reservationGenerator = new ReservationGenerator();

        private static DateTime startDate = new DateTime(2023, 07, 20, 21, 00, 00);
        private static DateTime endDate = new DateTime(2023, 07, 20, 21, 30, 00);


        [Fact]
        public void CancelInvite_CancelInviteToUser_InviteCanceled()
        {

            //arrange

            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.User, startDate, endDate);

            User user = userGenerator.GenerateUser(RoleName.User);
            User user2 = userGenerator.GenerateUser(RoleName.User);

            reservation.Invite(user);
            reservation.Invite(user2);

            //act

            reservation.CancelInvite(user);

            //assert

            foreach (var item in reservation.InvitedUsers)
            {
                if (item.User.Email == user.Email)
                {
                    Assert.Equal(InvitedUserStatus.Canceled, item.UserStatus);
                }
                else
                {
                    Assert.Equal(InvitedUserStatus.Invited, item.UserStatus);
                }

            }

        }

        [Fact]
        public void ChangeEndDate_EndDateLowerThanStartDate_ThrowsInvalidEndDateException()
        {

            //arrange

            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.Boss, startDate, endDate);

            //act

            var action = () => reservation.ChangeEndDate(new DateTime(2023, 07, 19, 21, 40, 00));

            //assert


            Assert.Throws<InvalidEndDateException>(action);

        }


        [Fact]
        public void ChangeStartDate_EndDateHigherThanStartDate_EndDateChanged()
        {

            //arrange

            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.Boss, startDate, endDate);

            var newEndDate = new DateTime(2023, 07, 20, 21, 20, 00);

            //act

            reservation.ChangeEndDate(newEndDate);

            //assert


            Assert.Equal(newEndDate, reservation.EndReservationDate);

        }

        [Fact]
        public void ChangeRoom_RoomChanged()
        {

            //arrange

            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.Boss, startDate, endDate);

            Room room2 = new Room("Picasso");

            //act

            reservation.ChangeRoom(room2);

            //assert

            Assert.Equal(room2, reservation.ReservedRoom);

        }

        [Fact]
        public void ChangeStartDate_StartDateHigherThanEndDate_ThrowsInvalidStartDateException()
        {

            //arrange

            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.Boss, startDate, endDate);

            //act

            var action = () => reservation.ChangeStartDate(new DateTime(2023, 07, 22, 21, 40, 00));

            //assert

            Assert.Throws<InvalidStartDateException>(action);

        }

        [Fact]
        public void ChangeStartDate_StartDateLowerThanStartDate_EndDateChanged()
        {

            //arrange

            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.Boss, startDate, endDate);

            var newStartDate = new DateTime(2023, 07, 20, 21, 20, 00);

            //act

            reservation.ChangeStartDate(newStartDate);

            //assert

            Assert.Equal(newStartDate, reservation.StartReservationDate);

        }



        [Fact]
        public void ChangeUser_UserChanged()
        {

            //arrange

            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.Boss, startDate, endDate);

            User user = userGenerator.GenerateUser(RoleName.User);

            //act

            reservation.ChangeUser(user);

            //assert

            Assert.Equal(user, reservation.ReservedUser);

        }




        [Fact]
        public void Invite_AutoAcceptToUserInvitedByBoss_StatusAccept()
        {

            //arrange

            DateTime startDate = new DateTime(2023, 07, 20, 21, 00, 00);
            DateTime endDate = new DateTime(2023, 07, 20, 21, 30, 00);
            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.Boss, startDate, endDate);

            User user = userGenerator.GenerateUser(RoleName.User);
            User manger = userGenerator.GenerateUser(RoleName.Manager);


            //act

            reservation.Invite(user);
            reservation.Invite(manger);

            //assert


            foreach (var item in reservation.InvitedUsers)
            {
                Assert.Equal(InvitedUserStatus.Accepted, item.UserStatus);
            }

        }


        [Fact]
        public void Invite_inviteMoreUsersThanOne_InvitedUsersAddToList()
        {

            //arrange

            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.User, startDate, endDate);

            User boss = userGenerator.GenerateUser(RoleName.Boss);
            User manager = userGenerator.GenerateUser(RoleName.Manager);

            List<User> usersToInvite = new List<User>();
            usersToInvite.Add(boss);
            usersToInvite.Add(manager);


            //act

            reservation.Invite(usersToInvite);

            //assert

            foreach (var item in reservation.InvitedUsers)
            {
                Assert.Equal(InvitedUserStatus.Invited, item.UserStatus);
            }


        }
    }
}
