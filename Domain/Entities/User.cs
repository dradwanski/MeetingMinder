using Domain.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get;  set; }
        public FirstName FirstName { get;  set; }
        public LastName LastName { get;  set; }
        public Role Role { get;  set; }
        public Password Password { get;  set; }
        public Email Email { get;  set; }
        

        private User()
        {
            
        }

        public User(string firstName, string lastName, Role role, string password, string email)
        {
            FirstName = new FirstName(firstName);
            LastName = new LastName(lastName);
            Role = role;
            Password = new Password(password);
            Email = new Email(email);
        }


        public void SetNewFirstName(string firstName)
        {
            FirstName = new FirstName(firstName);
        }
        public void SetNewLastName(string lastname)
        {
            LastName = new LastName(lastname);
        }
        public void SetNewRole(Role role)
        {
            Role = role;
        }
        public void SetNewPassword(string password)
        {
            Password = new Password(password);
        }
        public void SetNewEmail(string email)
        {
            Email = new Email(email);
        }

    }
}
