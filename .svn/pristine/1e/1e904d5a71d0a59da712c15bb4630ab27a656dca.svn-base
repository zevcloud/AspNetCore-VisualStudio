using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AspNetCore.Mvc.Utils.Cryption
{
    /// <summary>
    /// 解密AES算法
    /// </summary>
    public static class DecryptionAESUnits
    {

        /// <summary>
        /// 解密AES算法
        /// </summary>
        /// <param name="input">字符串</param>
        /// <param name="key">SALT</param>
        /// <returns></returns>
        public static string AESDecrypt(string input, string key)
        {
            var fullCipher = Convert.FromBase64String(input);
            var iv = new byte[16];
            var cipher = new byte[16];
            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var decryptKey = Encoding.UTF8.GetBytes(key);
            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(decryptKey, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt,
                            decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                    return result;
                }
            }
        }
    }
}
