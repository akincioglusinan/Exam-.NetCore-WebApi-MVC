using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SinavProje.Core.Utilities.Results;
using SinavProje.Entities;
using SinavProje.Entities.Concrete;
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
