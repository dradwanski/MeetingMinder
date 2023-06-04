using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.User
{
    internal class LoginNullException : DomainException
    {
        public LoginNullException(string exception) : base(exception)
        {
        }
    }
}
