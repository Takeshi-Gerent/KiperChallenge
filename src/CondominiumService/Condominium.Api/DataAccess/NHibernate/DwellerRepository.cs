using Condominium.Api.Domain;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public async Task<ICollection<Dweller>> GetAllByApartment(string number, string block)
        {
            Apartment ApartmentAlias = null;

            var query = session.QueryOver<Dweller>()
                .JoinAlias(p => p.Apartment, () => ApartmentAlias);
                
            if (!string.IsNullOrWhiteSpace(number) && int.TryParse(number, out int num))
                query.And(() => ApartmentAlias.Number == num);
            if (!string.IsNullOrWhiteSpace(block))
                query.And(() => ApartmentAlias.Block == block);


            return await query.TransformUsing(Transformers.DistinctRootEntity).ListAsync<Dweller>();
        }

        public async Task<ICollection<Dweller>> GetAllByDweller(string name, string birthDate, string telephone, string cpf, string email)
        {
            Apartment ApartmentAlias = null;

            DateTime outBirthDate;

            var query = session.QueryOver<Dweller>()
                .JoinAlias(p => p.Apartment, () => ApartmentAlias);
            if (!string.IsNullOrWhiteSpace(name))
                query.And(p => p.Name == name);
            if (!string.IsNullOrWhiteSpace(birthDate) && DateTime.TryParseExact(birthDate, "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out outBirthDate))
                query.And(p => p.BirthDate.Date == outBirthDate);
            if (!string.IsNullOrEmpty(telephone))
                query.And(p => p.Telephone == telephone);
            if (!string.IsNullOrEmpty(email))
                query.And(p => p.Email == email);


            return await query.TransformUsing(Transformers.DistinctRootEntity).ListAsync<Dweller>();
        }

        public async Task<Dweller> GetById(int id)
        {
            return await session.GetAsync<Dweller>(id);
        }

        public void Update(Dweller dweller)
        {
            session.Update(dweller);
        }
    }
}
