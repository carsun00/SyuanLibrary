﻿using Crypto.Abstract.Crypto;
using Crypto.Model.Crypto;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Crypto.Controller.Crypto
{
    public class AesCrypto : AbstractCrypto
    {
        #region 方法
        /// <summary>
        ///     解密
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <returns>string</returns>
        public override string DeCrypto(string toDecrypt)
        {
            try
            {
                ICryptoTransform cTransform = Crypto.CreateDecryptor();
                byte[] enBytes = Convert.FromBase64String(toDecrypt);
                byte[] resultArray = cTransform.TransformFinalBlock(enBytes, 0, enBytes.Length);
                Crypto.Clear();

                return Encoding.UTF8.GetString(resultArray);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                /*
                 *  正常情況下，
                 *  API加密取資料會伴隨著取回後的密文代解密。
                 *  因此在這邊放入Dispose自動釋放資源。
                 */
                if(Crypto != null)
                {
                    Crypto.Dispose();
                }
            }
        }

        /// <summary>
        ///     加密
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns>string</returns>
        public override string EnCrypto(string toEncrypt)
        {
            try
            {
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
                byte[] resultArray = Crypto.CreateEncryptor().TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        ///     初始化加密物件。
        /// </summary>
        /// <param name="CryptoParamater">0</param>
        /// <returns></returns>
        public override SymmetricAlgorithm GenerateCrypto(AesAlgorithm CryptoParamater)
        {
            Crypto = new AesCryptoServiceProvider
            {
                Key = CryptoParamater.Key,
                IV = CryptoParamater.IV,
                Mode = CryptoParamater.Mode,
                Padding = CryptoParamater.Padding
            };
            return Crypto;
        }

        #endregion
    }
}