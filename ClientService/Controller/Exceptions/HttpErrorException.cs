using ClientService.Model.Response.Error;
using Newtonsoft.Json;

namespace ClientService.Controller.Exceptions
{
    /// <summary>
    ///     Custom Http Client Exception in here.
    ///     在這邊客製化Http例外處理。
    /// </summary>
    public class HttpErrorException
    {
        HttpErrorResponse response = new HttpErrorResponse();

        #region Default
        /// <summary>
        ///     Default Msg.
        /// </summary>
        /// <returns></returns>
        public string GetDefaultMsg()
        {
            //  Set your Msg
            response = new HttpErrorResponse
            {
                errCode = -1,
                msgCode = "Default0001",
                errMsg = "Local servce undefine exception."
            };

            string JsonString = JsonConvert.SerializeObject(response);
            return JsonString;
        }
        #endregion

        #region Debug
        /// <summary>
        ///     Deubg mag
        /// </summary>
        /// <param name="exceptionMsg"></param>
        /// <returns></returns>
        public string GetDebugMsg(string exceptionMsg)
        {
            //  Set your Msg
            response = new HttpErrorResponse
            {
                errCode = -1,
                msgCode = "Default0001",
                errMsg = exceptionMsg
            };

            string JsonString = JsonConvert.SerializeObject(response);
            return JsonString;
        }

        #endregion
    }
}
