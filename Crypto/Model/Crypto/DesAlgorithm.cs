using PropotypeCrypto.Abstract.Crypto;
using System.Text;

namespace PropotypeCrypto.Model.Crypto
{
    public class DesAlgorithm : AbstractSymmetricAlgorithm
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
