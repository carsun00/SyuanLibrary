using Newtonsoft.Json;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace LibDataFormat.LibFile
{
    /// <summary>
    ///     Onlt Fromat Data Type. Not string or date format.
    ///     資料的格式轉換，不是字串格式或日期格式。
    /// </summary>
    public static class DataFormat
    {
        #region JsonFormat

        #region 反序列化JSON變String
        /// <summary>
        ///     Serialize Obj to string.
        ///     序列化物件為字串。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Obj"></param>
        /// <returns>string</returns>
        public static string ObjToString<T>(T Obj)
        {
            try
            {
                string Json = JsonConvert.SerializeObject(Obj);
                return Json;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 序列化String變Obj
        /// <summary>
        ///     Deserialize to Object.
        ///     序列化String變Obj
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JsonString"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string JsonString)
        {
            try
            {
                T Model = JsonConvert.DeserializeObject<T>(JsonString);
                return Model;
            }
            catch
            {
                return default;
            }
        }
        #endregion

        #region 動態序列化String變Obj
        /// <summary>
        ///     Deserialize dynamic object
        ///     動態序列化String變Obj
        /// </summary>
        /// <param name="value"></param>
        /// <returns>dynamic</returns>
        public static dynamic JsonToDynamic(string value)
        {
            try
            {
                dynamic model = JsonConvert.DeserializeObject(value);
                return model;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #endregion

        #region XmlFormat

        #region Xml資料轉換成OBJ
        /// <summary>
        ///     Xml資料轉換成OBJ
        ///     避免使用意外，請使用Try Catch
        /// <example>
        /// <code>
        /// <para>try</para>
        /// <para>{</para>
        /// <para>    Object obj = new Object();</para>
        /// <para>    obj = XmlToObj(xn, pi);</para>
        /// <para>}</para>
        /// <para>catch(Exception ex)</para>
        /// <para>{</para>
        /// <para>    //do something</para>
        /// <para>}</para>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="xmlNode">Xm的資料，僅取出你所要的階層</param>
        /// <param name="Obj">回傳的物件型態</param>
        public static T XmlToObj<T>(XmlNode xmlNode, T Obj)
        {
            string json = JsonConvert.SerializeXmlNode(xmlNode, Newtonsoft.Json.Formatting.None, true);
            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion

        #region XML文字轉換成XmlNode
        /// <summary>
        ///     XML文字轉換成XmlNode
        /// <example>
        /// <code>
        /// <para>String return = API.GetXmlFrommat;</para>
        /// <para>XmlNode xn = DataToXml(return, DataPath);</para>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="strReturn">API取回的XML字串</param>
        /// <param name="DataPath">要的資料路徑</param>
        /// <returns>
        /// XmlNode
        /// </returns>
        public static XmlNode DataToXmlNode(string xmlString, string DataPath)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xmlString);
            XmlNode xn = xd.SelectSingleNode(DataPath);
            return xn;
        }
        #endregion

        #region XML直接轉Obj
        /// <summary>
        ///     XML直接轉Obj
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <returns></returns>
        public static T XmlNodeConvertObj<T>(XmlNode node) where T : class
        {
            MemoryStream stm = new MemoryStream();

            StreamWriter stw = new StreamWriter(stm);
            stw.Write(node.OuterXml);
            stw.Flush();

            stm.Position = 0;

            XmlSerializer ser = new XmlSerializer(typeof(T));
            T result = ser.Deserialize(stm) as T;

            return result;
        }
        #endregion

        #endregion
    }
}
