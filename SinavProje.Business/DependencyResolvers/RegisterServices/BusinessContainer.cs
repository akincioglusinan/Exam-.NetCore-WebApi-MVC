using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SinavProje.Business.Abstract;
using SinavProje.Business.Concrete;

namespace SinavProje.Business.DependencyResolvers.RegisterServices
{
    public static class BusinessContainer
    {
        public static void AddScopedBusinessServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAuthService, AuthManager>();
            serviceCollection.AddScoped<IUserService, UserManager>();
            serviceCollection.AddScoped<IArticlesService, ArticleManager>();
            serviceCollection.AddScoped<IExamService, ExamManager>();
            serviceCollection.AddScoped<IQuestionService, QuestionManager>();
        }
    }
}
