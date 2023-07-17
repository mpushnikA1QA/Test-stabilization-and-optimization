using MlkPwgen;

namespace Exam
{
    public static class RandomTextGenerator
    {
        public static string Generate(int num = 1)
        {
            return PasswordGenerator.Generate(length: num, allowed: Sets.Alphanumerics);
        }

        public static int GenerateNum(int min = 0, int max = 100)
        {
            System.Random rand = new System.Random();
            return rand.Next(min, max);
        }

        public static int GenerateNumSpecified(int num = 1)
        {
            return int.Parse(PasswordGenerator.Generate(length: num, allowed: Sets.Digits));
        }
    }
}