﻿using System.Collections.Generic;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Entities.Concrete.ClientEntities.Request
{
    public class ExamRequest
    {
        public Exam Exam { get; set; }
        public List<Question> Questions { get; set; }
        
    }
}
