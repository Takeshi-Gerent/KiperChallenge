using Condominium.Core.Domain;
using FluentNHibernate.Mapping;

namespace Condominium.Data.DataAccess.NHMapping
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
