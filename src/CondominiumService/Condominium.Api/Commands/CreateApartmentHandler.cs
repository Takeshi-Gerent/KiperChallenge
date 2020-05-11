using Condominium.Api.Domain;
using Condominium.Api.Mappers;
using Condominium.Application.Commands;
using Condominium.Application.Commands.Dtos;
using Condominium.Application.Commands.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Commands
{
    public class CreateApartmentHandler : IRequestHandler<CreateApartmentCommand, ApartmentDto>
    {
        private readonly IUnitOfWork uow;

        public CreateApartmentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<ApartmentDto> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            var apartment = Apartment.New(request.Number, request.Block, DwellerMapper.FromDwellerDtoList(request.Dwellers));

            uow.ApartmentRepository.Add(apartment);           
            await uow.CommitChanges();

            return new ApartmentDto { Id = apartment.Id };
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
    }
}
