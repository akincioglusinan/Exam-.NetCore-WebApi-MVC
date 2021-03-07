using System.Collections.Generic;
using System.Threading.Tasks;
using SinavProje.Core.Utilities.Results;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<User>>> GetUsers();
        Task<IDataResult<User>> GetUserById(int id);
        Task<IDataResult<User>> GetUserByEmail(string email);
        Task<IResult> Add(User user);
        Task<IResult> Update(User user);
        Task<IResult> Delete(int id);
    }
}
