using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class MovieDirectorDto : BaseDto
    {
        public long? PersonId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }

    public class DirectorDtoProfile : Profile
    {
        public DirectorDtoProfile()
        {
            CreateMap<Models.Director, MovieDirectorDto>()
                .ForMember(directorDto => directorDto.FirstName, s => s.MapFrom(director => director.Person.FirstName))
                .ForMember(directorDto => directorDto.LastName, s => s.MapFrom(director => director.Person.LastName))
                .ForMember(directorDto => directorDto.BirthDate, s => s.MapFrom(director => director.Person.BirthDate));
        }
    }
}
