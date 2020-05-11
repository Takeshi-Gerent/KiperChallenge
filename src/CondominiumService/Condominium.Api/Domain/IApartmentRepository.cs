using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.Domain
{
    public interface IApartmentRepository
    {
        Task<Apartment> GetById(int id);
        void Add(Apartment apartment);
        void Update(Apartment apartment);
        void Delete(int id);
        Task<ICollection<Apartment>> GetAll();
    }
}
