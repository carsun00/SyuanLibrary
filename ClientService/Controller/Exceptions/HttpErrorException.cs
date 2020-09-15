using ClientService.Model.Response.Error;
using Newtonsoft.Json;
using System;

namespace ClientService.Controller.Exceptions
{
    /// <summary>
    ///     Custom Http Client Exception in here.
    ///     在這邊客製化Http例外處理。
    /// </summary>
    public class HttpErrorException
    {
        ServerErrorResponse response = new ServerErrorResponse();

        public string ErrorException(Exception exception)
        {

            switch(exception.GetType().Name)
            {  /* Exception case */
                #region "EndpointNotFoundException"
                case "EndpointNotFoundException":
                    return ApiConnectionFailed();
                #endregion
                
                #region default
                default:
                    return GetDefaultMsg();
                    #endregion
            }
        }

        #region Public

        #region Default

        /// <summary>
        ///     Default Msg.
        /// </summary>
        /// <returns></returns>
        public string GetDefaultMsg()
        {
            //  Set your Msg
            response = new ServerErrorResponse
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
        /// <param name="ExceptionMsg"></param>
        /// <returns></returns>
        public string GetDebugMsg(string ExceptionMsg)
        {
            //  Set your Msg
            response = new ServerErrorResponse
            {
                errCode = -1,
                msgCode = "Debug01",
                errMsg = ExceptionMsg
            };

            string JsonString = JsonConvert.SerializeObject(response);
            return JsonString;
        }

        #endregion

        #endregion

        #region private

        /// <summary>
        ///     ConnectionFailed
        ///     連線失敗
        /// </summary>
        /// <returns></returns>
        private string ApiConnectionFailed()
        {
            response = new ServerErrorResponse
            {
                errCode = -1,
                msgCode = "WEBE001",
                errMsg = "Remote Api connection failed."

            };

            string JsonString = JsonConvert.SerializeObject(response);
            return JsonString;
        }
        #endregion

    }
}
