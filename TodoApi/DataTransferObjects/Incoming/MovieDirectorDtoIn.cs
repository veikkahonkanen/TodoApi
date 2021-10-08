using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DataTransferObjects.Incoming
{
    public class MovieDirectorDtoIn : BaseDto
    {
        public long? PersonId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }

    public class MovieDirectorDtoInProfile : Profile
    {
        public MovieDirectorDtoInProfile()
        {
            CreateMap<MovieDirectorDtoIn, Models.Director>()
                .ForMember(director => director.Person.FirstName, s => s.MapFrom(directorDto => directorDto.FirstName))
                .ForMember(director => director.Person.LastName, s => s.MapFrom(directorDto => directorDto.LastName))
                .ForMember(director => director.Person.BirthDate, s => s.MapFrom(directorDto => directorDto.BirthDate));
        }
    }
}
