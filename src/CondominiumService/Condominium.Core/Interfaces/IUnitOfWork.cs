using System;
using System.Threading.Tasks;

namespace Condominium.Core.Domain
{
    public interface IUnitOfWork: IDisposable
    {
        IApartmentRepository ApartmentRepository { get; }
        IDwellerRepository DwellerRepository { get; }
        Task CommitChanges();
    }
}
