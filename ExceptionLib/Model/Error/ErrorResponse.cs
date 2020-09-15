namespace ExceptionLib.Model.Error
{
    /// <summary>
    ///     Error Model.
    ///     錯誤模型。
    /// </summary>
    public class ErrorResponse
    {
        #region parrmater 宣告參數

        /// <summary>
        ///     Error Code
        ///     錯誤代碼
        /// </summary>
        public int errCode { get; set; }

        /// <summary>
        ///     Error message code.
        ///     錯誤訊息代碼
        /// </summary>
        public string msgCode { get; set; }

        /// <summary>
        ///     Error message
        ///     錯誤訊息
        /// </summary>
        public string errMsg { get; set; }

        /// <summary>
        ///     Error Data.
        ///     錯誤時的回傳資料.
        /// </summary>
        public string data { get; set; }

        #endregion
    }
}
