using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.User
{
    internal class FirstNameNullException : DomainException
    {
        public FirstNameNullException(string exception) : base(exception)
        {
        }
    }
}
