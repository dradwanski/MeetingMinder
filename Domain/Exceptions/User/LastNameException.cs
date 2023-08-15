using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.User
{
    public class LastNameException : DomainException
    {
        public LastNameException(string exception) : base(exception)
        {
        }
    }
}
