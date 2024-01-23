using System;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Reflection.Metadata;
using System.Net.Http.Json;

namespace Snipping_OCR
{
    public class BaiduTransHelper
    {
        public static HttpClient _httpClient = new HttpClient();
        public static  string Trans(string theoriginal)
        {
            if (string.IsNullOrEmpty(theoriginal))
            {
                return "";
            }
            // 原文
            string q = theoriginal;
            // 源语言
            string from = "auto";
            // 目标语言
            string to = "zh";
            // 改成您的APP ID
            string appId = "";
            Random rd = new Random();
            string salt = rd.Next(100000).ToString();
            // 改成您的密钥
            string secretKey = "";
            string sign = EncryptString(appId + q + salt + secretKey);
            string url = "http://api.fanyi.baidu.com/api/trans/vip/translate?";
            url += "q=" + HttpUtility.UrlEncode(q);
            url += "&from=" + from;
            url += "&to=" + to;
            url += "&appid=" + appId;
            url += "&salt=" + salt;
            url += "&sign=" + sign;
           // var getContent = new StringContent("text/html;charset=UTF-8");

            var data= _httpClient.GetFromJsonAsync<TransJson_Result>(url).Result;
            var transtxt = "";
            foreach (var item in data.trans_result)
            {
                transtxt += item.dst;
            }
            return transtxt;
        }
        // 计算MD5值
        private static string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            // 将加密结果转换为字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                // 将字节转换成16进制表示的字符串，
                sb.Append(b.ToString("x2"));
            }
            // 返回加密的字符串
            return sb.ToString();
        }
    }

    public class TransJson_Result
    {
        public string error_code { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string error_msg { get; set; }
        /// <summary>
        /// 源语种
        /// </summary>
        public string from { get; set; }
        /// <summary>
        /// 目标语种
        /// </summary> 
        public string to { get; set; }
        public Trans_Result[] trans_result { get; set; }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (var item in trans_result)
            {
                yield return new KeyValuePair<string, string>(item.src, item.dst);
            }
        }
    }

    public class Trans_Result
    {
        /// <summary>
        /// 源字符串
        /// </summary>
        public string src { get; set; }
        /// <summary>
        /// 翻译后的字符串
        /// </summary>
        public string dst { get; set; }
    }
}
