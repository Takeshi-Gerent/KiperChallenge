using Condominium.Api.Domain;
using FluentNHibernate.Mapping;
using FluentNHibernate.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.DataAccess.NHMapping
{
    public class ApartmentMap : ClassMap<Apartment>
    {
        public ApartmentMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Number).Not.Nullable();
            Map(p => p.Block);

            HasMany(p => p.Dwellers).AsSet().Cascade.AllDeleteOrphan().Not.LazyLoad().Fetch.Select().Inverse();
        }
    }
}
