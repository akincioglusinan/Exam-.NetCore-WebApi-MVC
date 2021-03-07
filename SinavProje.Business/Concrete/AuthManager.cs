using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SinavProje.Business.Abstract;
using SinavProje.Business.Constants;
using SinavProje.Core.Utilities.Results;
using SinavProje.Core.Utilities.Security.Authorization;
using SinavProje.Core.Utilities.Security.Authorization.Hashing;
using SinavProje.Entities.Concrete.ClientEntities.Request;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }


        public IDataResult<User> Register(RegisterRequest request, string password)
        {
            HashingHelper.CreatePasswordHash(password, out byte[] passwordHash,
                out byte[] passwordSalt);
            var user = new User
            {
                Email = request.Email,
                Name = request.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                UserName = request.UserName
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(LoginRequest request)
        {
            var userToCheck = _userService.GetUserByEmail(request.Email);
            if (userToCheck.Result.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(request.Password, userToCheck.Result.Data.PasswordHash, userToCheck.Result.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Result.Data, Messages.SuccessfulLogin);
        }

        public IResult UserExist(string email)
        {
            var result = _userService.GetUserByEmail(email);
            if (result.Result.Success)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var accessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
