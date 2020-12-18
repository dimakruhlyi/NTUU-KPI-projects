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
    class DES
    {
        public string encryption(string str, byte[] key, byte[] IV)
        {
            byte[] eData;
            string a = String.Empty;

            if (str == String.Empty)
            {
                return "";
            }

            using (DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider())
            {
                cryptic.Key = key;
                cryptic.IV = IV;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, cryptic.CreateEncryptor(cryptic.Key, cryptic.IV), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(str);
                        }

                        eData = ms.ToArray();
                    }
                }
            }

            foreach (var b in eData)
            {
                a += b.ToString() + ", ";   
            }

            a = a.Remove(a.Length - 2, 2);
            return a;
        }


        public string decryption(string str, byte[] key, byte[] IV)
        {
            string dData = String.Empty;

            if (str == String.Empty)
            {
                return "";
            }


            string[] date = str.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            byte[] cText = new byte[date.Length];

            for (int i = 0; i < date.Length; i++)
            {
                try
                {
                    cText[i] = Convert.ToByte(date[i]);
                }
                catch (Exception)
                {
                    MessageBox.Show("Неправильні вхідні дані", "Error", MessageBoxButtons.OK);
                    return str;
                }
            }

            using (DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider())
            {
                cryptic.Key = key;
                cryptic.IV = IV;

                using (MemoryStream ms = new MemoryStream(cText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, cryptic.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            try
                            {
                                dData = sr.ReadToEnd();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Вхідні дані не відповідають ключу", "Error", MessageBoxButtons.OK);
                                return str;
                            }
                        }
                    }
                }
            }

            return dData;
        }
    }
}
