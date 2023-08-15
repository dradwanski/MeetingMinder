using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests.EntitiesGenerator
{
    public class RandomChar
    {
        public char GetRandomChar()
        {
            char[] specialChars = { '-', '*', '&', '^', '%', '^', '$', '!', '?', '#' };
            var randomIndex = Random.Shared.Next(0, specialChars.Length);
            return specialChars[randomIndex];
        }
    }
}
