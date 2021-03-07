using System.Collections.Generic;
using SinavProje.Core.Utilities.Results;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Models
{
    public class ExamViewModel
    {
        
        public IDataResult<Exam> Exam { get; set; }
        public IDataResult<List<Question>> Questions { get; set; }
    }
}
