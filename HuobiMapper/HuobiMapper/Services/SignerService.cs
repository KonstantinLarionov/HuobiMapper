using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace HuobiMapper.Services
{
    public class SignerService
    {
        public SignerService()
        {
            
        }

        public string GetSignature(string apikey, string secret, string signmethod, 
            string signversion, string host, string path, string method, string param)
        {
            WebDriver driver = new ChromeDriver();
            IJavaScriptExecutor js = driver;
            string text = string.Empty;
            using (StreamReader fs = new StreamReader(@"D:\.rider\AVBINVESTMappers\signer.js"))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if(temp == null) break;
                    text  += temp;
                }
            }

            text = text
                .Replace("__APIKEY__", apikey)
                .Replace("__SECRET__", secret)
                .Replace("__SIGNVERSION__", signversion)
                .Replace("__SIGNMETHOD__", signmethod)
                .Replace("__METHOD__", method)
                .Replace("__QUERYPARAMS__", param)
                .Replace("__HOST__", host)
                .Replace("__PATH__", path);
            
            string res = (string)js.ExecuteScript(text);
            return res;
        }
    }
}