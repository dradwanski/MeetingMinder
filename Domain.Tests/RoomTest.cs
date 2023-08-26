using Domain.Entities;

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

            Assert.Equal("Jobs", room.Name.Value);


        }
    }
}
