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
            return Dweller.FromId(dwellerDto.Id, dwellerDto.Name, dwellerDto.BirthDate, dwellerDto.Telephone, dwellerDto.CPF, dwellerDto.Email, null);
        }
    }
}
