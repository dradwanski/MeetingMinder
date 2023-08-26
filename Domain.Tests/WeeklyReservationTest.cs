using Domain.Entities;
using Domain.EntitiesGenerator;
using Domain.Exceptions.WeeklyReservation;
using Domain.Services;
using Domain.Tests.EntitiesGenerator;
using Domain.ValueObjects.Role;
using NSubstitute;

namespace Domain.Tests
{
    public class WeeklyReservationTest
    {
        private static UserGenerator userGenerator = new UserGenerator();
        private static ReservationGenerator reservationGenerator = new ReservationGenerator();

        DateTime startDate = new DateTime(2023, 07, 20, 21, 00, 00);
        DateTime endDate = new DateTime(2023, 07, 20, 21, 30, 00);

        DateTime secondStartDate = new DateTime(2023, 07, 26, 21, 00, 00);
        DateTime secondEndDate = new DateTime(2023, 07, 26, 21, 30, 00);

        private readonly ILimitReservationsForUser limitReservationsForUser = Substitute.For<ILimitReservationsForUser>();

        public WeeklyReservationTest()
        {
            limitReservationsForUser.GetReservationLimit(Arg.Any<User>()).Returns(1);
        }

        [Fact]
        public void AddReservation_AddReservation_ReservationAdded()
        {

            //arrange
            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.Boss, startDate, endDate);
            WeeklyReservation weeklyReservations = new WeeklyReservation(new DateTime(2023, 07, 20, 19, 00, 00));

            //act

            weeklyReservations.AddReservation(reservation, limitReservationsForUser);

            //assert

            var argument = weeklyReservations.Reservations.FirstOrDefault(x => x.ReservationId == reservation.ReservationId);

            Assert.NotNull(argument);

        }

        [Fact]
        public void AddReservation_UserAddSecondReservationInOneWeek_InvalidAddReservationException()
        {

            //arrange

            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.User, startDate, endDate);
            WeeklyReservation weeklyReservations = new WeeklyReservation(new DateTime(2023, 07, 20, 19, 00, 00));
            weeklyReservations.AddReservation(reservation, limitReservationsForUser);

            Reservation secondReservation = reservationGenerator.GenerateReservation(RoleName.User, secondStartDate, secondEndDate);

            //act

            var action = () => weeklyReservations.AddReservation(secondReservation, limitReservationsForUser);

            //assert

            Assert.Throws<InvalidAddReservationException>(action);

        }


        [Fact]
        public void AddReservation_UserAddReservationInNextWeek_InvalidAddReservationException()
        {

            //arrange

            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.User, startDate, endDate);
            WeeklyReservation weeklyReservations = new WeeklyReservation(new DateTime(2023, 07, 20, 19, 00, 00));
            weeklyReservations.AddReservation(reservation, limitReservationsForUser);

            Reservation secondReservation = reservationGenerator.GenerateReservation(RoleName.User, secondStartDate, secondEndDate);


            //act

            var action = () => weeklyReservations.AddReservation(secondReservation, limitReservationsForUser);

            //assert

            Assert.Throws<InvalidAddReservationException>(action);

        }


        [Fact]
        public void CancelReservation_CancelReservation_ReservationCanceled()
        {

            //arrange
            Reservation reservation = reservationGenerator.GenerateReservation(RoleName.Boss, startDate, endDate);

            WeeklyReservation weeklyReservations = new WeeklyReservation(new DateTime(2023, 07, 20, 19, 00, 00));

            //act

            weeklyReservations.CancelReservation(reservation);

            //assert

            var argument = weeklyReservations.Reservations.FirstOrDefault(x => x.ReservationId == reservation.ReservationId);

            Assert.Null(argument);

        }

    }

}
