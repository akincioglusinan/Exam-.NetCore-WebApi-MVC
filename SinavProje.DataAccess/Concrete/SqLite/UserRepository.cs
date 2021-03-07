using System;
using System.Collections.Generic;
using System.Text;
using SinavProje.DataAccess.Abstract;
using SinavProje.DataAccess.Concrete.Base;
using SinavProje.Entities;
using SinavProje.Entities.Concrete;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.DataAccess.Concrete.SqLite
{
    public class UserRepository: Repository<User, SqLiteDbContext>, IUserRepository
    {
    }
}
