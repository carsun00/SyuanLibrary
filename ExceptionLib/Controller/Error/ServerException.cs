using ExceptionLib.Interface.Error;
using ExceptionLib.Model.Error;
using Newtonsoft.Json;
using System;

namespace ExceptionLib.Controller.Error
{
    public class ServerException : IErrorException
    {
        ErrorResponse response = new ErrorResponse();

        #region ErrorExceptionCase
        public string ErrorException(Exception exception)
        {
            string stingReturn = string.Empty;

            switch(exception.GetType().Name)
            {

                #region AggregateException
                case "AggregateException":
                    stingReturn = GetAggregateException(exception);
                    break;
                #endregion

                #region NullReferenceException
                case "NullReferenceException":
                    stingReturn = GetNullReferenceException(exception);
                    break;
                #endregion

                #region AnyException

                #endregion

                #region default
                default:
                    stingReturn = GetDefaultMsg();
                    break;
                
                #endregion

            }

            return stingReturn;
        }

        #endregion

        #region Public

        /// <summary>
        ///     Default message.
        ///     預設訊息。
        /// </summary>
        /// <returns></returns>
        public string GetDefaultMsg()
        {
            //  Your error format model.
            response = new ErrorResponse
            {
                errCode = -1,
                msgCode = "WebS0001",
                errMsg = "Web Server undefine exception."

            };

            string JsonString = JsonConvert.SerializeObject(response);
            return JsonString;
        }

        /// <summary>
        ///     Debug mode exception trace message
        /// </summary>
        /// <param name="exceptionMsg"></param>
        /// <returns></returns>
        public string GetDebugMsg(string exceptionMsg)
        {
            //  Your error format model.
            response = new ErrorResponse
            {
                errCode = -1,
                msgCode = "WebS0002",
                errMsg = exceptionMsg

            };

            string JsonString = JsonConvert.SerializeObject(response);
            return JsonString;
        }

        #endregion

        #region private

        /// <summary>
        ///     AggregateException message.
        ///     預設訊息。
        /// </summary>
        /// <returns></returns>
        private string GetAggregateException(Exception Exception)
        {
            //  Your error format model.
            response = new ErrorResponse
            {
                errCode = -1,
                msgCode = "WebE0001",
                errMsg = "Web Server Exception.",
                data = Exception.StackTrace
            };

            string JsonString = JsonConvert.SerializeObject(response);
            return JsonString;
        }
        /// <summary>
        ///     AggregateException message.
        ///     預設訊息。
        /// </summary>
        /// <returns></returns>
        private string GetNullReferenceException(Exception Exception)
        {
            //  Your error format model.
            response = new ErrorResponse
            {
                errCode = -1,
                msgCode = "WebE0002",
                errMsg = "Web Server Exception.",
                data = Exception.StackTrace
            };

            string JsonString = JsonConvert.SerializeObject(response);
            return JsonString;
        }

        #endregion

    }
}
