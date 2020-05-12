using Condominium.Api.Queries;
using Condominium.Broker.Queries.FindAllApartmentsQuery;
using Condominium.Core.Domain;
using Condominium.Test.TestData;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Condominium.Test.Handlers
{
    public class ApartmentHandlersTest
    {
        private readonly Mock<IApartmentRepository> apartmentRepository;
        private readonly Mock<IUnitOfWork> uow;

        private readonly ICollection<Apartment> apartments = new List<Apartment>
        {
            TestGetAllApartmentFactory.Apartment201(),
            TestGetAllApartmentFactory.Apartment211(),
            TestGetAllApartmentFactory.Apartment212()
        };

        public ApartmentHandlersTest()
        {
            uow = new Mock<IUnitOfWork>();
            apartmentRepository = new Mock<IApartmentRepository>();
            apartmentRepository.Setup(x => x.GetAll()).Returns(Task.FromResult(apartments));

            uow.Setup(x => x.ApartmentRepository).Returns(apartmentRepository.Object);
        }

        [Fact]
        public async Task FindAllApartments_ReturnListOfAllApartments()
        {
            var handler = new FindAllApartmentsHandler(uow.Object);
            var result = await handler.Handle(new FindAllApartmentsQuery(), new CancellationToken());
            Assert.NotNull(result);
            Assert.Equal(apartments.Count, result.Apartments.Count);
        }
    }
}
