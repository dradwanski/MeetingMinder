using Domain.Exceptions.WeeklyReservation;
using Domain.Services;

namespace Domain.Entities
{
    public class WeeklyReservation
    {
        public int Id { get; init; }

        private DateTime _firstDayOfWeek;

        private readonly List<Reservation> _reservations = new List<Reservation>();
        public IReadOnlyCollection<Reservation> Reservations => _reservations.AsReadOnly();

        private WeeklyReservation()
        {

        }

        public WeeklyReservation(DateTime date)
        {
            SetMonday(date);
        }

        private void SetMonday(DateTime date)
        {

            _firstDayOfWeek = date.AddDays(-(int)date.DayOfWeek);

        }


        public void CancelReservation(Reservation reservation)
        {
            var reservationToCancel = _reservations.FirstOrDefault(x => x.ReservationId == reservation.ReservationId);

            if (reservationToCancel != null)
            {
                _reservations.Remove(reservationToCancel);
            }

        }


        public void AddReservation(Reservation reservation, ILimitReservationsForUser limitReservationsForUser)
        {
            if (reservation.StartReservationDate > _firstDayOfWeek.AddDays(7))
            {
                throw new InvalidAddReservationException("Invalid reservation week");
            }

            var weeklyReservation = _reservations.Count(x => x.ReservedUser.UserId == reservation.ReservedUser.UserId);

            var limit = limitReservationsForUser.GetReservationLimit(reservation.ReservedUser);

            if (weeklyReservation >= limit)
            {
                throw new InvalidAddReservationException("The user limit for making reservations has been reached");
            }
            _reservations.Add(reservation);
        }


    }
}
