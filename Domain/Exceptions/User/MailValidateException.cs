using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.User
{
    public class MailValidateException : DomainException
    {
        public MailValidateException(string exception) : base(exception)
        {
        }
    }
}
