using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;

namespace GT
{
    public partial class Form2 : Form
    {
        List<string> language = new List<string>(new[]
        {
            "en",
            "de",
            "ja",
            "fr",
            "mn",
            "pl",
            "el",
            "es",
            "th",
            "ko",
            "my",
            "ru",
            "pt",
            "tt",
            "ts",
            "st",
            "ceb",
            "bm",
            "et",
            "sk",
            "eo",
            "sn",
            "la",
            "gn",
            "ms",
            "be",
            "uk"
        });
        string text = "";
        int times = 0;
        public Form2(string text,int times)
        {
            InitializeComponent();
            this.text = text;
            this.times = times;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            new Task(() =>
            {
                while (true)
                {
                    label1.Text = "翻译中";
                    Thread.Sleep(100);
                    for (int i = 0; i < 3; i++)
                    {
                        label1.Text += ".";
                        Thread.Sleep(100);
                    }
                }
            }).Start();
            new Task(() =>
            {
                Random ran = new Random();
                string tlanguage = language[ran.Next(0, language.Count)];
                string tlanguage2 = "zh-CN";
                Trans(text, tlanguage2, tlanguage);
                tlanguage2 = tlanguage;
                for (int i = 0; i < times-1; i++)
                {
                    while (tlanguage == tlanguage2)
                    {
                        tlanguage = language[ran.Next(0, language.Count)];
                    }
                    Trans(richTextBox1.Text, tlanguage2, tlanguage);
                    tlanguage2 = tlanguage;
                }
                Trans(richTextBox1.Text, tlanguage2, "zh-CN");
                label1.Visible = false;
            }).Start();
        }
        #region 翻译
        public string Google(string q, string from, string to)
        {
            string url = "https://translate.google.cn/_/TranslateWebserverUi/data/batchexecute?rpcids=MkEWBc&bl=boq_translate-webserver_20210927.13_p0&soc-app=1&soc-platform=1&soc-device=1&rt=c";
            var from_data = "f.req=" + HttpUtility.UrlEncode(
                string.Format("[[[\"MkEWBc\",\"[[\\\"{0}\\\",\\\"{1}\\\",\\\"{2}\\\",true],[null]]\", null, \"generic\"]]]",
                ReplaceString(q), from, to), Encoding.UTF8).Replace("+", "%20");
            byte[] postData = Encoding.UTF8.GetBytes(from_data);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            client.Headers.Add("ContentLength", postData.Length.ToString());
            client.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36");
            byte[] responseData = client.UploadData(url, "POST", postData);
            string content = Encoding.UTF8.GetString(responseData);
            return MatchResult(content);
        }
        public static string MatchResult(string content)
        {
            string result = "";
            string patttern = @",\[\[\\\""(.*?)\\\"",";
            Regex regex = new Regex(patttern);
            MatchCollection matchcollection = regex.Matches(content);
            if (matchcollection.Count > 0)
            {
                List<string> list = new List<string>();
                list.Add(matchcollection[1].Groups[1].Value);
                result = string.Join(" ", list.Distinct());
                if (result.LastIndexOf(@"\""]]]],\""") > 0)
                {
                    result = result.Substring(0, result.LastIndexOf(@"\""]]]],"));
                }
            }
            return result;
        }
        public static string ReplaceString(string JsonString)
        {
            if (JsonString == null) { return JsonString; }
            if (JsonString.Contains("\\"))
            {
                JsonString = JsonString.Replace("\\", "\\\\");
            }
            if (JsonString.Contains("\'"))
            {
                JsonString = JsonString.Replace("\'", "\\\'");
            }
            if (JsonString.Contains("\""))
            {
                JsonString = JsonString.Replace("\"", "\\\\\\\"");
            }
            //去掉字符串的回车换行符
            JsonString = Regex.Replace(JsonString, @"[\n\r]", "");
            JsonString = JsonString.Trim();
            return JsonString;
        }
        public string Trans(string text, string from, string to)
        {
            richTextBox1.Text = "";
            string[] split = text.Split('\n');
            string Return = "";
            foreach (string s in split)
            {
                richTextBox1.Text += Google(s, from, to) + "\n";
                Return += Google(s, from, to) + "\n";
            }
            return Return;
        }
        #endregion

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
