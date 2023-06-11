using Domain.Exceptions.WeeklyReservation;
using Domain.ValueObjects.Role;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WeeklyReservations
    {
        public int Id { get; init; }
        
        private DateTime firstDayOfWeek;


        private List<Reservation> reservations = new List<Reservation>();
        public IReadOnlyCollection<Reservation> Reservations => reservations.AsReadOnly();

        private WeeklyReservations()
        {
            
        }

        public WeeklyReservations(DateTime date)
        {
            SetMonday(date);
        }

        public void CancelReservation(Reservation reservation)
        {
            var reservationToCancel = reservations.FirstOrDefault(x => x.Id == reservation.Id); 

            if (reservationToCancel != null)
            {
                reservations.Remove(reservationToCancel);
            }

        }

        public void SetMonday(DateTime date)
        {

            firstDayOfWeek = date.AddDays(-(int) date.DayOfWeek);

        }

        public void AddReservation(User user, Reservation reservation)
        {

            var weeklyReservation = reservations.Count(x => x.ReservedUser.UserId == user.UserId);

            var limit = GetReservationLimit(user);

            if(weeklyReservation > limit) 
            {
                throw new InvalidAddReservationException("Cannot make reservation");
            }
            reservations.Add(reservation);
        }

       
        private int GetReservationLimit(User user)
        {
            var role = user.Role.Name;
            
            switch (role)
            {
                case ValueObjects.Role.RoleName.Boss:
                    return int.MaxValue;
                case ValueObjects.Role.RoleName.Manager:
                    return 3;
                case ValueObjects.Role.RoleName.User:
                    return 1;
                default:
                    return 0; 
            }
        }


    }
}
