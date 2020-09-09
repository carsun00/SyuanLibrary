using Crypto.Controller.Crypto;
using Crypto.Model.Crypto;
using System;
using System.Security.Cryptography;

namespace CryptoConsloe.Controller
{
    /// <summary>
    ///     Aes實作
    /// </summary>
    public class AesController
    {
        #region 金匙
        /// <summary>
        ///     如要彈性修改，請將此設定放到Config等檔案內。
        /// </summary>
        readonly string sourceIV = "123456qweasdzxcq";
        readonly string AseKey = "123456789qweasdzxc987654cxzdsaew";
        #endregion

        #region 展示
        /// <summary>
        ///     展示如何實作。
        /// </summary>
        public void Display()
        {
            //  inital Aes
            AesCrypto aesCrypto = GenerateAesCrypto();

            //  Crypto Msg
            string OriginalMsg = "This is test message. 這是測試訊息.";
            Console.WriteLine("將要被加密的訊息：{" + OriginalMsg + "}");
            
            //  Encrypto
            string enCrypto = aesCrypto.EnCrypto(OriginalMsg);
            Console.WriteLine("\n加密後的訊息：{" + enCrypto + "}");

            //  Decrypto
            string deCrypto = aesCrypto.DeCrypto(enCrypto);
            Console.WriteLine("\n解密後的訊息：{" + deCrypto + "}");
        }
        #endregion

        #region 初始化
        /// <summary>
        ///     inital AesCrypto.
        ///     初始化
        /// </summary>
        /// <returns>AesCrypto</returns>
        private AesCrypto GenerateAesCrypto()
        {
            //  設定加密演算法。
            AesCrypto aesCrypto = new AesCrypto();
            AesAlgorithm aesAlgorithm = SetAlgorithm();
            aesCrypto.GenerateCrypto(aesAlgorithm);
            return aesCrypto;
        }
        #endregion

        #region 設定加密演算法
        /// <summary>
        ///     setting algorithm
        ///     設定加密演算法
        /// </summary>
        /// <returns>AesAlgorithm</returns>
        private AesAlgorithm SetAlgorithm()
        {
            //  因為加密模式可能不相同，所以選擇在實體化的時候設定演算法。
            AesAlgorithm aesAlgorithm = new AesAlgorithm();
            aesAlgorithm.SetKey(AseKey);
            aesAlgorithm.SetIV(sourceIV);
            aesAlgorithm.SetMode(CipherMode.CBC);
            aesAlgorithm.SetPadding(PaddingMode.PKCS7);
            return aesAlgorithm;
        }
        #endregion

    }
}
