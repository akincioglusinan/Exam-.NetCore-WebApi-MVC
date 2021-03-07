using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
