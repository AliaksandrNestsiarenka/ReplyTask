namespace ReplyTask.Infrastructure
{
    public class RandomStringGenerator
    {
        private static Random random = new Random();

        public static string GenerateRandomAlphabeticalString(int length = 7)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
