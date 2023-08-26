using Domain.ValueObjects.Role;

namespace Domain.Entities
{
    public class Role
    {
        public RoleName Name { get; private set; }

        public Role(RoleName name)
        {
            Name = name;
        }
        private Role()
        {

        }

    }
}