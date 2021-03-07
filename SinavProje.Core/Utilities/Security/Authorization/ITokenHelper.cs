using System;
using System.Collections.Generic;
using System.Text;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Core.Utilities.Security.Authorization
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
}
