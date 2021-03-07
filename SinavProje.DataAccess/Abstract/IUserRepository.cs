using System;
using System.Collections.Generic;
using System.Text;
using SinavProje.DataAccess.Abstract.Base;
using SinavProje.Entities;
using SinavProje.Entities.Concrete;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.DataAccess.Abstract
{
    public interface IUserRepository: IRepository<User>
    {
    }
}
