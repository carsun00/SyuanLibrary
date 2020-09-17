using Newtonsoft.Json;
using PrototypeException.Controller.Error;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

namespace PropotypeClientService.Model
{
    public class ResponseData
    {
        #region 參數

        /// <summary>
        ///     Should define web status code.
        ///     要定義回傳的錯誤狀態。
        ///     Status Code refance : https://zh.wikipedia.org/zh-tw/HTTP%E7%8A%B6%E6%80%81%E7%A0%81
        /// </summary>
        public HttpStatusCode StatusCode;

        /// <summary>
        ///     Your response date or error message(Json string).
        ///     你的回應資料，或者錯誤訊息(使用Json string)
        /// </summary>
        public string Data;
        #endregion

        #region New Methond

        #region Success(成功)
        /// <summary>
        ///     Request success.
        /// </summary>
        /// <param name="response"></param>
        public ResponseData(HttpResponseMessage response)
        {
            /* 
             *  Some time remote server reponse error.
             *  don't need process, jsut return error to client.
             *  so StatusCode should be send back together.
             *  
             *  有時候遠端伺服器回應錯誤.
             *  不用額外處裡可以直接回傳錯誤給Client.
             *  所以StatusCode應該要一起回傳
             */
            StatusCode = response.StatusCode;
            Data = response.Content.ReadAsStringAsync().Result;
        }
        #endregion

        #region Custom(客製化)
        /// <summary>
        ///     Custom response message.
        /// </summary>
        /// <param name="status">Define your http sataus.</param>
        /// <param name="response">Your custom response</param>
        public ResponseData(HttpStatusCode status, string response)
        {
            StatusCode = status;
            Data = response;
        }
        #endregion

        #region Exception(例外)

        /// <summary>
        ///     Corresponding status code is generated when receiving errors.
        ///     接收錯誤產生相對應的狀態Code.
        /// </summary>
        /// <param name="exception"></param>
        public ResponseData(Exception exception)
        {
            ServerException errorException = new ServerException();
            //  Setting return error msg.
            switch(exception.GetType().Name)
            {
                //  Exception case and define your Msg.
                #region AggregateException
                case "AggregateException":
                    SetResponseData(
                       HttpStatusCode.InternalServerError,
                       errorException.ErrorException(exception)
                       );

                    // Debug Mode Issue Trace.
                    SetDebugData(exception.StackTrace);
                    break;
                #endregion

                #region default
                default:
                    SetResponseData(
                        HttpStatusCode.InternalServerError,
                        errorException.GetDefaultMsg()
                        );
                    break;
                    #endregion

            }
        }
        #endregion

        #endregion

        #region private mothend

        private void SetResponseData(HttpStatusCode ststus, string AnyStringData)
        {
            StatusCode = ststus;
            Data = AnyStringData;
        }

        [Conditional("DEBUG")]
        private void SetDebugData(string exception)
        {
            Data = exception;
        }
        #endregion
    }
}
