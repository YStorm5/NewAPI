using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using TestingNewAPI.Models;

namespace TestingNewAPI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<News> list = new List<News>();
            string Baseurl = "http://newsapi-001-site1.htempurl.com/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = await client.GetAsync("api/News/Get");
            if (res.IsSuccessStatusCode)
            {
                var Respone = res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<News>>(Respone);

            }
            return View(list);      
        }

        public async Task<IActionResult> Show(string link)
        {
            string url = "";
            if(link.Substring(0,6) == "/index")
            {
                url = $"https://freshnewsasia.com/{link}";
            }
            else
            {
                url = link; 
            }
            List<News> list = new List<News>();
            string Baseurl = "http://newsapi-001-site1.htempurl.com/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = await client.GetAsync($"api/News/Show?link={url}");
            if (res.IsSuccessStatusCode)
            {
                var Respone = res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<News>>(Respone);

            }
            return View(list);
        }
        
    }
}