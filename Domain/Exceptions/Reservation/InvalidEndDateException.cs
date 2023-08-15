using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Reservation
{
    public class InvalidEndDateException : DomainException
    {
        public InvalidEndDateException(string exception) : base(exception)
        {
        }
    }
}
