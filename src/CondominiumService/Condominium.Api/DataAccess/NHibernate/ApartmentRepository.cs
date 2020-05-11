using Condominium.Api.Domain;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.DataAccess.NHibernate
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly ISession session;

        public ApartmentRepository(ISession session)
        {
            this.session = session;
        }

        public async Task<Apartment> GetById(int id)
        {
            return await session.GetAsync<Apartment>(id);
        }

        public void Add(Apartment apartment)
        {
            session.Save(apartment);
        }

        public void Update(Apartment apartment)
        {
            session.SaveOrUpdate(apartment);
        }

        public void Delete(int id)
        {
            session.Delete(session.Load<Apartment>(id));
        }

        public async Task<ICollection<Apartment>> GetAll()
        {
            return await session.Query<Apartment>().ToListAsync();
        }

    }
}
