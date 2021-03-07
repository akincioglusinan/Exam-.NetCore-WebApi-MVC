using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SinavProje.Business.Abstract;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Filter;
using SinavProje.Models;

namespace SinavProje.Controllers
{
    [UserFilter]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly IQuestionService _questionService;

        public ExamController(IExamService examService, IQuestionService questionService)
        {
            _examService = examService;
            _questionService = questionService;
        }
        public async Task<IActionResult> Index()
        {
            var result =await _examService.GetExams();

            return View(result);
        }

        [HttpGet("/{id}/{title}")]
        public async Task<IActionResult> GetExam(int id, string title)
        {
            var resultExam = await _examService.GetExam(id);
            var resultQuestions = await _questionService.GetQuestionsByExamId(id);
            ExamViewModel model = new ExamViewModel
            {
                Exam =  resultExam,
                Questions = resultQuestions
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
