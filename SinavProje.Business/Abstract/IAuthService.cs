using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SinavProje.Core.Utilities.Results;
using SinavProje.Core.Utilities.Security.Authorization;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterRequest request, string password);
        IDataResult<User> Login(LoginRequest request);

        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
