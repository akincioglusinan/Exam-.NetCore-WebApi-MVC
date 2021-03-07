using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SinavProje.Business.Abstract;
using SinavProje.Business.Constants;
using SinavProje.Core.Utilities.Results;
using SinavProje.DataAccess.Abstract;
using SinavProje.Entities;
using SinavProje.Entities.Concrete;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Business.Concrete
{
    public class QuestionManager:IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionManager(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }


        public async Task<IDataResult<List<Question>>> GetQuestions()
        {
            try
            {
                return new SuccessDataResult<List<Question>>(await _questionRepository.GetList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Question>>(Messages.GetQuestionsError);
            }
            
        }

        public async Task<IDataResult<List<Question>>> GetQuestionsByExamId(int examId)
        {
            try
            {
                return new SuccessDataResult<List<Question>>(await _questionRepository.GetList(x => x.ExamId == examId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Question>>(Messages.GetQuestionsByExamError);
            }
        }

        public async Task<IDataResult<Question>> GetQuestion(int id)
        {
            try
            {
                return new SuccessDataResult<Question>(await _questionRepository.Get(x => x.Id == id));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Question>(Messages.GetQuestionError);
            }
        }

        public async Task<IResult> Add(Question question)
        {
            try
            {
               await _questionRepository.Add(question);
            }
            catch (Exception)
            {
               return new ErrorResult(Messages.QuestionAddError);
            } 
            
            return new SuccessResult(Messages.QuestionAdded);
        }

        public async Task<IResult> Update(Question question)
        {
            try
            {
                await _questionRepository.Update(question);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.QuestionUpdateError);
            }

            return new SuccessResult(Messages.QuestionUpdated);
           
        }

        public async Task<IResult> Delete(int id)
        {
            try
            {
                await _questionRepository.Delete(await _questionRepository.Get(x=>x.Id==id));
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.QuestionDeleteError);
            }

            return new SuccessResult(Messages.QuestionDeleted);
            
        }
    }
}
