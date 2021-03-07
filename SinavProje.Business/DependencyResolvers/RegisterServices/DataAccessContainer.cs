using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SinavProje.DataAccess.Abstract;
using SinavProje.DataAccess.Concrete.SqLite;

namespace SinavProje.Business.DependencyResolvers.RegisterServices
{
    public static class DataAccessContainer
    {
        public static void AddScopedDataAccessServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IQuestionRepository, QuestionRepository>();
            serviceCollection.AddScoped<IExamRepository, ExamRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();


        }
    }
}
