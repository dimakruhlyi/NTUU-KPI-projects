using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class RSA
    {
        byte[] encrypti_byte;

        public byte[] Encrypti_byte
        {
            get
            {
                return encrypti_byte;
            }

            set
            {
                encrypti_byte = value;
            }
        }

        public string encryption(string str, string key)
        {
            byte[] Data;
            string resoult = string.Empty;

            if (str == String.Empty)
            {
                return "";
            }
            Data = Encoding.UTF8.GetBytes(str);

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            rsa.PersistKeyInCsp = false;
            rsa.FromXmlString(key);
            encrypti_byte = rsa.Encrypt(Data, true);

            return BitConverter.ToString(encrypti_byte).Replace("-","");
        }

        public string decryption(string str, string key)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.PersistKeyInCsp = false;
            rsa.FromXmlString(key);

            if (str == String.Empty)
            {
                return "";
            }

            byte[] decrypt_byte = rsa.Decrypt(Encrypti_byte, true);
            return Encoding.UTF8.GetString(decrypt_byte);
        }

        
    }
}
