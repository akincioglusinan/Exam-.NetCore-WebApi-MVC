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


        public async Task<IDataResult<User>> Register(RegisterRequest request, string password)
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
            await _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public async Task<IDataResult<User>> Login(LoginRequest request)
        {
            var userToCheck = await _userService.GetUserByEmail(request.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(request.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public async Task<IResult> UserExist(string email)
        {
            var result = await _userService.GetUserByEmail(email);
            if (result.Success)
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
