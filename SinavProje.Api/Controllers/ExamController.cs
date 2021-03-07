using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SinavProje.Business.Abstract;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly IQuestionService _questionService;
        private readonly IArticlesService _articlesService;

        public ExamController(IExamService examService, IQuestionService questionService, IArticlesService articlesService)
        {
            _examService = examService;
            _questionService = questionService;
            _articlesService = articlesService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var result = await _examService.GetExams();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetArticles")]
        public async Task<IActionResult> GetArticles()
        {
            var result = await _articlesService.GetArticles();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetExam(int id)
        {
            var resultExam = await  _examService.GetExam(id);
            var resultQuestion = await _questionService.GetQuestionsByExamId(id);
            
            if (resultExam.Success && resultQuestion.Success)
            {
                ExamRequest request = new ExamRequest
                {
                    Exam = resultExam.Data, Questions = resultQuestion.Data
                };
                return Ok(request);
            }

            if (!resultExam.Success)
            {
                return BadRequest(resultExam.Message);
            };

            return BadRequest(resultQuestion.Message);
        }

        [HttpPost("AddExam")]
        public async Task<IActionResult> AddExam(ExamRequest request)
        {
            var result = await _examService.Add(request);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        public async Task<IActionResult> RemoveExam(int id)
        {
            var result = await _examService.Delete(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
