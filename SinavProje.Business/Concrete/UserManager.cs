using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SinavProje.Business.Abstract;
using SinavProje.Business.Constants;
using SinavProje.Core.Utilities.Results;
using SinavProje.DataAccess.Abstract;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Business.Concrete
{
    public class UserManager:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IDataResult<List<User>>> GetUsers()
        {
            try
            {
                return new SuccessDataResult<List<User>>(await _userRepository.GetList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<User>>(Messages.GetUsersError);
            }
        }

        public async Task<IDataResult<User>> GetUserById(int id)
        {
            try
            {
                return new SuccessDataResult<User>(await _userRepository.Get(x => x.Id == id));
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>(Messages.GetUserError);
            }
        }

        public async Task<IDataResult<User>> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userRepository.Get(x => x.Email == email);
                if (user!=null)
                {
                    return new SuccessDataResult<User>(user);
                }
                else
                {
                    return new ErrorDataResult<User>(Messages.UserAlreadyExists);
                }
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>(Messages.GetUserError);
            }
        }

        public async Task<IResult> Add(User user)
        {
            try
            {
                await _userRepository.Add(user);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UserAddError);
            }

            return new SuccessResult(Messages.UserAdded);
        }

        public async Task<IResult> Update(User user)
        {
            try
            {
                await _userRepository.Update(user);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UserUpdateError);
            }

            return new SuccessResult(Messages.UserUpdated);
        }

        public async Task<IResult> Delete(int id)
        {
            try
            {
                await _userRepository.Delete(await _userRepository.Get(x=>x.Id==id));
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UserDeleteError);
            }

            return new SuccessResult(Messages.UserDeleted);
        }
    }
}
