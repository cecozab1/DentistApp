namespace DentistApp.Data.Common
{
    using System;
    using System.Text;

    public static class RandomGenerator
    {
        private static Random random = new Random();
        private static string Numbers = "1234567890";
        private static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUWXYZabcdefghijklmnopqrstuwxyz";
        private static string AlphabetWithSpaces = "  ABCDEFGHIJKLMNOPQRSTUWXYZ  abcdefghijklmnopqrstuwxyz  ";

        public static string RandomStringWithoutSpaces(int minLength, int maxLength)
        {
            StringBuilder result = new StringBuilder();
            var length = RandomNumber(minLength, maxLength);

            for (int i = 0; i < length; i++)
            {
                result.Append(Alphabet[RandomNumber(0, Alphabet.Length - 1)]);
            }

            return result.ToString();
        }

        public static string RandomStringWithSpaces(int minLength, int maxLength)
        {
            StringBuilder result = new StringBuilder();
            var length = RandomNumber(minLength, maxLength);

            for (int i = 0; i < length; i++)
            {
                result.Append(AlphabetWithSpaces[RandomNumber(0, AlphabetWithSpaces.Length - 1)]);
            }

            return result.ToString();
        }

        public static string RandomStringWithNumbers(int minLength, int maxLength)
        {
            StringBuilder result = new StringBuilder();
            var length = RandomNumber(minLength, maxLength);

            for (int i = 0; i < length; i++)
            {
                result.Append(Numbers[RandomNumber(0, Numbers.Length - 1)]);
            }

            return result.ToString();
        }

        public static int RandomNumber(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue + 1);
        }
    }
}
