using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
    }
}
