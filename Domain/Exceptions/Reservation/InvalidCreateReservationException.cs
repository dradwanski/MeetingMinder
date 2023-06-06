using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Reservation
{
    internal class InvalidCreateReservationException : DomainException
    {
        public InvalidCreateReservationException(string exception) : base(exception)
        {

        }
    }
}
