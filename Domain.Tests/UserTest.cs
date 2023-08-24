using Domain.Entities;
using Domain.ValueObjects.Role;
using Domain.Exceptions.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EntitiesGenerator;

namespace Domain.Tests
{
    public class UserTest
    {
        private static UserGenerator userGenerator = new UserGenerator();

        [Fact]
        public void setNewFirstName_SetName_NameChanged()
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);

            //act

            user.SetNewFirstName("Karol");

            //assert


            Assert.Equal("Karol", user.FirstName.Value);



        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("             ")]
        [InlineData(null)]
        [InlineData("...")]
        [InlineData("123")]
        public void setNewFirstName_TryToSetNotValidOptionToFirstName_FirstNameException(string firstname)
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);

            //act

            var action = () => user.SetNewFirstName(firstname);

            //assert


            Assert.Throws<FirstNameException>(action);

        }

        [Fact]
        public void setNewLastName_SetLastName_LastNameChanged()
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);

            //act

            user.SetNewLastName("Elegancki");

            //assert


            Assert.Equal("Elegancki", user.LastName.Value);



        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("             ")]
        [InlineData(null)]
        public void setNewLastName_TryToSetNotValidOptionToLastName_LastNameException(string lastname)
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);

            //act

            var action = () => user.SetNewLastName(lastname);

            //assert


            Assert.Throws<LastNameException>(action);

        }


        [Theory]
        [InlineData(RoleName.Boss, RoleName.Manager)]
        [InlineData(RoleName.Boss, RoleName.User)]
        [InlineData(RoleName.Manager, RoleName.Boss)]
        [InlineData(RoleName.Manager, RoleName.User)]
        [InlineData(RoleName.User, RoleName.Boss)]
        [InlineData(RoleName.User, RoleName.Manager)]
        public void setNewRole_SetRolesForAllRoleNames_RolesChanged(RoleName role, RoleName newRole)
        {

            //arrange

            User user = userGenerator.GenerateUser(role);

            //act

            user.SetNewRole(newRole);

            //assert


            Assert.Equal(newRole, user.Role.Name);



        }

        [Fact]
        public void SetNewPassword_SetValidPassword_PasswordChanged()
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);

            //act

            user.SetNewPassword("Passwd123!@#");

            //assert


            Assert.Equal("Passwd123!@#", user.Password.Value);



        }

        [Theory]
        [InlineData("Password")]
        [InlineData("Password!@#$")]
        [InlineData("12345677xd")]
        [InlineData("Pass1!")]
        [InlineData("@#$#$%^12323!")]
        [InlineData(null)]
        public void SetNewPassword_SetNotValidPassword_PasswordValidateException(string password)
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);

            //act

            var action = () => user.SetNewPassword(password);

            //assert


            Assert.Throws<PasswordValidateException>(action);

        }


        [Fact]
        public void SetNewEmail_SetValidEmail_EmailChanged()
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);

            //act

            user.SetNewEmail("mail@mail.pl");

            //assert


            Assert.Equal("mail@mail.pl", user.Email.Value);



        }

        [Theory]
        [InlineData("mail")]
        [InlineData("Value@")]
        [InlineData(" ")]
        [InlineData(null)]
        public void SetNewEmail_SetNotValidEmail_MailValidateException(string email)
        {

            //arrange
            User user = userGenerator.GenerateUser(RoleName.User);

            //act

            var action = () => user.SetNewEmail(email);

            //assert


            Assert.Throws<MailValidateException>(action);

        }
    }
}
