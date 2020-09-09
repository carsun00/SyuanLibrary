using CryptoConsloe.Controller;
using System;

namespace CryptoConsloe
{
    class Program
    {
        static void Main(string[] args)
        {
            AesDisplay();
            Console.ReadKey();
        }

        #region AES
        /// <summary>
        ///     Aes的加解密演示
        /// </summary>
        private static void AesDisplay()
        {
            AesController aes = new AesController();
            aes.Display();
        }
        #endregion
    }
}
