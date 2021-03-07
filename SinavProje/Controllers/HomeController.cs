using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SinavProje.Filter;
using SinavProje.Business.Abstract;

namespace SinavProje.Controllers
{
    [UserFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticlesService _articlesService;

        public HomeController(ILogger<HomeController> logger, IArticlesService articlesService)
        {
            _logger = logger;
            _articlesService = articlesService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _articlesService.GetArticles();

            return View(result);
        }

    }
}
