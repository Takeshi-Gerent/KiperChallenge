using Condominium.Api.Domain;
using Condominium.Api.Mappers;
using Condominium.Application.Commands;
using Condominium.Application.Commands.Dtos;
using Condominium.Application.Commands.Validation;
using MediatR;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Commands
{
    public class UpdateApartmentHandler : IRequestHandler<UpdateApartmentCommand, ApartmentDto>
    {
        private readonly IUnitOfWork uow;

        public UpdateApartmentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<ApartmentDto> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            var apartment = await uow.ApartmentRepository.GetById(request.Id);
            if (apartment == null) throw new Exception("Apartamento não localizado.");
            apartment.UpdateData(request.Number, request.Block, DwellerMapper.FromDwellerDtoList(request.Dwellers));
            uow.ApartmentRepository.Update(apartment);            
            await uow.CommitChanges();

            return new ApartmentDto { Id = apartment.Id };
        }

        private static void Validate(UpdateApartmentCommand command)
        {
            var validator = new UpdateApartmentCommandValidator();
            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
            {
                var errorBuilder = new StringBuilder();
                errorBuilder.AppendLine("Apartamento informado inválido.");
                foreach (var error in validationResult.Errors)
                {
                    errorBuilder.AppendLine(error.ErrorMessage);
                }
                throw new Exception(errorBuilder.ToString());
            }
        }

    }
}
