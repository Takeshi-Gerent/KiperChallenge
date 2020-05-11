using Condominium.Api.Domain;
using Condominium.Application.Commands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.Mappers
{
    public static class DwellerMapper
    {
        public static IEnumerable<Dweller> FromDwellerDtoList(IEnumerable<DwellerDto> dwellerDtos)
        {
            return dwellerDtos?.Select(d => FromDwellerDto(d));
        }

        private static Dweller FromDwellerDto(DwellerDto dwellerDto)
        {
            return Dweller.FromId(dwellerDto.Id, dwellerDto.Name, dwellerDto.BirthDate.Value, dwellerDto.Telephone, dwellerDto.CPF, dwellerDto.Email, null);
        }

        public static IEnumerable<Application.Queries.DwellerDto> ToDwellerDtoList(IEnumerable<Dweller> dwellers)
        {
            return dwellers?.Select(d => ToDwellerDto(d));
        }

        private static Application.Queries.DwellerDto ToDwellerDto(Dweller dweller)
        {
            return new Application.Queries.DwellerDto {
                Id = dweller.Id,
                Name = dweller.Name,
                BirthDate = dweller.BirthDate,
                Telephone = dweller.Telephone,
                CPF = dweller.CPF,
                Email = dweller.Email                
            };
        }
    }
}
