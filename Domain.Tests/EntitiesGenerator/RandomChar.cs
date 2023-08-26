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
