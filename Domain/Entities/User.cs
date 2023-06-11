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
        public int UserId { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Role Role { get; private set; }
        public Login Login { get; private set; }
        public Password Password { get; private set; }
        public Email Email { get; private set; }
        

        private User()
        {
            
        }

        public User(string firstName, string lastName, Role role, string login, string password, string email)
        {
            FirstName = new FirstName(firstName);
            LastName = new LastName(lastName);
            Role = role;
            Login = new Login(login);
            Password = new Password(password);
            Email = new Email(email);
        }


        public void SetFirstName(string firstName)
        {
            FirstName = new FirstName(firstName);
        }
        public void SetLastName(string lastname)
        {
            LastName = new LastName(lastname);
        }
        public void SetRole(Role role)
        {
            Role = role;
        }
        public void SetLogin(string login)
        {
            Login = new Login(login);
        }
        public void SetPassword(string password)
        {
            Password = new Password(password);
        }
        public void SetEmail(string email)
        {
            Email = new Email(email);
        }

    }
}
