using Auth.Api.Domain;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.DataAccess.NHibernate
{
    public class UserRepository : IUserRepository
    {
        private readonly ISession session;

        public UserRepository(ISession session)
        {
            this.session = session;
        }

        public async Task<User> FindByUserName(string userName)
        {
            return await session.Query<User>().FirstOrDefaultAsync(p => p.UserName == userName);
        }
    }
}
