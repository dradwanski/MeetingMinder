using Domain.Entities;
using Domain.ValueObjects.Role;
using Domain.ValueObjects.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{
    public class RoomTest
    {
        [Fact]
        public void ChangeRoom_RoomChanged()
        {

            //arrange
            var room = new Room("Picasso");

            //act

            room.SetNewName("Jobs");

            //assert

            Assert.Equal("Jobs", room.Name.Name);


        }
    }
}
