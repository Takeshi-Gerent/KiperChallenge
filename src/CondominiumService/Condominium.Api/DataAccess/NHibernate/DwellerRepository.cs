using Condominium.Api.Domain;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.DataAccess.NHibernate
{
    public class DwellerRepository : IDwellerRepository
    {
        private readonly ISession session;

        public DwellerRepository(ISession session)
        {
            this.session = session;
        }

        public void Add(Dweller dweller)
        {
            session.Save(dweller);
        }

        public void Delete(int id)
        {
            session.Delete(session.Load<Dweller>(id));
        }

        public async Task<IEnumerable<Dweller>> FindByApartmentId(int id)
        {
            return await session.Query<Dweller>().Where(p => p.Apartment.Id == id).ToListAsync();
        }

        public void Update(Dweller dweller)
        {
            session.Update(dweller);
        }
    }
}
