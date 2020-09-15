namespace ClientService.Model.Response.Error
{
    /// <summary>
    ///     Response model for local server program catch .
    ///     本地伺服器內的錯誤回應模型。
    /// </summary>
    public class ServerErrorResponse
    {

        #region parrmater 宣告參數
        public int errCode { get; set; }
        public string msgCode { get; set; }
        public string errMsg { get; set; }
        public string data { get; set; }
        #endregion

    }
}
