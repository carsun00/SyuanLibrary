using PropotypeCrypto.Controller.Crypto;
using PropotypeCrypto.Model.Crypto;
using System;
using System.Security.Cryptography;

namespace PropotypeCryptoConsloe.Controller
{
    public class DesController
    {

        #region 金匙
        /// <summary>
        ///     如要彈性修改，請將此設定放到Config等檔案內。
        /// </summary>
        readonly string sourceIV = "A7654321";
        readonly string DseKey = "1234567A";
        /*   
         *   必須為 8 個 ASCII 字元，超過會被自動切除，
         *    舉例今天使用 [ 0123456789 ] 10碼進行加密，
         *    實際上在演算中只會取出 [ 01234567 ]進行加密，
         *    故PHP、JSP使用DES加密時可以直接加密，
         *    但C#較嚴謹，超過8碼會報錯，所以預防安全可以加入SubString。
         */
        #endregion

        #region 展示
        /// <summary>
        ///     展示如何實作。
        /// </summary>
        public void Display()
        {
            //  inital Aes
            DesCrypto desCrypto = GenerateAesCrypto();

            //  Crypto Msg
            string OriginalMsg = "This is test message. 這是測試訊息.";
            Console.WriteLine("將要被加密的訊息：{" + OriginalMsg + "}");

            //  Encrypto
            string enCrypto = desCrypto.EnCrypto(OriginalMsg);
            Console.WriteLine("\n加密後的訊息：{" + enCrypto + "}");

            //  Decrypto
            string deCrypto = desCrypto.DeCrypto(enCrypto);
            Console.WriteLine("解密後的訊息：{" + deCrypto + "}");
        }
        #endregion

        #region 初始化
        /// <summary>
        ///     inital AesCrypto.
        ///     初始化
        /// </summary>
        /// <returns>AesCrypto</returns>
        private DesCrypto GenerateAesCrypto()
        {
            //  設定加密演算法。
            DesCrypto desCrypto = new DesCrypto();
            DesAlgorithm desAlgorithm = SetAlgorithm();
            desCrypto.GenerateCrypto(desAlgorithm);
            return desCrypto;
        }
        #endregion

        #region 設定加密演算法
        /// <summary>
        ///     setting algorithm
        ///     設定加密演算法
        /// </summary>
        /// <returns>AesAlgorithm</returns>
        private DesAlgorithm SetAlgorithm()
        {
            //  因為加密模式可能不相同，所以選擇在實體化的時候設定演算法。
            DesAlgorithm desAlgorithm = new DesAlgorithm();
            desAlgorithm.SetKey(DseKey);
            desAlgorithm.SetIV(sourceIV);
            desAlgorithm.SetMode(CipherMode.CBC);
            desAlgorithm.SetPadding(PaddingMode.PKCS7);
            return desAlgorithm;
        }
        #endregion

    }
}

