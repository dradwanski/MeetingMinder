﻿using Domain.ValueObjects.Role;

namespace Domain.Entities
{
    public class Role
    {
        public int RoleId { get; private set; }
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