using Crypto.Interface;
using Crypto.Model.Crypto;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Crypto.Abstract.Crypto
{
    /// <summary>
    ///     加密相關請以此方法作衍生。
    /// </summary>
    public abstract class AbstractCrypto : IDisposable
    {
        #region 宣告參數

        #region Disposable相關

        /// <summary>
        ///     釋放非受控資源
        /// </summary>
        private bool disposed = false;

        /// <summary>
        ///     安全控制
        /// </summary>
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        #endregion

        /// <summary>
        ///     加密演算法
        /// </summary>
        public SymmetricAlgorithm Crypto { get; set; }

        #endregion

        #region 抽象方法

        /// <summary>
        ///     初始化加密物件，設定你要的加密類型。
        ///     EX: AesCryptoServiceProvider
        /// </summary>
        /// <param name="CryptoParamater"></param>
        /// <returns></returns>
        public abstract SymmetricAlgorithm GenerateCrypto(ISymmetricAlgorithm CryptoParamater);

        /// <summary>
        ///     加密
        /// </summary>
        /// <param name="Crypto"></param>
        /// <returns>回傳加密後的密文(string)</returns>
        public abstract string EnCrypto(string toEncrypt);

        /// <summary>
        ///     解密
        /// </summary>
        /// <param name="Crypto"></param>
        /// <returns>回傳解密後的明文(string)</returns>
        public abstract string DeCrypto(string toDecrypt);

        #endregion

        #region Dispose 資源控制

        /// <summary>
        ///     使用完畢後呼叫方法，給予GC控制。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     實際釋放，交由程式控管。
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if(disposed) return;
            if(disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }
        #endregion
    }
}
