using System.Security.Cryptography;

/// <summary>
///     指定編碼格式介面
/// </summary>
namespace PropotypeCrypto.Interface
{
    public interface ISymmetricAlgorithm
    {
        #region Key
        public void SetKey(string key);
        public byte[] GetKey();
        #endregion

        #region IV
        public void SetIV(string iv);
        public byte[] GetIV();
        #endregion

        #region CipherMode
        public void SetMode(CipherMode mode);
        public CipherMode GetMode();
        #endregion

        #region PaddingMode
        public void SetPadding(PaddingMode padding);
        public PaddingMode GetPadding();
        #endregion
    }
}
