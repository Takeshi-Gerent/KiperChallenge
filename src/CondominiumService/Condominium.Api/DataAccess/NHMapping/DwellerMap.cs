using Condominium.Api.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.DataAccess.NHMapping
{
    public class DwellerMap: ClassMap<Dweller>
    {
        public DwellerMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Name).Not.Nullable();
            Map(p => p.BirthDate).Nullable();
            Map(p => p.Telephone).Nullable();
            Map(p => p.CPF).Not.Nullable();
            Map(p => p.Email).Nullable();
            References(p => p.Apartment).Column("ApartmentId").Not.Nullable().Cascade.None();
        }
    }
}
