using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqnkj.OA.Common
{
    public class MD5
    {
        public static string GetMD5(string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);

            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("X").PadLeft(2, '0');
            }
            return ret;
        }
    }
}
