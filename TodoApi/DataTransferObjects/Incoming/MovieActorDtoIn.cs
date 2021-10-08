using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DataTransferObjects.Incoming
{
    public class MovieActorDtoIn : BaseDto
    {
        public long? PersonId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }

    public class MovieActorDtoInProfile : Profile
    {
        public MovieActorDtoInProfile()
        {
            CreateMap<MovieActorDtoIn, Models.Actor>()
                .ForMember(actor => actor.Person.FirstName, s => s.MapFrom(actorDto => actorDto.FirstName))
                .ForMember(actor => actor.Person.LastName, s => s.MapFrom(actorDto => actorDto.LastName))
                .ForMember(actor => actor.Person.BirthDate, s => s.MapFrom(actorDto => actorDto.BirthDate));
        }
    }
}
