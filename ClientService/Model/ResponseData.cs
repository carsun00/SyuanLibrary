using System.Net;
using System.Net.Http;

namespace ClientService.Model
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

        public ResponseData(HttpResponseMessage response)
        {
            StatusCode = response.StatusCode;
            Data = response.Content.ReadAsStringAsync().Result;
        }
        public ResponseData(HttpStatusCode status, string response)
        {
            StatusCode = status;
            Data = response;
        }

        #endregion
    }
}
