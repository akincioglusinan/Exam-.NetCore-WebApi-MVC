using System.Collections.Generic;
using System.Threading.Tasks;
using SinavProje.Core.Utilities.Results;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Business.Abstract
{
    public interface IQuestionService
    {
        Task<IDataResult<List<Question>>> GetQuestions();
        Task<IDataResult<List<Question>>> GetQuestionsByExamId(int examId);
        Task<IDataResult<Question>> GetQuestion(int id);
        Task<IResult> Add(Question question);
        Task<IResult> Update(Question question);
        Task<IResult> Delete(int id);
    }
}
