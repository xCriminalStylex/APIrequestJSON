using System;
using Xunit;
using RestSharp;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace APIrequestJSON
{
    public class UnitTest1
    {

        [Fact]
        public void TestUsingCookies()

        {
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/x-www-form-urlencoded" }
            };
            var body = new Dictionary<string, string>
            {
                 {"ulogin", "art1613122" },
                 {"upassword", "505558545 " }

            };
            var response = APIhelper.SendAPIrequest(body, headers, "https://my.soyuz.in.ua/", Method.POST);

            var cookie = APIhelper.ExtractCookie(response, "zbs_lang");
            var cookie2 = APIhelper.ExtractCookie(response, "ulogin");
            var cookie3 = APIhelper.ExtractCookie(response, "upassword");

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://my.soyuz.in.ua/");
            System.Threading.Thread.Sleep(3000);
            
            driver.Manage().Cookies.AddCookie(cookie);
            driver.Manage().Cookies.AddCookie(cookie2);
            driver.Manage().Cookies.AddCookie(cookie3);
            

            driver.Navigate().GoToUrl("https://my.soyuz.in.ua/index.php");
            System.Threading.Thread.Sleep(10000);
            driver.Close();
        }
        [Fact]
        public void TestUpLoadImg()
        {
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "multipart/form-data" }
            };
            var body = new Dictionary<string, object>
            {
                {"login", "jofafeg989@nahetech.com" },
                {"password", "123456789" },
                 {"avatar", "C:\\Users\\������������\\source\\repos\\APIrequest\\venus.jpg" }
            };

            var response = APIhelper.UpLoadImgAPIrequest(body, headers, "http://users.bugred.ru/tasks/rest/addavatar/", Method.POST);
        }
        [Fact]
        public void TestDownLoadFile()
        {
            RestClient client = new RestClient("https://i.pinimg.com/originals/15/5a/17/155a1725ed188934f0c70617e2b70f46.jpg");
            var requestImg = new RestRequest(Method.GET);
            byte[] result = client.DownloadData(requestImg);
            File.WriteAllBytes(Path.Combine("C:\\Users\\������������\\source\\repos\\APIrequestJSON\\img.jpg"), result);
        }
        
    }
}