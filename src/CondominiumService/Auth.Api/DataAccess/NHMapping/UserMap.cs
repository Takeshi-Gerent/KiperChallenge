using Auth.Api.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.DataAccess.NHMapping
{
    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.UserName).Not.Nullable();
            Map(p => p.Password).Not.Nullable();
        }
    }
}
