using Domain.ValueObjects.Role;
using Domain.ValueObjects.User;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Role Role { get; private set; }
        public Password Password { get; private set; }
        public Email Email { get; private set; }

        //TODO: zrobić z tego valuo object (jak rola)
        public bool IsDeleted { get; set; } = false;


        private User()
        {

        }

        public User(string firstName, string lastName, RoleName role, string password, string email)
        {
            FirstName = new FirstName(firstName);
            LastName = new LastName(lastName);
            Role = new Role(role);
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
        public void SetNewRole(RoleName role)
        {
            Role = new Role(role);
        }
        public void SetNewPassword(string password)
        {
            Password = new Password(password);
        }
        public void SetNewEmail(string email)
        {
            Email = new Email(email);
        }

        public void Delete() => IsDeleted = true;

    }
}
