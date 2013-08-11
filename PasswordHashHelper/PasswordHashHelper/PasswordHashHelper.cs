using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace PasswordHashHelper
{
    public class PasswordHashHelper
    {
        public static string CreateSalt(int size)
        {
            // Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        /// <summary>
        /// 根据传入的密码和salt 生成存入数据库的password
        /// </summary>
        /// <param name="pwd">
        /// The pwd.
        /// </param>
        /// <param name="salt">
        /// The salt.
        /// </param>
        /// <returns>
        /// </returns>
        public static string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = string.Concat(pwd, salt);
            string hashedPwd = GetSHA1(saltAndPwd);
            return hashedPwd;
        }

        public static string GetSHA1(string text)
        {
            byte[] hashValue;
            byte[] message = Encoding.UTF8.GetBytes(text);

            SHA1Managed hashString = new SHA1Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}
