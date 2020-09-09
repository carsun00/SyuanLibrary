using Crypto.Abstract.Crypto;
using System.Security.Cryptography;
using System.Text;

namespace Crypto.Model.Crypto
{
    public class TripleDescAlgorithm : AbstractSymmetricAlgorithm
    {
        #region 覆寫的方法
        /// <summary>
        ///     自定義的Encoding格式
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override byte[] EncodingFormat(string key)
        {
            return Encoding.UTF8.GetBytes(key);
        }

        /// <summary>
        ///     TripleDesc 的Key需要特別編碼。
        /// </summary>
        /// <param name="key"></param>
        public override void SetKey(string key)
        {

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyBytes = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            Key = keyBytes;
        }
        #endregion

    }
}
