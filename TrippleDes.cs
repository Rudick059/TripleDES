using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace WindowsFormsApp4
{
    public class TrippleDes
    {
        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        
        public TrippleDes(string key)
        {
            des.Key = UTF8Encoding.UTF8.GetBytes(key);
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
        }

        public void EncryptFile(string filePath)
        {
            byte[] Bytes = File.ReadAllBytes(filePath);
            byte[] eBytes = des.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filePath, eBytes);
        }

        public void DecryptFiles(string filePath)
        {
            byte[] Bytes = File.ReadAllBytes(filePath);
            byte[] dBytes = des.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filePath, dBytes);
        }
    }

}
