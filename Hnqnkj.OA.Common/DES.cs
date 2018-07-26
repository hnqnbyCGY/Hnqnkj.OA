using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Hnqnkj.OA.Common
{
    /// DES对称加密
    /// </summary>
    public sealed class DES
    {
        /// <summary>
        /// Des解密方法
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key">8位的key</param>
        /// <param name="IV">8位的IV</param>
        /// <returns></returns>
        public static string Decrypt(string val, string key, string IV)
        {
            try
            {
                byte[] buffer1 = Encoding.UTF8.GetBytes(key);
                byte[] buffer2 = Encoding.UTF8.GetBytes(IV);
                DESCryptoServiceProvider provider1 = new DESCryptoServiceProvider
                {
                    Mode = CipherMode.ECB,               
                    Key = buffer1,
                    IV = buffer2
                };
                ICryptoTransform transform1 = provider1.CreateDecryptor(provider1.Key, provider1.IV);
                byte[] buffer3 = Convert.FromBase64String(val);
                MemoryStream stream1 = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream1, transform1, CryptoStreamMode.Write);
                stream2.Write(buffer3, 0, buffer3.Length);
                stream2.FlushFinalBlock();
                stream2.Close();
                return Encoding.UTF8.GetString(stream1.ToArray());
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Des加密方法
        /// </summary>
        /// <param name="val"></param>
        /// <param name="key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        public static string Encrypt(string val, string key, string IV)
        {
            try
            {

                byte[] buffer1 = Encoding.UTF8.GetBytes(key);
                byte[] buffer2 = Encoding.UTF8.GetBytes(IV);

                DESCryptoServiceProvider provider1 = new DESCryptoServiceProvider
                {
                    Mode = CipherMode.ECB,
                    Key = buffer1,
                    IV = buffer2
                };
                ICryptoTransform transform1 = provider1.CreateEncryptor(provider1.Key, provider1.IV);
                byte[] buffer3 = Encoding.UTF8.GetBytes(val);
                MemoryStream stream1 = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream1, transform1, CryptoStreamMode.Write);
                stream2.Write(buffer3, 0, buffer3.Length);
                stream2.FlushFinalBlock();
                stream2.Close();
                return Convert.ToBase64String(stream1.ToArray());
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}