using MediatR;

namespace Condominium.Broker.Commands
{
    public class DeleteApartmentCommand : IRequest<DeleteApartmentResult>
    {
        public int Id { get; set; }
    }

    public class DeleteApartmentResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
