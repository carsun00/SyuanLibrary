using Crypto.Interface;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

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
        #endregion

        #region 可複寫的加解密method
        /// <summary>
        ///     加密
        /// </summary>
        /// <param name="Crypto"></param>
        /// <returns>回傳加密後的密文(string)</returns>
        public virtual string EnCrypto(string toEncrypt)
        {
            try
            {
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
                byte[] resultArray = Crypto.CreateEncryptor().TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        ///     解密
        /// </summary>
        /// <param name="Crypto"></param>
        /// <returns>回傳解密後的明文(string)</returns>
        public virtual string DeCrypto(string toDecrypt)
        {
            try
            {
                ICryptoTransform cTransform = Crypto.CreateDecryptor();
                byte[] enBytes = Convert.FromBase64String(toDecrypt);
                byte[] resultArray = cTransform.TransformFinalBlock(enBytes, 0, enBytes.Length);
                Crypto.Clear();

                return Encoding.UTF8.GetString(resultArray);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                /*
                 *  正常情況下，
                 *  API加密取資料會伴隨著取回後的密文代解密。
                 *  因此在這邊放入Dispose自動釋放資源。
                 */
                if(Crypto != null)
                {
                    Crypto.Dispose();
                }
            }
        }
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
