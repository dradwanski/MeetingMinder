using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Room
{
    internal class RoomNameNullException : DomainException
    {
        public RoomNameNullException(string exception) : base(exception)
        {
        }
    }
}
