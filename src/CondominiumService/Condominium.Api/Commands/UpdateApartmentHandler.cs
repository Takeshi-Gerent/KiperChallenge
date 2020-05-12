﻿using Condominium.Broker.Commands.UpdateApartmentCommand;
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
    public class UpdateApartmentHandler : IRequestHandler<UpdateApartmentCommand, UpdateApartmentCommandResult>
    {
        private readonly IUnitOfWork uow;

        public UpdateApartmentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<UpdateApartmentCommandResult> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Validate(request);
                var apartment = await uow.ApartmentRepository.GetById(request.Id);
                if (apartment == null) throw new Exception("Apartamento não localizado.");
                apartment.UpdateData(request.Number, request.Block, FromDwellerDtoList(request.Dwellers));
                uow.ApartmentRepository.Update(apartment);
                await uow.CommitChanges();
                return new UpdateApartmentCommandResult { Success = true, Message="Apartamento atualizado com sucesso.", ApartmentId = apartment.Id };
            }
            catch (Exception e)
            {
                return new UpdateApartmentCommandResult { Success = false, Message = e.Message };
            }
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
