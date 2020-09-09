using Crypto.Abstract.Crypto;
using System.Text;

namespace Crypto.Model.Crypto
{
    /// <summary>
    ///     會因各自程式不同需求，有不同的位元編碼方式
    /// </summary>
    public class AesAlgorithm : AbstractSymmetricAlgorithm
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
        #endregion

    }
}
