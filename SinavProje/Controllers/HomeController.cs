using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SinavProje.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SinavProje.Filter;
using HtmlAgilityPack;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Http.Logging;
using SinavProje.Business.Abstract;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Entities.Concrete.Entities;
using SinavProje.Extensions;

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

        public IActionResult Index()
        {
            return View(_articlesService.GetArticles().Result.Data);
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
