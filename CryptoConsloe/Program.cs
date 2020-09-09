using CryptoConsloe.Controller;
using System;

namespace CryptoConsloe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aes Display");
            AesDisplay();
            
            Console.WriteLine("\nDes Display");
            DesDisplay();

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
        
        #region DES
        /// <summary>
        ///     Aes的加解密演示
        /// </summary>
        private static void DesDisplay()
        {
            DesController des = new DesController();
            des.Display();
        }
        #endregion
    }
}
