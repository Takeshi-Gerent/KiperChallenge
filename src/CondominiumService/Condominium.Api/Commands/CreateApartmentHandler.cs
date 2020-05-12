using Condominium.Broker.Commands.CreateApartmentCommand;
using Condominium.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Commands
{
    public class CreateApartmentHandler : IRequestHandler<CreateApartmentCommand, CreateApartmentCommandResult>
    {
        private readonly IUnitOfWork uow;

        public CreateApartmentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<CreateApartmentCommandResult> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Validate(request);
                var apartment = Apartment.New(request.Number, request.Block, FromDwellerDtoList(request.Dwellers));

                uow.ApartmentRepository.Add(apartment);
                await uow.CommitChanges();

                return new CreateApartmentCommandResult { Success = true, Message = "Apartamento criado com sucesso.", ApartmentId = apartment.Id };
            } 
            catch (Exception e)
            {
                return new CreateApartmentCommandResult { Success = false, Message = e.Message };
            }
        }

        private static void Validate(CreateApartmentCommand command)
        {
            var validator = new CreateApartmentCommandValidator();
            var validationResult = validator.Validate(command);

            if(!validationResult.IsValid)
            {
                var errorBuilder = new StringBuilder();
                errorBuilder.AppendLine("Apartamento informado inválido.");
                foreach(var error in validationResult.Errors)
                {
                    errorBuilder.AppendLine(error.ErrorMessage);
                }
                throw new Exception(errorBuilder.ToString());
            }
        }

        private static IEnumerable<Dweller> FromDwellerDtoList(IEnumerable<DwellerDto> dwellerDtos)
        {
            return dwellerDtos?.Select(d => FromDwellerDto(d));
        }

        private static Dweller FromDwellerDto(DwellerDto dwellerDto)
        {
            return Dweller.FromId(dwellerDto.Id, dwellerDto.Name, dwellerDto.BirthDate.Value, dwellerDto.Telephone, dwellerDto.CPF, dwellerDto.Email, null);
        }

    }

}
