using Microsoft.Win32.SafeHandles;
using PropotypeClientService.Model;
using System;
using System.Runtime.InteropServices;

namespace PropotypeClientService.Abstract
{
    public abstract class AbstractClient<T> : IDisposable
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
        ///     this paramater should be HttpClient, WebClient Class.
        ///     這邊應該放入的是各類的Client服務。
        /// </summary>
        public T ClientType { get; set; }

        #endregion

        #region 抽象方法

        /// <summary>
        ///     Inital Client Servce
        ///     初始化各自的Client服務
        /// </summary>
        public abstract void CreatClient();

        /// <summary>
        ///     Get methond .
        ///     Get方法
        /// </summary>
        /// <param name="Url">Your get Url</param>
        /// <returns>json string data</returns>
        public abstract ResponseData GetClient(string Url);

        /// <summary>
        ///     Post methond.
        ///     Post方法.
        /// </summary>
        /// <param name="Url">Your post Url</param>
        /// <param name="JsonString">Using json string</param>
        /// <returns>Json string data</returns>
        public abstract ResponseData PostClient(string Url, string JsonString);

        #region 未定義
        /*
        /// <summary>
        ///     Put methond
        ///     Put方法
        /// </summary>
        /// <param name="Url">Your put Url</param>
        /// <param name="JsonString">Using json string</param>
        /// <returns>Json string data</returns>
        public abstract string PutClient(string Url, string JsonString);

        /// <summary>
        ///     Delete methond
        ///     Delete方法
        /// </summary>
        /// <param name="Url">Your delete Url</param>
        /// <param name="JsonString">Using json string</param>
        public abstract void DeleteClient(string Url, string JsonString);

        
        /// <summary>
        ///     for now Unused.
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="JsonString"></param>
        /// <returns></returns>
        public abstract string PatchClient(string Url, string JsonString);
        */
        #endregion

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
