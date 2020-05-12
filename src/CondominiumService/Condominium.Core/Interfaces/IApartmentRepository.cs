using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominium.Core.Domain
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
