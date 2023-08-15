using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Reservation
{
    public class InvalidStartDateException : DomainException
    {
        public InvalidStartDateException(string exception) : base(exception)
        {
        }
    }
}
