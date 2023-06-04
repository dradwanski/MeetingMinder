using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.User
{
    internal class LastNameNullException : DomainException
    {
        public LastNameNullException(string exception) : base(exception)
        {
        }
    }
}
