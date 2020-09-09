using Crypto.Abstract.Crypto;
using Crypto.Interface;
using System.Security.Cryptography;

namespace Crypto.Controller.Crypto
{
    public class DesCrypto : AbstractCrypto
    {

        #region 初始化加密物件
        /// <summary>
        ///     初始化加密物件。
        /// </summary>
        /// <param name="CryptoParamater">0</param>
        /// <returns></returns>
        public override SymmetricAlgorithm GenerateCrypto(ISymmetricAlgorithm CryptoParamater)
        {
            Crypto = new DESCryptoServiceProvider
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
