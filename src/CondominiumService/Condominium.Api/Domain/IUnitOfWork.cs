using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.Domain
{
    public interface IUnitOfWork: IDisposable
    {
        IApartmentRepository ApartmentRepository { get; }
        IDwellerRepository DwellerRepository { get; }
        Task CommitChanges();
    }
}
