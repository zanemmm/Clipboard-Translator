using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clipboard_Translator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new App());
        }

        public static string GetWordTranslation(string text)
        {
            string url = @"https://www.youdao.com/w/eng/" + text;
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            return doc.DocumentNode.SelectNodes("//*[@id=\"phrsListTab\"]/div[2]/ul/li").First().InnerText;
        }
    }
}
