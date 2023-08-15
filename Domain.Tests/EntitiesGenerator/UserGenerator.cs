using AutoBogus;
using Bogus;
using Domain.Entities;
using Domain.Tests.EntitiesGenerator;
using Domain.ValueObjects.Role;
using Domain.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesGenerator
{
    public class UserGenerator
    {
        public User GenerateUser(RoleName role)
        {
            var randomChar = new RandomChar();

            var userFirstName = Faker.Name.First();
            var userLastName = Faker.Name.Last();
            var userPassword = (userFirstName + userLastName + Random.Shared.Next(0, 100) + randomChar.GetRandomChar());
            var userEmail = Faker.Internet.Email();


            User user = new User(userFirstName, userLastName, new Role(role), userPassword, userEmail);

            return user;
        }
    }
}
