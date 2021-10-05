using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class ActorDto
    {
        public long? Id { get; set; }

        public PersonDto? Person { get; set; }

        public ICollection<CrewDto>? Crews { get; set; }
    }

    public class ActorDtoProfile : Profile
    {
        public ActorDtoProfile()
        {
            CreateMap<Models.Actor, ActorDto>().ReverseMap();
        }
    }
}
