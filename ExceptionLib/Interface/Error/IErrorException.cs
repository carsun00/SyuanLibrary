using System;
namespace PrototypeException.Interface.Error
{
    /// <summary>
    ///     Define your exception case.
    /// </summary>
    public interface IErrorException
    {

        /// <summary>
        ///     Process Exception .
        ///     處理例外要回傳的類型
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public string ErrorException(Exception exception);

        /// <summary>
        ///     Default message (undefine exception)
        ///     預設訊息(未定義例外)
        /// </summary>
        /// <returns></returns>
        public string GetDefaultMsg();

        /// <summary>
        ///     Only Debug mode use.
        ///     Debug訊息
        /// </summary>
        /// <param name="exceptionMsg"></param>
        /// <returns></returns>
        public string GetDebugMsg(string exceptionMsg);
    }
}
