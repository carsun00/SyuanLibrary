using ClientService.Abstract;
using ClientService.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace ClientService.Controller.ClientService
{
    class HttpClientMethod : AbstractClient<HttpClient>
    {
        #region 宣告參數

        /// <summary>
        ///     Client
        /// </summary>
        private HttpClient client;

        /// <summary>
        ///     Time out setting.
        /// </summary>
        private readonly TimeSpan TimeOut = TimeSpan.FromSeconds(10);

        #endregion

        #region Create client

        /// <summary>
        ///     Factory mode.
        ///     工廠模式
        /// </summary>
        public override void CreatClient()
        {
            client = new HttpClient();
        }

        #endregion

        #region Get

        /// <summary>
        ///     HttpClient Get
        /// </summary>
        /// <param name="Url">Url</param>
        /// <returns>ResponseData</returns>
        public override ResponseData GetClient(string Url)
        {
            ResponseData httpResponse;

            using(HttpClient httpClient = client)
            {
                client.Timeout = TimeOut;
                try
                {
                    // this part only process http requese. 
                    using(HttpResponseMessage response = client.GetAsync(Url).Result)
                    {
                        /*   
                         *   process data. 
                         *   if your data have logic, should be ResponseData class.
                         *   
                         *   #mark# maybe should be Intercafe?
                         */
                        httpResponse = new ResponseData(response);
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
            }

            return httpResponse;
        }
        #endregion

        #region Post

        /// <summary>
        ///     Post
        /// </summary>
        /// <param name="Url">Url</param>
        /// <param name="JsonString">Query json string</param>
        /// <returns>ResponseData</returns>
        public override ResponseData PostClient(string Url, string JsonString)
        {
            ResponseData httpResponse;
            using(HttpClient httpClient = client)
            {
                #region 前置設定
                client.Timeout = TimeOut;
                HttpContent httpContent = GetNameValueCollection(JsonString);
                #endregion


                try
                {
                    using(HttpResponseMessage response = httpClient.PostAsync(Url, httpContent).Result)
                    {
                        httpResponse = new ResponseData(response);
                    }
                }
                catch(Exception)
                {
                    httpResponse = new ResponseData(
                        (int)HttpStatusCode.InternalServerError
                        , "define your error message");
                }
            }
            return httpResponse;
        }

        #endregion

        #region private methon

        /// <summary>
        ///     Generate HttpContent name value collection.
        ///     In my case only request key.    
        /// 
        ///     產生HttpConetent的Key & value集合。
        ///     在這邊預設情況只會有一個request的Key
        /// </summary>
        /// <param name="JsonString">Data</param>
        /// <returns>HttpContent</returns>
        private HttpContent GetNameValueCollection(string JsonString)
        {
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("request", JsonString));
            return new FormUrlEncodedContent(keyValues);
        }
        #endregion
    }

}
