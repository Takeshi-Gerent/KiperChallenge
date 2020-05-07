using Condominium.Api.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.DataAccess.NHibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession session;
        private readonly ITransaction tx;
        private readonly ApartmentRepository apartmentRepository;
        private readonly DwellerRepository dwellerRepository;

        public IApartmentRepository ApartmentRepository => apartmentRepository;

        public IDwellerRepository DwellerRepository => dwellerRepository;

        public UnitOfWork(ISession session)
        {
            this.session = session;
            tx = session.BeginTransaction();
            apartmentRepository = new ApartmentRepository(session);
            dwellerRepository = new DwellerRepository(session);
        }

        public async Task CommitChanges()
        {            
            await tx.CommitAsync();
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
