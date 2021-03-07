using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinavProje.Business.Abstract;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Entities.Concrete.Entities;
using SinavProje.Extensions;
using SinavProje.Filter;
using SinavProje.Models;

namespace SinavProje.Controllers
{
    [UserFilter]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly IQuestionService _questionService;
        private readonly IArticlesService _articlesService;

        public ExamController(IExamService examService, IArticlesService articlesService, IQuestionService questionService)
        {
            _examService = examService;
            _articlesService = articlesService;
            _questionService = questionService;
        }
        public IActionResult Index()
        {
            return View(_examService.GetExams().Result.Data);
        }

        [HttpGet("/{id}/{title}")]
        public IActionResult GetExam(int id, string title)
        {
            ExamViewModel model = new ExamViewModel
            {
                Exam = _examService.GetExam(id).Result.Data,
                Questions = _questionService.GetQuestionsByExamId(id).Result.Data
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddExam([FromBody] ExamRequest request)
        {
            return View(_examService.Add(request).Result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> RemoveExam(int id)
        {

            await _examService.Delete(id);

            return Redirect("/Exam/Index");
        }
    }
}
