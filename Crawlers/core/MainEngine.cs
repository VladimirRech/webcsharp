using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class MainEngine
    {
        string _url;
        string _node;
        string _lastError;        
        CookieContainer _cookie;
        string _decodedText;

        public string LastError { get { return _lastError; } }
        public string DecodedText { get { return _decodedText; } }


        public MainEngine(string url, string node)
        {
            _url = url;
            _node = node;
        }

        public string Read()
        {
            if (string.IsNullOrEmpty(_url) || string.IsNullOrEmpty(_node))
            {
                _lastError = "Nenhuma url ou node para ler.";
                return null;
            }

            HttpWebRequest request = createWebRequestGet();
            string readText = getText(request);
            return readText;
        }

        string getText(HttpWebRequest request)
        {
            var response = (HttpWebResponse)request.GetResponse();
            var body = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            response.Close();
            var html = new HtmlDocument();
            html.LoadHtml(body);
            _decodedText = html.DocumentNode.SelectSingleNode(_node).InnerHtml;
            return WebUtility.UrlEncode(_decodedText);
        }

        HttpWebRequest createWebRequestGet()
        {
            var request = (HttpWebRequest)WebRequest.Create(_url);
            request.Method = "GET";
            request.Timeout = 10000;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.130 Safari/537.36";
            request.Referer = _url;
            request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            request.Headers.Add("Accept-Language", "pt-BR,pt;q=0.8,en-US;q=0.6,en;q=0.4");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            _cookie = new CookieContainer();
            request.CookieContainer = _cookie;
            return request;
        }
    }
}
