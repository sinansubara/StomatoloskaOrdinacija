using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.WebAPI.Helper
{
    public class RandomString
    {
        public static string GetString(int size)
        {
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            StringBuilder result = new StringBuilder(10);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            return result.ToString();
        }
    }
}
