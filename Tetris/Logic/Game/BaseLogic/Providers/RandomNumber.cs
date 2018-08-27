using System.Security.Cryptography;

namespace Tetris.Logic.Game.BaseLogic.Providers
{
    internal static class RandomNumber
    {
        private static RandomNumberGenerator provider;
        private static byte[] byteArray;

        static RandomNumber()
        {
            provider = RandomNumberGenerator.Create();
            byteArray = new byte[1];
        }

        internal static int ZeroBasedRange(int maxNumber)
        {
            provider.GetBytes(byteArray);
            return byteArray[0] % maxNumber;
        }

        internal static int InRange(int min, int max)
        {
            return ZeroBasedRange(max - min + 1) + min;
        }
    }
}
