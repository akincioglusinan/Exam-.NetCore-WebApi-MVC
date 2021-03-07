using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SinavProje.Core.Utilities.Results;
using SinavProje.Entities.Concrete.ClientEntities.Response;

namespace SinavProje.Business.Abstract
{
    public interface IArticlesService
    {
        Task<IDataResult<List<ArticleResponse>>> GetArticles();
    }
}
