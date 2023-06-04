namespace Domain.Entities
{
    public class Role
    {
        public int RoleId { get; private set; }
        public string Name { get; private set; }

        private Role()
        {
            
        }
    }
}