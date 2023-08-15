﻿using Domain.Exceptions.WeeklyReservation;
using Domain.Services;
using Domain.ValueObjects.Role;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void CancelReservation(Reservation reservation)
        {
            var reservationToCancel = reservations.FirstOrDefault(x => x.Id == reservation.Id); 

            if (reservationToCancel != null)
            {
                reservations.Remove(reservationToCancel);
            }

        }

        private void SetMonday(DateTime date)
        {

            firstDayOfWeek = date.AddDays(-(int) date.DayOfWeek);

        }

        public void AddReservation(Reservation reservation, ILimitReservationsForUser limitReservationsForUser)
        {
            if(reservation.StartReservationDate > firstDayOfWeek.AddDays(7))
            {
                throw new InvalidAddReservationException("Invalid reservation week");
            }

            var weeklyReservation = reservations.Count(x => x.ReservedUser.UserId == reservation.ReservedUser.UserId);

            var limit = limitReservationsForUser.GetReservationLimit(reservation.ReservedUser);

            if(weeklyReservation >= limit) 
            {
                throw new InvalidAddReservationException("The user limit for making reservations has been reached");
            }
            reservations.Add(reservation);
        }

       /*
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
        */

    }
}