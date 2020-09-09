using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Crypto.Abstract.Crypto
{
    /// <summary>
    ///     金匙設定集中控管
    /// </summary>
    public abstract class AbstractSymmetricAlgorithm : IDisposable
    {
        #region 宣告參數

        #region Disposable相關

        /// <summary>
        ///     釋放非受控資源
        /// </summary>
        private bool disposed;

        /// <summary>
        ///     安全控制
        /// </summary>
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        #endregion

        /// <summary>
        ///     加密的金匙
        /// </summary>
        protected internal byte[] Key;

        /// <summary>
        ///     加密偏移量
        /// </summary>
        protected internal byte[] IV;

        /// <summary>
        ///     編碼模式
        /// </summary>
        protected internal CipherMode Mode;

        /// <summary>
        ///     補零模式。
        /// </summary>
        protected internal PaddingMode Padding;

        /// <summary>
        ///     要加解密的訊息
        /// </summary>
        protected string CryptMsg;

        #endregion

        #region 實體方法

        /// <summary>
        ///     設定加密金匙
        /// </summary>
        /// <param name="key"></param>
        public void SetKey(string key)
        {
            Key = EncodingFormat(key);
        }

        /// <summary>
        ///     設定偏移金匙
        /// </summary>
        /// <param name="iv"></param>
        public void SetIV(string iv)
        {
            IV = EncodingFormat(iv);
        }

        /// <summary>
        ///     設定編碼格式
        /// </summary>
        /// <param name="iv"></param>
        public void SetMode(CipherMode mode)
        {
            Mode = mode;
        }

        /// <summary>
        ///     設定偏移金匙
        /// </summary>
        /// <param name="iv"></param>
        public void SetPadding(PaddingMode padding)
        {
            Padding = padding;
        }

        #endregion

        #region 抽象方法

        /// <summary>
        ///     指定自己的編碼格式
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract byte[] EncodingFormat(string key);

        #endregion

        #region Dispose 資源控制

        /// <summary>
        ///     使用完畢後呼叫方法，給予GC控制。
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    handle.Dispose();
                }

                disposed = true;
            }
        }

        /// <summary>
        ///     實際釋放，交由程式控管。
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
