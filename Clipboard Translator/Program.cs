using HtmlAgilityPack;
using System;
using System.Linq;
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
            try {
                string url = @"https://www.youdao.com/w/" + text;
                HtmlWeb web = new HtmlWeb();
                var doc = web.Load(url);
                // 翻译结果
                string transXPath = "//*[@id='phrsListTab']/div[@class='trans-container']/ul/li";
                var transNodes = doc.DocumentNode.SelectNodes(transXPath);
                if (transNodes == null) {
                    return String.Format("没有单词 {0} 的翻译结果", text);
                }
                string trans = "";
                foreach (HtmlNode node in transNodes.ToList()) {
                    trans += node.InnerText.Trim() + "\r\n";
                }
                // 网络释义
                string webTrans = "";
                string webTransXPath = "//*[@id='tWebTrans']/div[contains(@class,'wt-container')]/div[@class='title']/span";
                var webTransNodes = doc.DocumentNode.SelectNodes(webTransXPath);
                if (webTransNodes != null) {
                    webTrans = "\r\n网络释义：\r\n";
                    foreach (HtmlNode node in webTransNodes.ToList()){
                        webTrans += node.InnerText.Replace("\n", "").Replace(" ", "").Replace("\t", "") + "; ";
                    }
                }
                return text + " 释义：\r\n" + trans + webTrans;
            } catch (Exception e) {
                return "翻译失败,出现异常：\r\n" + e.Message;
            }
        }

        public static string GetSentenceTranslation(string text)
        {
            try {
                text = Uri.EscapeUriString(text);
                string url = @"https://www.youdao.com/w/" + text;
                HtmlWeb web = new HtmlWeb();
                var doc = web.Load(url);
                string xPath = "//*[@id='fanyiToggle']/div[@class='trans-container']/p[2]";
                var node = doc.DocumentNode.SelectSingleNode(xPath);
                if (node == null) {
                    return "句子翻译失败，请尝试翻译单词。";
                }
                return node.InnerText.Trim().Replace("\r", "").Replace("\n", "");
            } catch (Exception e) {
                return "翻译失败,出现异常：\r\n" + e.Message;
            }
        }
    }
}
