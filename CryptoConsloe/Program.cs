﻿using PropotypeCryptoConsloe.Controller;
using System;

namespace PropotypeCryptoConsloe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aes Display");
            AesDisplay();

            Console.WriteLine("\nDes Display");
            DesDisplay();

            Console.WriteLine("\nTripleDesc Display");
            TripleDescDisplay();
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

        #region TripleDesc
        /// <summary>
        ///     Aes的加解密演示
        /// </summary>
        private static void TripleDescDisplay()
        {
            TripleDescController TripleDesc = new TripleDescController();
            TripleDesc.Display();
        }
        #endregion
    }
}
