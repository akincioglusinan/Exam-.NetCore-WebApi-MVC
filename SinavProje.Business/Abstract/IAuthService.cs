using System.Threading.Tasks;
using SinavProje.Core.Utilities.Results;
using SinavProje.Core.Utilities.Security.Authorization;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> Register(RegisterRequest request, string password);
        Task<IDataResult<User>> Login(LoginRequest request);

        Task<IResult> UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
