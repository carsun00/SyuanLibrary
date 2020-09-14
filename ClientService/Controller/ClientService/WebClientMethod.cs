using ClientService.Abstract;
using ClientService.Model;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace ClientService.Controller.ClientService
{
    class WebClientMethod : AbstractClient<WebClient>
    {
        #region 宣告參數

        /// <summary>
        ///     Client
        /// </summary>
        private WebClient client;


        #endregion
        public override void CreatClient()
        {
            client = new WebClient();
        }

        public override ResponseData GetClient(string Url)
        {
            ResponseData httpResponse;
            try
            {
                using(WebClient wc = client)
                {
                    wc.Encoding = Encoding.UTF8;

                    httpResponse = new ResponseData(
                        (int)HttpStatusCode.OK
                        , wc.DownloadString(Url)
                        );
                }
            }
            catch(Exception)
            {
                /*  
                 *  Your exception handling.
                 *  In this case, just use ResponseData class for exception handling.
                 *  
                 *  Suggest creat class for exception handling.
                 *  
                 *  你的例外處理
                 *  在這邊只是用ResponseData處理異常。
                 *  
                 *  建議開一個類別專門處理異常。
                 */
                httpResponse = new ResponseData(
                    (int)HttpStatusCode.InternalServerError
                    , "define your error message"
                );
            }
            return httpResponse;
        }

        public override ResponseData PostClient(string Url, string JsonString)
        {
            ResponseData httpResponse; 
            try
            {
                using(WebClient wc = client)
                {
                    wc.Encoding = Encoding.UTF8;

                    var NameValue = GetNameValueCollection(JsonString);

                    byte[] ApiRepasonesByByte = wc.UploadValues(Url, NameValue);
                    httpResponse = new ResponseData(
                        (int)HttpStatusCode.OK
                        , Encoding.UTF8.GetString(ApiRepasonesByByte)
                        );
                }
            }
            catch(Exception)
            {
                /*  
                 *  Your exception handling.
                 *  In this case, just use ResponseData class for exception handling.
                 *  
                 *  Suggest creat class for exception handling.
                 *  
                 *  你的例外處理
                 *  在這邊只是用ResponseData處理異常。
                 *  
                 *  建議開一個類別專門處理異常。
                 */
                httpResponse = new ResponseData(
                    (int)HttpStatusCode.InternalServerError
                    , "define your error message"
                );
            }
            return httpResponse;
        }


        #region private methond

        /// <summary>
        ///     Generate name value collection.
        ///     In my case only request key.    
        /// 
        ///     產生NameValueCollection的Key & value集合。
        ///     在這邊預設情況只會有一個request的Key
        /// </summary>
        /// <param name="JsonString">Data</param>
        /// <returns>HttpContent</returns>
        private NameValueCollection GetNameValueCollection(string JsonString)
        {
            NameValueCollection nameValue = new NameValueCollection();
            nameValue["request"] = JsonString;
            return nameValue;
        }
        #endregion
    }
}
