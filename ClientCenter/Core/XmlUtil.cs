using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClientCenter.Core
{
    public class XmlUtil
    {
        public static string  ReadDataInfo(string filename,string key)
        {
            string value;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filename);
                XmlNode root = xmlDoc.SelectSingleNode("DataSource");        
                if (root != null)
                {
                    value = (root.SelectSingleNode(key)).InnerText;
                    return value;
                }
                else
                {
                    Console.WriteLine("the node  is not existed");
                    return "";
                }
            }
            catch (Exception e)
            {
                //显示错误信息  
                Console.WriteLine(e.Message);
                return "";
            }
        }

        public static void SavaDataInfo(string filename, string key,string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filename);
                XmlNode root = xmlDoc.SelectSingleNode("DataSource");
                if (root != null)
                {
                   root.SelectSingleNode(key).InnerText = value;
                    xmlDoc.Save(filename);
                }
                else
                {
                    Console.WriteLine("the node  is not existed");
                }
            }
            catch (Exception e)
            {
                //显示错误信息  
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string MD5Encrypt64(string content)
        {
            MD5 md5 = MD5.Create(); //实例化一个md5对像
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(content));// 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            return Convert.ToBase64String(s);
        }
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public static string Encryption(string express)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "shihangreal";//密匙容器的名称，保持加密解密一致才能解密成功
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] plaindata = Encoding.Default.GetBytes(express);//将要加密的字符串转换为字节数组
                byte[] encryptdata = rsa.Encrypt(plaindata, false);//将加密后的字节数据转换为新的加密字节数组
                return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为字符串
            }
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public static string Decrypt(string ciphertext)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = "shihangreal";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(ciphertext);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                return Encoding.Default.GetString(decryptdata);
            }
        }
    }
}
