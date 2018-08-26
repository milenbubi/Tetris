using System;
using System.Security.Cryptography;

namespace Tetris.Logic.Game.BaseLogic.Providers
{
    internal static class RandomNumber
    {
        private static RandomNumberGenerator provider;
        private static byte[] byteArray;

        static RandomNumber()
        {
            provider = RNGCryptoServiceProvider.Create();
            byteArray = new byte[2];
        }

        internal static int InRangeZeroTo(int maxNumber)
        {
            provider.GetBytes(byteArray);
            int randomNumber = BitConverter.ToUInt16(byteArray, 0) % maxNumber;

            return randomNumber;
        }

        //TODO  A new method with two parameters  :  from - to
    }
}
