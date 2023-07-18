using MlkPwgen;

namespace Exam.Utility
{
    public static class RandomTextGenerator
    {
        public static string Generate(int num = 1)
        {
            return PasswordGenerator.Generate(length: num, allowed: Sets.Alphanumerics);
        }

        //Fix similar cases in other places.
        //I do not know how appropriate this code is, but I think it's better to delete the unused code.
        //Or add a comment on why this code was written and when it will be used in the future.
        /*
        public static int GenerateNum(int min = 0, int max = 100)
        {
            System.Random rand = new System.Random();
            return rand.Next(min, max);
        }

        public static int GenerateNumSpecified(int num = 1)
        {
            return int.Parse(PasswordGenerator.Generate(length: num, allowed: Sets.Digits));
        }*/
    }
}