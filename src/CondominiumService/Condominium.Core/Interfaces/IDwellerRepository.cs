using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominium.Core.Domain
{
    public interface IDwellerRepository
    {
        void Delete(int id);
        void Update(Dweller dweller);
        void Add(Dweller dweller);
        Task<Dweller> GetById(int id);
        Task<ICollection<Dweller>> GetAllByDweller(string name, string birthDate, string telephone, string cpf, string email);
        Task<ICollection<Dweller>> GetAllByApartment(string number, string block);
    }
}
