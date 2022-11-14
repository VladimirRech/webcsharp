using System.Net;
using System.Text;

namespace web.crawlers.console.classes 
{
    public class MakeRequests
    {
        public MakeRequests() { }

        public bool Request()
        {
            Console.WriteLine("Iniciando request.");
            var request = WebRequest.Create("https://www.cnbc.com/2022/11/09/meta-to-lay-off-more-than-11000-thousand-employees.html");
            request.Method = "GET";
            request.Headers.Add("Content-type", "text;html; charset=utf-8");
            //string body = File.ReadAllText("~/myfile.txt");
            //Encoding encoding = Encoding.GetEncoding("utf-8");
            //byte[] bytes = encoding.GetBytes(body);
            //request.ContentLength = bytes.Length;
            using (var response = request.GetResponse())
            {
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                using(var respStream = response.GetResponseStream())
                {
                    using(var reader = new StreamReader(respStream))
                    {
                        string data = reader.ReadToEnd();
                        Console.WriteLine(data);
                    }
                }
            }
            
            return false;
        }
    }
}