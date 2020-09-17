using PropotypeCrypto.Abstract.Crypto;
using PropotypeCrypto.Interface;
using System.Security.Cryptography;

namespace PropotypeCrypto.Controller.Crypto
{
    public class TripleDescCrypto : AbstractCrypto
    {

        #region 初始化加密物件
        /// <summary>
        ///     初始化加密物件。
        /// </summary>
        /// <param name="CryptoParamater">0</param>
        /// <returns></returns>
        public override SymmetricAlgorithm GenerateCrypto(ISymmetricAlgorithm CryptoParamater)
        {
            Crypto = new TripleDESCryptoServiceProvider
            {
                Key = CryptoParamater.GetKey(),
                IV = CryptoParamater.GetIV(),
                Mode = CryptoParamater.GetMode(),
                Padding = CryptoParamater.GetPadding()
            };
            return Crypto;
        }
        #endregion

    }
}
