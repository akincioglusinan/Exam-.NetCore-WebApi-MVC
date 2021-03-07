using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SinavProje.DataAccess.Abstract.Base
{
    public interface IRepository<T>
    {
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);

        Task<int> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
