using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.Domain
{
    public interface IUserRepository
    {
        Task<User> FindByUserName(string userName);
    }
}
