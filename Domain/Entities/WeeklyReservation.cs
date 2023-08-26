using Domain.Exceptions.WeeklyReservation;
using Domain.Services;

namespace Domain.Entities
{
    public class WeeklyReservation
    {
        public int Id { get; init; }

        private DateTime firstDayOfWeek;

        private List<Reservation> reservations = new List<Reservation>();
        public IReadOnlyCollection<Reservation> Reservations => reservations.AsReadOnly();

        private WeeklyReservation()
        {

        }

        public WeeklyReservation(DateTime date)
        {
            SetMonday(date);
        }

        private void SetMonday(DateTime date)
        {

            firstDayOfWeek = date.AddDays(-(int)date.DayOfWeek);

        }


        public void CancelReservation(Reservation reservation)
        {
            var reservationToCancel = reservations.FirstOrDefault(x => x.ReservationId == reservation.ReservationId);

            if (reservationToCancel != null)
            {
                reservations.Remove(reservationToCancel);
            }

        }


        public void AddReservation(Reservation reservation, ILimitReservationsForUser limitReservationsForUser)
        {
            if (reservation.StartReservationDate > firstDayOfWeek.AddDays(7))
            {
                throw new InvalidAddReservationException("Invalid reservation week");
            }

            var weeklyReservation = reservations.Count(x => x.ReservedUser.UserId == reservation.ReservedUser.UserId);

            var limit = limitReservationsForUser.GetReservationLimit(reservation.ReservedUser);

            if (weeklyReservation >= limit)
            {
                throw new InvalidAddReservationException("The user limit for making reservations has been reached");
            }
            reservations.Add(reservation);
        }


    }
}
