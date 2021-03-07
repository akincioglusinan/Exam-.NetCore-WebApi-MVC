using System.Collections.Generic;
using System.Threading.Tasks;
using SinavProje.Core.Utilities.Results;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Business.Abstract
{
    public interface IExamService
    {
        Task<IDataResult<List<Exam>>> GetExams();
        Task<IDataResult<Exam>> GetExam(int id);
        Task<IResult> Add(ExamRequest request);
        Task<IResult> Update(Exam exam);
        Task<IResult> Delete(int id);
    }
}
