using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.Domain
{
    public interface IDwellerRepository
    {
        Task<IEnumerable<Dweller>> FindByApartmentId(int id);
        void Delete(int id);
        void Update(Dweller dweller);
        void Add(Dweller dweller);
    }
}
