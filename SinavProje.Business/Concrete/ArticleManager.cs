using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SinavProje.Business.Abstract;
using SinavProje.Core.Utilities.Results;
using SinavProje.Entities.Concrete.ClientEntities.Response;

namespace SinavProje.Business.Concrete
{
    public class ArticleManager : IArticlesService
    {
        public async Task<IDataResult<List<ArticleResponse>>> GetArticles()
        {
            HttpClient client = new HttpClient();
            using HttpResponseMessage result = await client.GetAsync($"https://www.wired.com/most-recent/");
            var stream = await result.Content.ReadAsStreamAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(stream);
            HtmlNodeCollection nodes =
                doc.DocumentNode.SelectNodes("//li/a[contains(@class, 'archive-item-component__link')]");
            List<ArticleResponse> articles = new List<ArticleResponse>();
            
            for (int i = 0; articles.Count<5; i++)
            {
                ArticleResponse article = new ArticleResponse {Link = nodes[i].Attributes["href"].Value};
                string lnk = "https://www.wired.com" + article.Link;
                using var response = await client.GetAsync(lnk);
                await using var streamAsync = await response.Content.ReadAsStreamAsync();
                doc = new HtmlDocument();
                doc.Load(streamAsync);

                if(doc.DocumentNode
                    .SelectSingleNode("//div[contains(@class, 'grid-layout__content')]") !=null)
                {
                    article.Title =String.Join("", doc.DocumentNode
                        .SelectSingleNode("//h1[contains(@class, 'content-header__row content-header__hed')]")
                        .InnerText.Replace("&#8212;", "'").Replace("&#39;", "'"));
                    article.Content =doc.DocumentNode
                        .SelectSingleNode("//div[contains(@class, 'grid-layout__content')]").InnerText.Replace("&#x27;", "'" ).Replace("&#39;","'");
                    articles.Add(article);
                }
            }

            return new SuccessDataResult<List<ArticleResponse>>(articles);
        }
    
    }
}
