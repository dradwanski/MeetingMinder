using Domain.Entities;
using Domain.EntitiesGenerator;
using Domain.ValueObjects.Role;
using Domain.ValueObjects.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests.EntitiesGenerator
{
    public class ReservationGenerator
    {
        private static UserGenerator userGenerator = new UserGenerator();

        public Reservation GenerateReservation(RoleName userRoleName, DateTime startDate, DateTime endDate)
        {
            string roomName = Faker.Lorem.GetFirstWord();
            Room room = new Room(roomName);

            User user = userGenerator.GenerateUser(userRoleName);

            Reservation reservation = new Reservation(room, user, startDate, endDate);


            return reservation;


        }
    }
}
