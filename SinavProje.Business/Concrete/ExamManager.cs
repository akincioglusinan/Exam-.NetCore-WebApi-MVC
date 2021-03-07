using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SinavProje.Business.Abstract;
using SinavProje.Business.Constants;
using SinavProje.Core.Utilities.Results;
using SinavProje.Entities;
using SinavProje.DataAccess.Abstract;
using SinavProje.Entities.Concrete;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Business.Concrete
{
    public class ExamManager : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IQuestionService _questionService;

        public ExamManager(IExamRepository examRepository, IQuestionService questionService)
        {
            _examRepository = examRepository;
            _questionService = questionService;
        }

        public async Task<IResult> Add(ExamRequest request)
        {
            try
            {
                int examId=await _examRepository.Add(request.Exam);

                foreach (var question in request.Questions)
                {
                    question.ExamId = examId;

                    await _questionService.Add(question);
                }
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ExamAddError);
            }
           
            return new SuccessResult(Messages.ExamAdded);
        }

        public async Task<IResult> Delete(int id)
        {
            try
            {
                var questions = _questionService.GetQuestionsByExamId(id).Result.Data;
                foreach (var q in questions)
                {
                    await _questionService.Delete(q.Id);
                }
                await _examRepository.Delete(await _examRepository.Get(x => x.Id == id));
            }
            catch (Exception)
            {
               return new ErrorResult(Messages.ExamDeleteError);
            }
            
            return new SuccessResult(Messages.ExamDeleted);
        }

        public async Task<IDataResult<Exam>> GetExam(int id)
        {
            try
            {
                return new SuccessDataResult<Exam>(await _examRepository.Get(x => x.Id == id));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Exam>(Messages.GetExamError);
            }
            
        }

        public async Task<IDataResult<List<Exam>>> GetExams()
        {
            try
            {
                return new SuccessDataResult<List<Exam>>(await _examRepository.GetList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Exam>>(Messages.GetExamsError);
            }
        }

        public async Task<IResult> Update(Exam exam)
        {
            try
            {
                await _examRepository.Update(exam);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ExamUpdateError);
            }

            return new SuccessResult(Messages.ExamUpdated);
        }
    }
}
