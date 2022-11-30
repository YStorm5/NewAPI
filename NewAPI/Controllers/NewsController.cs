using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAPI.Model;
using System.Security.Cryptography.X509Certificates;

namespace NewAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<News> news = new List<News>();
            HtmlWeb htmlWeb = new HtmlWeb();
            
            for (int i = 0; i < 50; i += 50)
            {
                HtmlDocument document = htmlWeb.Load($"https://freshnewsasia.com/index.php/en/?start={i}");
                var doc = document.DocumentNode.SelectNodes("//td[@class='list-title']");
                foreach (var item in doc)
                {
                    string title = item.SelectSingleNode("a").InnerText.Trim();
                    string link = item.SelectSingleNode("a").GetAttributeValue("href", null).Trim();
                    HtmlWeb htmlWeb1 = new HtmlWeb();
                    if (link.Substring(0, 6) == "/index")
                    {
                        HtmlDocument document1 = htmlWeb1.Load($"https://freshnewsasia.com/{link}");
                        var detailList = document1.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div[2]");
                        news.Add(new News()
                        {
                            title = title,
                            link = link,
                            detial = detailList.First().InnerText.Trim()

                        });
                    }
                    else
                    {
                        HtmlDocument document1 = htmlWeb1.Load(link);
                        var detailList = document1.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div[2]");
                        news.Add(new News()
                        {
                            title = title,
                            link = link,
                            detial = detailList.First().InnerText.Trim()

                        });
                    }
                }

            }

            return Ok(news);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<News> news = new List<News>();
            HtmlWeb htmlWeb = new HtmlWeb();

            for (int i = 0; i < 50; i += 50)
            {
                HtmlDocument document = htmlWeb.Load($"https://freshnewsasia.com/index.php/en/?start={i}");
                var doc = document.DocumentNode.SelectNodes("//td[@class='list-title']");
                foreach (var item in doc)
                {
                    string title = item.SelectSingleNode("a").InnerText.Trim();
                    string link = item.SelectSingleNode("a").GetAttributeValue("href", null).Trim();
                    news.Add(new News
                    {
                        title = title,
                        link = link
                    });
                }
            }
            return Ok(news);
        }
        [HttpGet]
        public async Task<IActionResult> Show(string link)
        {
            List<News> news = new List<News>();
            HtmlWeb htmlWeb1 = new HtmlWeb();

            if (link.Substring(0, 6) == "/index")
            {
                HtmlDocument document1 = htmlWeb1.Load($"https://freshnewsasia.com/{link}");
                var detailList = document1.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div[2]");
                var title = document1.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/div[3]/div[1]/h2").InnerText.Trim();
                var date = document1.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/div[3]/dl/dd/time").InnerText.Trim();

                news.Add(new News()
                {
                    title=title,
                    link = link,
                    detial = detailList.First().InnerHtml.Trim(),
                    DateTime = date

                });
            }
            else
            {
                HtmlDocument document1 = htmlWeb1.Load(link);
                var detailList = document1.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div[2]");
                var title = document1.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/div[3]/div[1]/h2").InnerText.Trim();
                var date = document1.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/div[3]/dl/dd/time").InnerText.Trim();
                detailList.First().ChildNodes.Remove(2);
                news.Add(new News()
                {
                    title = title,
                    link = link,
                    detial = detailList.First().InnerHtml.Trim(),
                    DateTime= date

                });
            }

            return Ok(news);
        }
       
    }
}
