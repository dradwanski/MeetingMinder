﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.WeeklyReservation
{
    internal class InvalidAddReservationException : DomainException
    {
        public InvalidAddReservationException(string exception) : base(exception)
        {
        }
    }
}
