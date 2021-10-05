using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class MovieActorDto : BaseDto
    {
        public long? PersonId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }

    public class MovieActorDtoProfile : Profile
    {
        public MovieActorDtoProfile()
        {
            CreateMap<Models.Actor, MovieActorDto>()
                .ForMember(actorDto => actorDto.FirstName, s => s.MapFrom(actor => actor.Person.FirstName))
                .ForMember(actorDto => actorDto.LastName, s => s.MapFrom(actor => actor.Person.LastName))
                .ForMember(actorDto => actorDto.BirthDate, s => s.MapFrom(actor => actor.Person.BirthDate));
        }
    }
}
