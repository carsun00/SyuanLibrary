using System.IO;

namespace LibReadFileString.LibFile
{
    /// <summary>
    ///     File Reader.
    ///     讀檔程式。
    /// </summary>
    public class ReadFileByPath
    {
        /// <summary>
        ///     Read text File.
        ///     讀取純文字檔案.
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public string ReadStringFile(string FilePath)
        {
            using(TextReader readerFile = new StreamReader(FilePath))
            {
                string returnString = readerFile.ReadToEnd();
                return returnString;
            }
        }
    }
}