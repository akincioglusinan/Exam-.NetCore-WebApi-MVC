﻿using SinavProje.DataAccess.Abstract;
using SinavProje.DataAccess.Concrete.Base;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.DataAccess.Concrete.SqLite
{
    public class QuestionRepository: Repository<Question, SqLiteDbContext>, IQuestionRepository
    {
    }
}
