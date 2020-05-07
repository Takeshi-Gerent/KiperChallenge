using Auth.Api.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.DataAccess.NHibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession session;
        private readonly ITransaction tx;

        private readonly UserRepository userRepository;
        public IUserRepository UserRepository => userRepository;

        public UnitOfWork(ISession session)
        {
            this.session = session;
            tx = session.BeginTransaction();
            userRepository = new UserRepository(session);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                tx?.Dispose();
            }
        }
    }
}
