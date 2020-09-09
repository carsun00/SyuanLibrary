using Crypto.Controller.Crypto;
using Crypto.Model.Crypto;
using System;
using System.Security.Cryptography;

namespace CryptoConsloe.Controller
{
    public class TripleDescController
    {

        #region 金匙
        /// <summary>
        ///     如要彈性修改，請將此設定放到Config等檔案內。
        /// </summary>
        readonly string sourceIV = "12345678";
        readonly string TripleDesKey = "1234567AAAAAA";
        #endregion

        #region 展示
        /// <summary>
        ///     展示如何實作。
        /// </summary>
        public void Display()
        {
            //  inital Aes
            TripleDescCrypto tripleDescCrypto = GenerateAesCrypto();

            //  Crypto Msg
            string OriginalMsg = "This is test message. 這是測試訊息.";
            Console.WriteLine("將要被加密的訊息：{" + OriginalMsg + "}");

            //  Encrypto
            string enCrypto = tripleDescCrypto.EnCrypto(OriginalMsg);
            Console.WriteLine("\n加密後的訊息：{" + enCrypto + "}");

            //  Decrypto
            string deCrypto = tripleDescCrypto.DeCrypto(enCrypto);
            Console.WriteLine("解密後的訊息：{" + deCrypto + "}");
        }
        #endregion

        #region 初始化
        /// <summary>
        ///     inital AesCrypto.
        ///     初始化
        /// </summary>
        /// <returns>AesCrypto</returns>
        private TripleDescCrypto GenerateAesCrypto()
        {
            //  設定加密演算法。
            TripleDescCrypto tripleDescCrypto = new TripleDescCrypto();
            TripleDescAlgorithm desAlgorithm = SetAlgorithm();
            tripleDescCrypto.GenerateCrypto(desAlgorithm);
            return tripleDescCrypto;
        }
        #endregion

        #region 設定加密演算法
        /// <summary>
        ///     setting algorithm
        ///     設定加密演算法
        /// </summary>
        /// <returns>AesAlgorithm</returns>
        private TripleDescAlgorithm SetAlgorithm()
        {
            //  因為加密模式可能不相同，所以選擇在實體化的時候設定演算法。
            TripleDescAlgorithm desAlgorithm = new TripleDescAlgorithm();
            desAlgorithm.SetKey(TripleDesKey);
            desAlgorithm.SetIV(sourceIV);
            desAlgorithm.SetMode(CipherMode.CBC);
            desAlgorithm.SetPadding(PaddingMode.PKCS7);
            return desAlgorithm;
        }
        #endregion
    }
}
